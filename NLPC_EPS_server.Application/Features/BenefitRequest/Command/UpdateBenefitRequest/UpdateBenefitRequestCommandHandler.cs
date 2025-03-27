using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.BenefitRequest.Command.UpdateBenefitRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Command.UpdateBenefitRequest
{
    public class UpdateBenefitRequestCommandHandler : IRequestHandler<UpdateBenefitRequestCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IBenefitRequestRepository _benefitRequestRepository;
        private readonly IAppLogger<UpdateBenefitRequestCommandHandler> _logger;

        public UpdateBenefitRequestCommandHandler(
            IMapper mapper,
            IBenefitRequestRepository benefitRequestRepository,
            IAppLogger<UpdateBenefitRequestCommandHandler> logger
        )
        {
            this._mapper = mapper;
            this._benefitRequestRepository = benefitRequestRepository;
            this._logger = logger;
        }
        public async Task<Unit> Handle(UpdateBenefitRequestCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate Incoming Data
            var validator = new UpdateBenefitRequestCommandValidator(_benefitRequestRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Vaidation Error(s) in update request for {0} - {1}", nameof(BenefitRequest), request.Id);
                throw new BadRequestExceptions("Invalid Benefit Request", validationResult);
            }

            // 2. Convert to domain entity type object
            var benefitRequestToUpdate = _mapper.Map<DAL.BenefitRequest>(request);

            // 3. Add to database
            await _benefitRequestRepository.UpdateAsync(benefitRequestToUpdate);
            // 
            // 4. return record id
            return Unit.Value;
        }
    }
}
