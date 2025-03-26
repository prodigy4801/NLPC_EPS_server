using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.MemberContribution.Command.CreateMemberContribution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.MemberContribution.Command.CreateMemberContribution
{
    public class CreateMemberContributionCommandHandler : IRequestHandler<CreateMemberContributionCommand, Guid>
    {
        private readonly IMapper _mapper;
        private readonly IMemberContributionRepository _memberContributionRepository;
        private readonly IMemberProfileRepository _memberProfileRepository;
        private readonly IEmployeeProfileRepository _employeeProfileRepository;

        public CreateMemberContributionCommandHandler(
            IMapper mapper,
            IMemberContributionRepository memberContributionRepository,
            IMemberProfileRepository memberProfileRepositor,
            IEmployeeProfileRepository employeeProfileRepository
        )
        {
            this._mapper = mapper;
            this._memberContributionRepository = memberContributionRepository;
            this._memberProfileRepository = memberProfileRepositor;
            this._employeeProfileRepository = employeeProfileRepository;
        }
        public async Task<Guid> Handle(CreateMemberContributionCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate Incoming Data
            var validator = new CreateMemberContributionCommandValidator(_memberContributionRepository, _memberProfileRepository, _employeeProfileRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any()) throw new BadRequestExceptions("Invalid Member Contribution", validationResult);

            // 2. Convert to domain entity type object
            var memberContributionToCreate = _mapper.Map<DAL.MemberContribution>(request);

            // 3. Add to database
            await _memberContributionRepository.Insert(memberContributionToCreate);
            // 
            // 4. return record id
            return MemberContributionToCreate.Id;
        }
    }
}
