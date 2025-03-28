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
    public class EmployeeProfile : BaseEntity
    {
        public int CompanyId { get; set; }
        [Required]
        [StringLength(550)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [StringLength(550)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        [StringLength(255)]
        public string? PasswordHashed { get; set; } = string.Empty;
        public bool EmailConfirmed { get; set; } = false;
        public string? RefreshToken { get; set; }
        public DateTime? RefreshTokenExpiration { get; set; }
        public bool DeleteStatus { get; set; }
        public DateTime? DateDeleted { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }
        public virtual ICollection<MemberProfile> MemberProfiles { get; set; }
    }
}
