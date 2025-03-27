using NLPC_EPS_server.Application.Features.Country.Query.GetAllCountry;
using NLPC_EPS_server.Application.Features.State.Query.GetAllState;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.Features.Company.Query.GetCompanyDetails
{
    public class CompanyDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;

        public CountryDTO Country { get; set; }
        public StateDTO State { get; set; }
    }
}
