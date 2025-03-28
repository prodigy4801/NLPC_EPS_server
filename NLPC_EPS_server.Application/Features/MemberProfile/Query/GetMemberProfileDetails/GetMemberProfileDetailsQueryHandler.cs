using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;

namespace NLPC_EPS_server.Application.Features.MemberProfile.Query.GetMemberProfileDetails
{
    public class GetMemberProfileDetailsQueryHandler : IRequestHandler<GetMemberProfileDetailsQuery, MemberProfileDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly IMemberProfileRepository _memberProfileRepository;
        private readonly IAppLogger<GetMemberProfileDetailsQueryHandler> _logger;

        public GetMemberProfileDetailsQueryHandler(
            IMapper mapper,
            IMemberProfileRepository memberProfileRepository,
            IAppLogger<GetMemberProfileDetailsQueryHandler> logger
        )
        {
            this._mapper = mapper;
            this._memberProfileRepository = memberProfileRepository;
            this._logger = logger;
        }
        public async Task<MemberProfileDetailsDTO> Handle(GetMemberProfileDetailsQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var memberProfile = await _memberProfileRepository.GetActiveById(request.Id);
            if (memberProfile == null)
            {
                _logger.LogInformation("Get Employee Profile Details contains no information.", nameof(memberProfile));
                throw new NotFoundExceptions(nameof(memberProfile), "getMemberProfileDetails");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<MemberProfileDetailsDTO>(memberProfile);
            _logger.LogInformation("Member Profile was retrieved successfully", nameof(memberProfile));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
