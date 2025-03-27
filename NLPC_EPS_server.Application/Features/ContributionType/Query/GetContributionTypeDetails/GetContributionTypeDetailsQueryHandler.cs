using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.ContributionType.Query.GetContributionTypeDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.ContributionType.Query.GetContributionTypeDetails
{
    public class GetContributionTypeQueryHandler : IRequestHandler<GetContributionTypeDetailsQuery, ContributionTypeDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly IContributionTypeRepository _contributionTypeRepository;
        private readonly IAppLogger<GetContributionTypeQueryHandler> _logger;

        public GetContributionTypeQueryHandler(
            IMapper mapper,
            IContributionTypeRepository contributionTypeRepository,
            IAppLogger<GetContributionTypeQueryHandler> logger
        )
        {
            this._mapper = mapper;
            this._contributionTypeRepository = contributionTypeRepository;
            this._logger = logger;
        }
        public async Task<ContributionTypeDetailsDTO> Handle(GetContributionTypeDetailsQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var contributionType = await _contributionTypeRepository.GetByIdAsync(request.Id);
            if (contributionType == null)
            {
                _logger.LogInformation("Get Contribution Type Details contains no information.", nameof(contributionType));
                throw new NotFoundExceptions(nameof(contributionType), "getContributionTypeDetails");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<ContributionTypeDetailsDTO>(contributionType);
            _logger.LogInformation("Benefit Process was retrieved successfully", nameof(contributionType));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
