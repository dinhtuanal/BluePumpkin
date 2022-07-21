using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class ContactSupport
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Mail { get; set; }
        public string Phone_Number { get; set; }
        public string Skype { get; set; }
        public string CreatedBy { get; set; }
        
    }
}
