using AutoMapper;
using NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetAllBenefitProcess;
using NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetBenefitProcessDetails;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.MappingProfiles
{
    internal class BenefitProcessProfile : Profile
    {
        public BenefitProcessProfile()
        {
            CreateMap<BenefitProcess, BenefitProcessDTO>();
            CreateMap<BenefitProcess, BenefitProcessDetailsDTO>();
        }
    }
}
