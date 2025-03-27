using NLPC_EPS_server.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.DAL
{
    public class ContributionType : BaseEntity
    {
        public string Type { get; set; } = string.Empty;
        public string? Description { get; set; }

        public virtual ICollection<MemberContribution> MemberContributions { get; set; }
    }
}
