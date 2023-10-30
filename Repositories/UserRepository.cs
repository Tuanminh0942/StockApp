using StockAppApi.Models;
using Microsoft.EntityFrameworkCore;
using StockAppApi.ViewModel;
using Microsoft.Data.SqlClient;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;

namespace StockAppApi.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly StockAppContext _context;
        private readonly IConfiguration _configuration;
        public UserRepository(StockAppContext context, IConfiguration configuration)
        {
            _context = context;
            _configuration = configuration;
        }

        public async Task<User?> Create(RegisterViewModel registerViewModel)
        {
            string sql = "EXECUTE dbo.register_user @user_name, @hashed_password, " +
                                                  "@email, @phone, @full_name, @date_of_birth, @country";
            IEnumerable<User>? result = await _context.Users.FromSqlRaw(sql, new SqlParameter("@user_name", registerViewModel.UserName?? ""),
                                                  new SqlParameter("@hashed_password", registerViewModel.HashedPassword),
                                                  new SqlParameter("@email", registerViewModel.Email),
                                                  new SqlParameter("@phone", registerViewModel.Phone??""),
                                                  new SqlParameter("@full_name", registerViewModel.FullName ?? ""),
                                                  new SqlParameter("@date_of_birth", registerViewModel.DateOfBirth),
                                                  new SqlParameter("@country", registerViewModel.Country ?? "")).ToListAsync();
            User user = result.FirstOrDefault();
            return user;
        }

        public async Task<User?> GetByEmail(string email)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task<User?>GetById(int Id)
        {
            return await _context.Users.FindAsync(Id);
        }

        public async Task<User?> GetByUsername(string username)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.UserName == username);
        }

        public async Task<string> Login(LoginViewModel loginViewModel)
        {
            string sql = "EXECUTE dbo.CheckLogin @email,     @hashed_password";
            IEnumerable<User>? result = await _context.Users.FromSqlRaw(sql,new SqlParameter("@email", loginViewModel.Email),
                                                  new SqlParameter("@hashed_password", loginViewModel.HashedPassword)).ToListAsync();
            User user = result.FirstOrDefault();
            if(user!= null)
            {
                //Tạo jwt string để gửi cho client 
                //Nếu xác thực thành công tạo ra jwt token
                var tokenHandler = new JwtSecurityTokenHandler();
                var key = Encoding.ASCII.GetBytes(_configuration["Jwt:SecretKey"]??"");
                var tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                    }),
                    Expires = DateTime.UtcNow.AddDays(30),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
                };
                var token = tokenHandler.CreateToken(tokenDescriptor);
                var jwtToken= tokenHandler.WriteToken(token);
                return jwtToken;
            }
            else
            {
                throw new Exception("Wrong email or password");
            }
        }
    }
}
