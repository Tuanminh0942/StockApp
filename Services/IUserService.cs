using StockAppApi.Models;
using StockAppApi.ViewModel;
using System;

namespace StockAppApi.Services
{
    public interface IUserService
    {
        Task<User?> Register(RegisterViewModel registerViewModel);
        Task<string> Login(LoginViewModel loginViewModel);
        Task<User?> GetByID(int UserId);
    }
}
