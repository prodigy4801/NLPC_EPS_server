using AutoMapper;
using NLPC_EPS_server.Application.Features.BenefitRequest.Command.CreateBenefitRequest;
using NLPC_EPS_server.Application.Features.BenefitRequest.Command.UpdateBenefitRequest;
using NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetAllBenefitRequest;
using NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetBenefitRequestDetails;
using NLPC_EPS_server.Application.Features.MemberContribution.Command.CreateMemberContribution;
using NLPC_EPS_server.Application.Features.MemberContribution.Command.UpdateMemberContribution;
using NLPC_EPS_server.Application.Features.MemberContribution.Query.GetAllMemberContribution;
using NLPC_EPS_server.Application.Features.MemberContribution.Query.GetMemberContributionDetails;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.MappingProfiles
{
    public class MemberContributionProfileMapper : Profile
    {
        public MemberContributionProfileMapper()
        {
            CreateMap<MemberContribution, MemberContributionDTO>();
            CreateMap<MemberContribution, MemberContributionDetailsDTO>();
            CreateMap<CreateMemberContributionCommand, MemberContribution>();
            CreateMap<UpdateMemberContributionCommand, MemberContribution>();
        }
    }
}
