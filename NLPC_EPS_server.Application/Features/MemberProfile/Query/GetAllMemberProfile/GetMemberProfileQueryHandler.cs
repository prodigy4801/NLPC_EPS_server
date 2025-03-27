using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.MemberProfile.Query.GetAllMemberProfile;
namespace NLPC_EPS_server.Application.Features.MemberProfile.Query.GetAllMemberProfile
{
    public class GetMemberProfileQueryHandler : IRequestHandler<GetMemberProfileQuery, List<MemberProfileDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IMemberProfileRepository _memberProfileRepository;
        private readonly IAppLogger<GetMemberProfileQueryHandler> _logger;

        public GetMemberProfileQueryHandler(
            IMapper mapper,
            IMemberProfileRepository memberProfileRepository,
            IAppLogger<GetMemberProfileQueryHandler> logger
        )
        {
            this._mapper = mapper;
            this._memberProfileRepository = memberProfileRepository;
            this._logger = logger;
        }
        public async Task<List<MemberProfileDTO>> Handle(GetMemberProfileQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var memberProfiles = await _memberProfileRepository.GetAsync();
            if (memberProfiles == null || memberProfiles.Count == 0)
            {
                _logger.LogInformation("Get All Employee Profile contains no information.", nameof(memberProfiles));
                throw new NotFoundExceptions(nameof(memberProfiles), "getAllMemberProfile");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<List<MemberProfileDTO>>(memberProfiles);
            _logger.LogInformation("Member Profiles were retrieved successfully", nameof(memberProfiles));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
