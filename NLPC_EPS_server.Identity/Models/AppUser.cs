using Microsoft.AspNetCore.Identity;
using NLPC_EPS_server.Application.Models.Identity;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLPC_EPS_server.Identity.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? DateDeleted { get; set; }
        public DateTime? DateCreated { get; set; }
        public DateTime? DateModified { get; set; }

        [ForeignKey(nameof(CompanyId))]
        public Company Company { get; set; }
    }
}
