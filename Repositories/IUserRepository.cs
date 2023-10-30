using StockAppApi.Models;
using StockAppApi.ViewModel;

namespace StockAppApi.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetById(int Id);
        Task<User?> GetByUsername(string username);
        Task<User?> GetByEmail(string email);
        Task<User?> Create(RegisterViewModel registerViewModel);
        Task<string> Login(LoginViewModel loginViewModel);
    }
}
