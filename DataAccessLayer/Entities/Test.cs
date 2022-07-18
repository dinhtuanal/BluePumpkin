﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Entities
{
    public class Test
    {
        public Guid TestId { get; set; }
        [Required(ErrorMessage ="Testname required !")]
        public string TestName { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
