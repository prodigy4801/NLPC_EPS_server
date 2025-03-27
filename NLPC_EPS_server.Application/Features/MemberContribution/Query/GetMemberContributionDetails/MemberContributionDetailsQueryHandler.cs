using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.ContributionType.Query.GetAllContributionType;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetAllEmployeeProfile;
using NLPC_EPS_server.Application.Features.MemberContribution.Query.GetMemberContributionDetails;
using NLPC_EPS_server.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.MemberContribution.Query.GetMemberContributionDetails
{
    public class GetMemberContributionDetailsQueryHandler : IRequestHandler<GetMemberContributionDetailsQuery, MemberContributionDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly IMemberContributionRepository _memberContributionRepository;
        private readonly IAppLogger<GetMemberContributionDetailsQueryHandler> _logger;

        public GetMemberContributionDetailsQueryHandler(
            IMapper mapper,
            IMemberContributionRepository memberContributionRepository,
            IAppLogger<GetMemberContributionDetailsQueryHandler> logger
        )
        {
            this._mapper = mapper;
            this._memberContributionRepository = memberContributionRepository;
            this._logger = logger;
        }
        public async Task<MemberContributionDetailsDTO> Handle(GetMemberContributionDetailsQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var memberContribution = await _memberContributionRepository.GetByIdAsync(request.Id);
            if (memberContribution == null)
            {
                _logger.LogInformation("Get Member Contribution Details contains no information.", nameof(MemberContribution));
                throw new NotFoundExceptions(nameof(memberContribution), "getMemberContributionDetails");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<MemberContributionDetailsDTO>(memberContribution);
            _logger.LogInformation("Member Profile was retrieved successfully", nameof(memberContribution));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
