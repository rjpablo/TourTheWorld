using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<AuthController> _logger;

        public AuthController(IUsersService usersService,
            ILogger<AuthController> logger)
        {
            _usersService = usersService;
            _logger = logger;
        }

        [HttpPost(nameof(Login))]
        [Route("/Login")]
        public async Task<IActionResult> Login([FromBody] LoginInputModel data)
        {
            var result = await _usersService.LoginAsync(data);
            if (result.Succeeded)
            {
                HttpContext.Session.SetString("Token", result.Token);
                return Ok(result);
            }
            if (result.RequiresTwoFactor)
            {
                return RedirectToPage("./LoginWith2fa", new { ReturnUrl = data.ReturnUrl, data.RememberMe });
            }
            if (result.IsLockedOut)
            {
                _logger.LogWarning("User account locked out.");
                return RedirectToPage("./Lockout");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return Unauthorized(ModelState);
            }
        }
    }
}
