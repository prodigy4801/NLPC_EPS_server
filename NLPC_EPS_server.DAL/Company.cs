using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.DAL
{
    public class Company
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int CountryId { get; set; }
        public string StateId { get; set; } = string.Empty;

        public virtual ICollection<EmployeeProfile> EmployeeProfiles { get; set; }
    }
}
