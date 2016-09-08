using System.ComponentModel.DataAnnotations;

using PhotoIndex.API.Enums;

namespace PhotoIndex.API.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage="Required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Required")]
        public string Password { get; set; }
        public LoginActions Action { get; set; }
    }
}