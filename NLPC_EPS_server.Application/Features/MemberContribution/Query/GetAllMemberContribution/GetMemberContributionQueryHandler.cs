using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.MemberContribution.Query.GetAllMemberContribution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.MemberContribution.Query.GetAllMemberContribution
{
    public class GetMemberContributionQueryHandler : IRequestHandler<GetMemberContributionQuery, List<MemberContributionDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IMemberContributionRepository _memberContributionRepository;
        private readonly IAppLogger<GetMemberContributionQueryHandler> _logger;

        public GetMemberContributionQueryHandler(
            IMapper mapper,
            IMemberContributionRepository memberContributionRepository,
            IAppLogger<GetMemberContributionQueryHandler> logger
        )
        {
            this._mapper = mapper;
            this._memberContributionRepository = memberContributionRepository;
            this._logger = logger;
        }
        public async Task<List<MemberContributionDTO>> Handle(GetMemberContributionQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var memberContribution = await _memberContributionRepository.GetAll();
            if (memberContribution == null || memberContribution.Count == 0)
            {
                _logger.LogInformation("Get All Member Contributions contains no information.", nameof(memberContribution));
                throw new NotFoundExceptions(nameof(memberContribution), "getAllMemberContribution");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<List<MemberContributionDTO>>(memberContribution);
            _logger.LogInformation("Member Contributions were retrieved successfully", nameof(memberContribution));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
