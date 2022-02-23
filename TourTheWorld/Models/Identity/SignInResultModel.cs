using Microsoft.AspNetCore.Identity;
using System;

namespace TourTheWorld.Models.Identity
{
    public class SignInResultModel: SignInResult
    {
        public SignInResultModel(SignInResult result)
        {
            Succeeded = result.Succeeded;
            IsLockedOut = result.IsLockedOut;
            RequiresTwoFactor = result.RequiresTwoFactor;
            IsNotAllowed = result.IsNotAllowed;            
        }
        public string Token { get; set; }
        public DateTime? TokenExpiry { get; set; }
    }
}
