using System;

namespace TourTheWorld.Models.Identity
{
    public class SignInResultModel
    {
        public SignInResultModel(bool isSuccess, string token = "", DateTime? tokenExpiry = null)
        {
            IsSuccess = isSuccess;
            Token = token;
            TokenExpiry = tokenExpiry;
        }
        public bool IsSuccess { get; set; }
        public string Token { get; set; }
        public DateTime? TokenExpiry { get; set; }
    }
}
