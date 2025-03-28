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
    public class BenefitRequest : BaseEntity
    {
        [Required]
        public int MemberProfileId { get; set; }
        [Required]
        public int EmployeeProfileId { get; set; }
        public int BenefitProcessId { get; set; }
        [Required]
        [StringLength(550)]
        public string RequestDescription { get; set; } = string.Empty;
        public decimal RequestedAmount { get; set; }
        public decimal? DispatchedAmount { get; set; }
        public string? EmployeeComment { get; set; }
        public DateTime? DateDispatched { get; set; }

        [ForeignKey(nameof(MemberProfileId))]
        public MemberProfile MemberProfile { get; set; }

        [ForeignKey(nameof(EmployeeProfileId))]
        public EmployeeProfile EmployeeProfile { get; set; }

        [ForeignKey(nameof(BenefitProcessId))]
        public BenefitProcess BenefitProcess { get; set; }
    }
}
