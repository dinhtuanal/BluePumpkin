using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class LoginViewModel
    {
        [Required(ErrorMessage ="Email login required !")]
        [EmailAddress(ErrorMessage ="Must be email !")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Password login required !")]
        public string Password { get; set; }
    }
}
