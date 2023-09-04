﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialNetwork.Business.Abstract;
using SocialNetwork.Core.Utilities.EmailHelper;
using SocialNetwork.Entities.DTOs.UserDTOs;

namespace SocialNetwork.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost("register")]
        public IActionResult Register([FromBody]UserRegisterDTO userRegisterDTO)
        {
            var result = _userService.Register(userRegisterDTO);

            if (result.Success)
                return Ok(result);

            return BadRequest(result);
        }
        [HttpGet("verifypassword")]
        public IActionResult VerifyPassword([FromQuery]string email, [FromQuery]string token)
        {
            var result = _userService.VerifyEmail(email, token);
            if (result.Success)
                return Ok(result);
            
            return BadRequest(result);
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody]UserLoginDTO userLoginDTO)
        {
            var result = _userService.Login(userLoginDTO);
            if(result.Success)
                return Ok(result);

            return BadRequest(result);
        }
    }
}
