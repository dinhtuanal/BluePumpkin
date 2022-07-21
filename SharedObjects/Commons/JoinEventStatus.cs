using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace SharedObjects.Commons
{
    public enum JoinEventStatus
    {
        InActive,
        Failed,
        Peding, 
        Accepted,
        Won
    }
}
