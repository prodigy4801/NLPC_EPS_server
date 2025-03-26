using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.DAL
{
    public class BenefitProcess
    {
        public int Id { get; set; }
        public string ProcessName { get; set; }
        public string Description { get; set; }
    }
    //-> PENDING -> VERIFICATION -> DENIED -> DISPATCHED
}
