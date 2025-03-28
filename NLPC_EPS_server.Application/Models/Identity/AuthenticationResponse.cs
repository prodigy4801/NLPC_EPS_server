using NLPC_EPS_server.DAL;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using NLPC_EPS_server.Application.Features.Company.Query.GetAllCompany;

namespace NLPC_EPS_server.Application.Models.Identity
{
    public class AuthenticationResponse
    {
        public string FullName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string? Token { get; set; }
        public CompanyDTO Company { get; set; }
    }
}
