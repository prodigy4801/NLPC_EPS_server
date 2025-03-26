using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetBenefitProcessDetails
{
    public class GetBenefitProcessQueryHandler : IRequestHandler<GetBenefitProcessDetailsQuery, BenefitProcessDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly IBenefitProcessRepository _benefitProcessRepository;
        private readonly IAppLogger<GetBenefitProcessQueryHandler> _logger;

        public GetBenefitProcessQueryHandler(
            IMapper mapper,
            IBenefitProcessRepository benefitProcessRepository,
            IAppLogger<GetBenefitProcessQueryHandler> logger
        )
        {
            this._mapper = mapper;
            this._benefitProcessRepository = benefitProcessRepository;
            this._logger = logger;
        }
        public async Task<BenefitProcessDetailsDTO> Handle(GetBenefitProcessDetailsQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var benefitProcess = await _benefitProcessRepository.Get(request.Id);
            if (benefitProcess == null)
            {
                _logger.LogInformation("Get Benefit Process Details contains no information.", nameof(benefitProcess));
                throw new NotFoundExceptions(nameof(benefitProcess), "getBenefitProcessDetails");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<BenefitProcessDetailsDTO>(benefitProcess);
            _logger.LogInformation("Benefit Process was retrieved successfully", nameof(benefitProcess));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
