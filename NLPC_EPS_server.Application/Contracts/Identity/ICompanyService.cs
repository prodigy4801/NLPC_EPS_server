using NLPC_EPS_server.Application.Models.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Contracts.Identity
{
    public interface ICompanyService
    {
        Task<List<Company>> GetCompanies();
        Task<Company> GetCompany(int companyId);
    }
}
