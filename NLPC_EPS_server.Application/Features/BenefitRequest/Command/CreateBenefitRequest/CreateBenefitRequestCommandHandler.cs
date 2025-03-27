using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.BenefitRequest.Command.CreateBenefitRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Command.CreateBenefitRequest
{
    public class CreateBenefitRequestCommandHandler : IRequestHandler<CreateBenefitRequestCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IBenefitRequestRepository _benefitRequestRepository;
        private readonly IMemberProfileRepository _memberProfileRepository;
        private readonly IEmployeeProfileRepository _employeeProfileRepository;

        public CreateBenefitRequestCommandHandler(
            IMapper mapper, 
            IBenefitRequestRepository benefitRequestRepository,
            IMemberProfileRepository memberProfileRepositor,
            IEmployeeProfileRepository employeeProfileRepository
        )
        {
            this._mapper = mapper;
            this._benefitRequestRepository = benefitRequestRepository;
            this._memberProfileRepository = memberProfileRepositor;
            this._employeeProfileRepository = employeeProfileRepository;
        }
        public async Task<int> Handle(CreateBenefitRequestCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate Incoming Data
            var validator = new CreateBenefitRequestCommandValidator(_benefitRequestRepository, _memberProfileRepository, _employeeProfileRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any()) throw new BadRequestExceptions("Invalid BenefitRequest", validationResult);

            // 2. Convert to domain entity type object
            var benefitRequestToCreate = _mapper.Map<DAL.BenefitRequest>(request);
            benefitRequestToCreate.BenefitProcessId = 1;

            // 3. Add to database
            await _benefitRequestRepository.CreateAsync(benefitRequestToCreate);
            // 
            // 4. return record id
            return benefitRequestToCreate.Id;
        }
    }
}
