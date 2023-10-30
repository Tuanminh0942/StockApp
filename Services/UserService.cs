using StockAppApi.Models;
using StockAppApi.Repositories;
using StockAppApi.ViewModel;

namespace StockAppApi.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _UserRepository;

        public UserService(IUserRepository userRepository)
        {
            _UserRepository = userRepository;
        }
        public async Task<User?> Register(RegisterViewModel registerViewModel)
        {
            var ExistingUserName = await _UserRepository.GetByUsername(registerViewModel.UserName??"");
            if (ExistingUserName != null)
            {
                throw new ArgumentException("Username already exists");   
            }
            var ExistingEmail = await _UserRepository.GetByEmail(registerViewModel.Email);
            if (ExistingEmail != null)
            {
                throw new ArgumentException("Email already exists");
            }
            return await _UserRepository.Create(registerViewModel);
        }

        public async Task<string> Login(LoginViewModel loginViewModel)
        {
            return await _UserRepository.Login(loginViewModel);
        }

        public async Task<User?> GetByID(int UserId)
        {
            User? user= await _UserRepository.GetById(UserId);
            return user;
        }
    }
}
