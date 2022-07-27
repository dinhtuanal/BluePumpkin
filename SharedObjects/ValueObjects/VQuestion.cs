using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VQuestion
    {
        public Guid QuestionId { get; set; }
        public string Title { get; set; }
        public string Answer { get; set; }
        public string CreatedBy { get; set; }
    }
}
