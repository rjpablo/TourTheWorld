﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TourTheWorld.Models.Identity;

namespace TourTheWorld.Services
{
    public class UsersService: IUsersService
    {
        private IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signinManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public UsersService(IConfiguration config,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signinManager)
        {
            _configuration  = config;
            _signinManager = signinManager;
            _userManager = userManager;
        }

        public async Task<SignInResultModel> LoginAsync(LoginInputModel model)
        {
            var result = await _signinManager.PasswordSignInAsync(model.Username, model.Password, model.RememberMe, lockoutOnFailure: false);
            SignInResultModel toReturn = new SignInResultModel(result);
            
            var user = await _userManager.FindByNameAsync(model.Username);
            if (result.Succeeded)
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
                DateTime tokenExpiry = DateTime.Now.AddHours(3);

                var token = new JwtSecurityToken(
                    issuer: _configuration["JWT:ValidIssuer"],
                    audience: _configuration["JWT:ValidAudience"],
                    expires: tokenExpiry,
                    claims: authClaims,
                    signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                    );
                string strToken = new JwtSecurityTokenHandler().WriteToken(token);

                toReturn.Token = strToken;
                toReturn.TokenExpiry = tokenExpiry;

                return toReturn;
            }
            return toReturn;
        }

    }
}
