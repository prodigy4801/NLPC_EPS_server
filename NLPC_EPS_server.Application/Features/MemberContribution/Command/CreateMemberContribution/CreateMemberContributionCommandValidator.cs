using FluentValidation;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.MemberContribution.Command.CreateMemberContribution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.MemberContribution.Command.CreateMemberContribution
{
    public class CreateMemberContributionCommandValidator : AbstractValidator<CreateMemberContributionCommand>
    {
        private readonly IMemberContributionRepository _memberContributionRepository;
        private readonly IMemberProfileRepository _memberProfileRepository;
        private readonly IContributionTypeRepository _contributionTypeRepository;

        public CreateMemberContributionCommandValidator(
            IMemberContributionRepository memberContributionRepository,
            IMemberProfileRepository memberProfileRepositor,
            IContributionTypeRepository contributionTypeRepository
        )
        {
            RuleFor(p => p.MemberProfileId)
                .MustAsync(MemberProfileMustExist).WithMessage("{PropertyName} does not exist");

            RuleFor(p => p.ContributionTypeId)
                .MustAsync(ContributionTypeMustExist).WithMessage("{PropertyName} does not exist");

            RuleFor(p => p.Amount)
                .GreaterThan(999).WithMessage("{PropertyName} must be within a 1000 and above");

            this._memberContributionRepository = memberContributionRepository;
            _memberProfileRepository = memberProfileRepositor;
            _contributionTypeRepository = contributionTypeRepository;
        }

        private async Task<bool> VerifyPreviousContribution(CreateMemberContributionCommand command)
        {
            if (command.ContributionTypeId == 2) return true;

            return !await _memberContributionRepository.IsContributionExistByMonth(DateTime.Now.Month, command.MemberProfileId);
        }

        private async Task<bool> MemberProfileMustExist(int id, CancellationToken token)
        {
            return await _memberProfileRepository.Exist(id);
        }

        private async Task<bool> ContributionTypeMustExist(int id, CancellationToken token)
        {
            return await _contributionTypeRepository.Exist(id);
        }
    }
}
