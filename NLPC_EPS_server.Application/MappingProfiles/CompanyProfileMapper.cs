using AutoMapper;
using NLPC_EPS_server.Application.Features.Company.Command.CreateCompany;
using NLPC_EPS_server.Application.Features.Company.Command.UpdateCompany;
using NLPC_EPS_server.Application.Features.Company.Query.GetAllCompany;
using NLPC_EPS_server.Application.Features.Company.Query.GetCompanyDetails;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.MappingProfiles
{
    public class CompanyProfileMapper : Profile
    {
        public CompanyProfileMapper()
        {
            CreateMap<Company, CompanyDTO>();
            CreateMap<Company, CompanyDetailsDTO>();
            CreateMap<CreateCompanyCommand, Company>();
            CreateMap<UpdateCompanyCommand, Company>();
        }
    }
}
