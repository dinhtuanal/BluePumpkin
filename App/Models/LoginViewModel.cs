using System.ComponentModel.DataAnnotations;

namespace App.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Email login required !")]
        [EmailAddress(ErrorMessage = "Must be email !")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Password login required !")]
        public string Password { get; set; }
    }
}
