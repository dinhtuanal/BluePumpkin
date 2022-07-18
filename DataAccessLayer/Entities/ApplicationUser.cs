using Microsoft.AspNetCore.Identity;
using SharedObjects.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public Gender Gender { get; set; }
        public DateTime? BirtthDay { get; set; }
    }
}
