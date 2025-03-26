using NLPC_EPS_server.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.DAL
{
    public class MemberContribution : BaseEntity
    {
        public Guid Id { get; set; }
        public Guid MemberProfileId { get; set; }
        public int EmployeeProfileId { get; set; }
        public int ContributionTypeId { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime ContributionDate { get; set; }

        public MemberProfile MemberProfile { get; set; }
        public EmployeeProfile EmployeeProfile { get; set; }
        public ContributionType ContributionType { get; set; }
    }
}
