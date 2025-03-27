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

namespace NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetAllBenefitProcess
{
    public class GetBenefitProcessQueryHandler : IRequestHandler<GetBenefitProcessQuery, List<BenefitProcessDTO>>
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
        public async Task<List<BenefitProcessDTO>> Handle(GetBenefitProcessQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var benefitProcesses = await _benefitProcessRepository.GetAsync();
            if (benefitProcesses == null || benefitProcesses.Count == 0)
            {
                _logger.LogInformation("Get All Benefit Processes contains no information.", nameof(benefitProcesses));
                throw new NotFoundExceptions(nameof(benefitProcesses), "getAlBenefitProcesses");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<List<BenefitProcessDTO>>(benefitProcesses);
            _logger.LogInformation("Benefit Processes were retrieved successfully", nameof(benefitProcesses));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
