using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourTheWorld.Models.Identity;
using TourTheWorld.Services;

namespace TourTheWorld.Controllers.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IUsersService _usersService;

        public AuthController(IUsersService usersService)
        {
            _usersService = usersService;
        }

        [HttpPost(nameof(Login))]
        [Route("/Login")]
        public async Task<IActionResult> Login([FromBody] LoginModel data)
        {
            var result = await _usersService.LoginAsync(data);
            if (result.IsSuccess)
            {
                return Ok(result);
            }

            return Unauthorized(new SignInResultModel(false, "Username or password is incorrect"));
        }
    }
}
