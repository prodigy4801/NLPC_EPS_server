using NLPC_EPS_server.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.DAL
{
    public class BenefitProcess : BaseEntity
    {
        public string ProcessCode { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<BenefitRequest> BenefitRequests { get; set; }
    }
    //-> PENDING -> VERIFICATION -> DENIED -> DISPATCHED
}
