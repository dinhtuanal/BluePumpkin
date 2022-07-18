using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.ValueObjects
{
    public class VTest
    {
        public Guid TestId { get; set; }
        public string TestName { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
