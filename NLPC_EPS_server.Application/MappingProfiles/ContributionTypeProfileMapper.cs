using AutoMapper;
using NLPC_EPS_server.Application.Features.ContributionType.Query.GetAllContributionType;
using NLPC_EPS_server.Application.Features.ContributionType.Query.GetContributionTypeDetails;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.MappingProfiles
{
    public class ContributionTypeProfileMapper : Profile
    {
        public ContributionTypeProfileMapper()
        {
            CreateMap<ContributionType, ContributionTypeDTO>();
            CreateMap<ContributionType, ContributionTypeDetailsDTO>();
        }
    }
}
