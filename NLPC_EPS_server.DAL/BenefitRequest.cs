using NLPC_EPS_server.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.DAL
{
    public class BenefitRequest : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid MemberProfileId { get; set; }
        public int EmployeeProfileId { get; set; }
        public int BenefitProcessId { get; set; }
        public string RequestDescription { get; set; } = string.Empty;
        public decimal RequestedAmount { get; set; }
        public decimal DispatchedAmount { get; set; }
        public string? EmployeeComment { get; set; }
        public DateTime DateDispatched { get; set; }

        public MemberProfile MemberProfile { get; set; }
        public EmployeeProfile EmployeeProfile { get; set; }
        public BenefitProcess BenefitProcess { get; set; }
    }
}
