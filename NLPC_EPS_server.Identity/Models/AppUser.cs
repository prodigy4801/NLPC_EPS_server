using Microsoft.AspNetCore.Identity;

namespace NLPC_EPS_server.Identity.Models
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public int CompanyId { get; set; }
    }
}
