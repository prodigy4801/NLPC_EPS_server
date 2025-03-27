using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;

namespace NLPC_EPS_server.Application.Features.ContributionType.Query.GetAllContributionType
{
    public class GetContributionTypeQueryHandler : IRequestHandler<GetContributionTypeQuery, List<ContributionTypeDTO>>
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
        public async Task<List<ContributionTypeDTO>> Handle(GetContributionTypeQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var contributionTypes = await _contributionTypeRepository.GetAsync();
            if (contributionTypes == null || contributionTypes.Count == 0)
            {
                _logger.LogInformation("Get All Contribution Types contains no information.", nameof(contributionTypes));
                throw new NotFoundExceptions(nameof(contributionTypes), "getAllContributionTypes");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<List<ContributionTypeDTO>>(contributionTypes);
            _logger.LogInformation("Contribution Types were retrieved successfully", nameof(contributionTypes));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
