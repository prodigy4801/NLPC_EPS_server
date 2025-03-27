using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetBenefitRequestDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetBenefitRequestDetails
{
    public class GetBenefitRequestDetailsQueryHandler : IRequestHandler<GetBenefitRequestDetailsQuery, BenefitRequestDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly IBenefitRequestRepository _benefitRequestRepository;
        private readonly IAppLogger<GetBenefitRequestDetailsQueryHandler> _logger;

        public GetBenefitRequestDetailsQueryHandler(
            IMapper mapper,
            IBenefitRequestRepository benefitRequestRepository,
            IAppLogger<GetBenefitRequestDetailsQueryHandler> logger
        )
        {
            this._mapper = mapper;
            this._benefitRequestRepository = benefitRequestRepository;
            this._logger = logger;
        }
        public async Task<BenefitRequestDetailsDTO> Handle(GetBenefitRequestDetailsQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var benefitRequest = await _benefitRequestRepository.GetByIdAsync(request.Id);
            if (benefitRequest == null)
            {
                _logger.LogInformation("Get Employee Profile Details contains no information.", nameof(benefitRequest));
                throw new NotFoundExceptions(nameof(benefitRequest), "getBenefitRequestDetails");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<BenefitRequestDetailsDTO>(benefitRequest);
            _logger.LogInformation("Benefit Request was retrieved successfully", nameof(benefitRequest));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
