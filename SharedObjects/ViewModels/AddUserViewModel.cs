using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class AddUserViewModel
    {
        [Required(ErrorMessage = "Username required !")]
        public string UserName { get; set; }
        [Required(ErrorMessage = "Email required !")]
        [EmailAddress(ErrorMessage = "Must be email !")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Fist Name required !")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name required !")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Country required !")]
        public string Country { get; set; }
        [Required(ErrorMessage = "Phone number required !")]
        public string AvataUrl { get; set; }
        public string PhoneNumber { get; set; }
        public int Gender { get; set; }
        [Required(ErrorMessage = "Birthday required !")]
        [DataType(DataType.DateTime, ErrorMessage = "Must be type datetime")]
        public DateTime BirthDay { get; set; }
        [Required(ErrorMessage = "Password required !")]
        public string Password { get; set; }
    }
}
