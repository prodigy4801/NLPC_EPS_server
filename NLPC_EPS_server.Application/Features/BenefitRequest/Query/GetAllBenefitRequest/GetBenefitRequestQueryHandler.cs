using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetAllBenefitRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetAllBenefitRequest
{
    public class GetBenefitRequestQueryHandler : IRequestHandler<GetBenefitRequestQuery, List<BenefitRequestDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IBenefitRequestRepository _benefitRequestRepository;
        private readonly IAppLogger<GetBenefitRequestQueryHandler> _logger;

        public GetBenefitRequestQueryHandler(
            IMapper mapper,
            IBenefitRequestRepository benefitRequestRepository,
            IAppLogger<GetBenefitRequestQueryHandler> logger
        )
        {
            this._mapper = mapper;
            this._benefitRequestRepository = benefitRequestRepository;
            this._logger = logger;
        }
        public async Task<List<BenefitRequestDTO>> Handle(GetBenefitRequestQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var benefitRequest = await _benefitRequestRepository.GetAll();
            if (benefitRequest == null || benefitRequest.Count == 0)
            {
                _logger.LogInformation("Get All Benefit Request contains no information.", nameof(benefitRequest));
                throw new NotFoundExceptions(nameof(benefitRequest), "getAllBenefitRequest");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<List<BenefitRequestDTO>>(benefitRequest);
            _logger.LogInformation("Benefit Requests were retrieved successfully", nameof(benefitRequest));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
