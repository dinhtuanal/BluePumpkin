using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ViewModels
{
    public class QuestionViewModel
    {
        public string QuestionId { get; set; }
        [Required(ErrorMessage = "Title requied !")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Answer requied !")]
        public string Answer { get; set; }
        public string CreatedBy { get; set; }
    }
}
