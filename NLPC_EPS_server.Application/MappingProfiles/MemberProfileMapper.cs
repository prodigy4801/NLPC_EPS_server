using AutoMapper;
using NLPC_EPS_server.Application.Features.MemberProfile.Command.CreateMemberProfile;
using NLPC_EPS_server.Application.Features.MemberProfile.Command.UpdateMemberProfile;
using NLPC_EPS_server.Application.Features.MemberProfile.Query.GetAllMemberProfile;
using NLPC_EPS_server.Application.Features.MemberProfile.Query.GetMemberProfileDetails;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.MappingProfiles
{
    public class MemberProfileMapper : Profile
    {
        public MemberProfileMapper()
        {
            CreateMap<MemberProfile, MemberProfileDTO>();
            CreateMap<MemberProfile, MemberProfileDetailsDTO>();
            CreateMap<CreateMemberProfileCommand, MemberProfile>();
            CreateMap<UpdateMemberProfileCommand, MemberProfile>();
        }
    }
}
