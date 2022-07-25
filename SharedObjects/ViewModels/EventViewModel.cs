﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class EventViewModel
    {
        public string EventId { get; set; }
        [Required(ErrorMessage ="Event Name required !")]
        public string EventName { get; set; }
        public int EventStatus { get; set; }
        [MinLength(6, ErrorMessage ="Please enter title better than 6 character !")]
        [Required(ErrorMessage ="Title required !")]
        public string Title { get; set; }
        [Required(ErrorMessage ="Content required !")]
        public string Content { get; set; }
        public DateTime TimeStart { get; set; }
        public DateTime TimeEnd { get; set; }
        public string CreatedBy { get; set; }
    }
}
