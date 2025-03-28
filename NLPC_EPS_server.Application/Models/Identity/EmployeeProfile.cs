using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Models.Identity
{
    public class EmployeeProfile
    {
        public int CompanyId { get; set; }
        [Required]
        [StringLength(550)]
        public string FullName { get; set; } = string.Empty;
        [Required]
        [StringLength(550)]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }
    }
}
