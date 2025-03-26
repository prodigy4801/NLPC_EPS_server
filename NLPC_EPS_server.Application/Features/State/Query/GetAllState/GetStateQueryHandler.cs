using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;

namespace NLPC_EPS_server.Application.Features.State.Query.GetAllState
{
    public class GetStateQueryHandler : IRequestHandler<GetStateQuery, List<StateDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IStateRepository _stateRepository;
        private readonly IAppLogger<GetStateQueryHandler> _logger;

        public GetStateQueryHandler(
            IMapper mapper,
            IStateRepository stateRepository,
            IAppLogger<GetStateQueryHandler> logger
        )
        {
            this._mapper = mapper;
            this._stateRepository = stateRepository;
            this._logger = logger;
        }
        public async Task<List<StateDTO>> Handle(GetStateQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var states = await _stateRepository.GetAll();
            if (states == null || states.Count == 0)
            {
                _logger.LogInformation("Get All States contains no information.", nameof(states));
                throw new NotFoundExceptions(nameof(states), "getAlStatees");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<List<StateDTO>>(states);
            _logger.LogInformation("Benefit Processes were retrieved successfully", nameof(states));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
