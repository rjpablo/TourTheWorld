using System.ComponentModel.DataAnnotations;
using TourTheWorld.Areas.Identity.Pages.Account;

namespace TourTheWorld.Models.Identity
{
    public class LoginInputModel
    {
        public LoginInputModel(LoginModel model, string returnUrl = "")
        {
            Username = model.Input.Email;
            Password = model.Input.Password;
            RememberMe = model.Input.RememberMe;
            ReturnUrl = returnUrl;
        }
        [Required(ErrorMessage = "User Name is required")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }
        public bool RememberMe { get; set; } = true;
        public string ReturnUrl { get; set; }
    }
}
