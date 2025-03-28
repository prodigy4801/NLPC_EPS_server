using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.State.Query.GetStateDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.State.Query.GetStateDetails
{
    public class GetStateQueryHandler : IRequestHandler<GetStateDetailsQuery, StateDetailsDTO>
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
        public async Task<StateDetailsDTO> Handle(GetStateDetailsQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var state = await _stateRepository.GetByIDAsync(request.Id);
            if (state == null)
            {
                _logger.LogInformation("Get State Details contains no information.", nameof(DAL.State));
                throw new NotFoundExceptions(nameof(DAL.State), "getStateDetails");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<StateDetailsDTO>(state);
            _logger.LogInformation("State was retrieved successfully", nameof(DAL.State));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
