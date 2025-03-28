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
    public class ContributionType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Type { get; set; } = string.Empty;
        [StringLength(550)]
        public string? Description { get; set; }

        public virtual ICollection<MemberContribution> MemberContributions { get; set; }
    }
}
