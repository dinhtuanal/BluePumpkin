using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class UpdateUserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string AvataUrl { get; set; }
        public string PhoneNumber { get; set; }
        public int Gender { get; set; }
        public DateTime? BirthDay { get; set; }
    }
}
