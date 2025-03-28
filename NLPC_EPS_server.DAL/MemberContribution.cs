using NLPC_EPS_server.DAL.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.DAL
{
    public class MemberContribution : BaseEntity
    {
        public int MemberProfileId { get; set; }
        public int ContributionTypeId { get; set; }
        [StringLength(550)]
        public string? Description { get; set; }
        [Required]
        public decimal Amount { get; set; }
        public DateTime ContributionDate { get; set; }

        [ForeignKey(nameof(MemberProfileId))]
        public MemberProfile MemberProfile { get; set; }
        [ForeignKey(nameof(ContributionTypeId))]
        public ContributionType ContributionType { get; set; }
    }
}
