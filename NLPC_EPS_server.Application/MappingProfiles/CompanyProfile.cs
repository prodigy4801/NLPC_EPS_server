using AutoMapper;
using NLPC_EPS_server.Application.Features.Company.Query.GetAllCompany;
using NLPC_EPS_server.Application.Features.Company.Query.GetCompanyDetails;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.MappingProfiles
{
    public class CompanyProfile : Profile
    {
        public CompanyProfile()
        {
            CreateMap<Company, CompanyDTO>();
            CreateMap<Company, CompanyDetailsDTO>();
        }
    }
}
