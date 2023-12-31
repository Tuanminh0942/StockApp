﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StockAppApi.Models;
using StockAppApi.Services;
using StockAppApi.ViewModel;

namespace StockAppApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost("register")]
        //https://localhost:44314/api/user/register
        public async Task<IActionResult> Register(RegisterViewModel RegisterViewModel)
        {
            try
            {
                User? user = await _userService.Register(RegisterViewModel);
                return Ok(user);
            }
            catch (ArgumentException ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            try
            {
                string JwtToken = await _userService.Login(loginViewModel);
                return Ok(new { JwtToken } );
            }
            catch(ArgumentException ex)
            {
                return BadRequest(new {Message =  ex.Message});
            }
        }
    }
}
