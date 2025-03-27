using NLPC_EPS_server.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.DAL
{
    public class MemberProfile : BaseEntity
    {
        public int EmployeeProfileId { get; set; }
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public string StateId { get; set; } = string.Empty;
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public DateTime? DateDeleted { get; set; }

        public EmployeeProfile EmployeeProfile { get; set; }
        public Country Country { get; set; }
        public State State { get; set; }
        public virtual ICollection<MemberContribution> MemberContributions { get; set; }
    }
}
