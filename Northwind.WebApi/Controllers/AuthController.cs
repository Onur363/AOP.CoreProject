using Microsoft.AspNetCore.Mvc;
using Northwind.Business.Abstract;
using Northwind.Entities.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Northwind.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")] //localHost/api/Auth
    public class AuthController:Controller
    {
        private IAuthService authService;
        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost("login")]
        public IActionResult Login(UserLoginDto userLoginDto)
        {
            var userToLogin = authService.Login(userLoginDto);
            if (!userToLogin.IsSuccess)
            {
                return BadRequest(userToLogin.Message);
            }

            var result=authService.CreateAccessToken(userToLogin.Data);
            if(result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }

        [HttpPost("register")]
        public IActionResult Register(UserForRegisterDto userForRegisterDto)
        {
            var userExists = authService.UserExists(userForRegisterDto.Email);
            if (!userExists.IsSuccess)
            {
                return BadRequest(userExists.Message);
            }

            var resultRegister = authService.Register(userForRegisterDto);
            var result = authService.CreateAccessToken(resultRegister.Data);
            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }

            return BadRequest(result.Message);
        }
    }
}
