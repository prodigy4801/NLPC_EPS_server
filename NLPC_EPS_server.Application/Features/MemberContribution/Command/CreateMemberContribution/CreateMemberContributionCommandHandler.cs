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
    public class CreateMemberContributionCommandHandler : IRequestHandler<CreateMemberContributionCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IMemberContributionRepository _memberContributionRepository;
        private readonly IMemberProfileRepository _memberProfileRepository;
        private readonly IContributionTypeRepository _contributionTypeRepository;

        public CreateMemberContributionCommandHandler(
            IMapper mapper,
            IMemberContributionRepository memberContributionRepository,
            IMemberProfileRepository memberProfileRepositor,
            IContributionTypeRepository contributionTypeRepository
        )
        {
            this._mapper = mapper;
            this._memberContributionRepository = memberContributionRepository;
            this._memberProfileRepository = memberProfileRepositor;
            this._contributionTypeRepository = contributionTypeRepository;
        }
        public async Task<int> Handle(CreateMemberContributionCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate Incoming Data
            var validator = new CreateMemberContributionCommandValidator(_memberContributionRepository, _memberProfileRepository, _contributionTypeRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any()) throw new BadRequestExceptions("Invalid Member Contribution", validationResult);

            //1. Validate if contribution is Monthly and if it has previously been paid
            if(request.ContributionTypeId == 1)
            {
                if(await _memberContributionRepository.IsContributionExistByMonth(DateTime.Now.Month, request.MemberProfileId))
                    throw new BadRequestExceptions("Contribution has previously been made by this member for this current month.");
            }

            // 2. Convert to domain entity type object
            var memberContributionToCreate = _mapper.Map<DAL.MemberContribution>(request);
            memberContributionToCreate.DateCreated = DateTime.UtcNow;

            // 3. Add to database
            await _memberContributionRepository.CreateAsync(memberContributionToCreate);
            // 
            // 4. return record id
            return memberContributionToCreate.Id;
        }
    }
}
