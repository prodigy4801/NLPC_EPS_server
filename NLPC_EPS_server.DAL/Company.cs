using NLPC_EPS_server.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.DAL
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int? CountryId { get; set; }
        public long StateId { get; set; }
        public bool ActiveStatus { get; set; }
        public bool DeleteStatus { get; set; }
        public DateTime? DateDeleted { get; set; }

        public Country Country { get; set; }
        public State State { get; set; }
        public virtual ICollection<EmployeeProfile> EmployeeProfiles { get; set; }
    }
}
