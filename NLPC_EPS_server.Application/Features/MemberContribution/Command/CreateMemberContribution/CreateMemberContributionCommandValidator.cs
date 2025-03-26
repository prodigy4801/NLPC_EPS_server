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
        private readonly IMemberContributionRepository _MemberContributionRepository;
        private readonly IMemberProfileRepository _memberProfileRepository;
        private readonly IEmployeeProfileRepository _employeeProfileRepository;
        private readonly IContributionTypeRepository _contributionTypeRepository;

        public CreateMemberContributionCommandValidator(
            IMemberContributionRepository MemberContributionRepository,
            IMemberProfileRepository memberProfileRepositor,
            IEmployeeProfileRepository employeeProfileRepository,
            IContributionTypeRepository contributionTypeRepository
        )
        {
            RuleFor(p => p.MemberProfileId)
                .MustAsync(MemberProfileMustExist).WithMessage("{PropertyName} does not exist");

            RuleFor(p => p.EmployeeProfileId)
                .MustAsync(EmployeeProfileMustExist).WithMessage("{PropertyName} does not exist");

            RuleFor(p => p.ContributionTypeId)
                .MustAsync(ContributionTypeMustExist).WithMessage("{PropertyName} does not exist");

            RuleFor(p => p.Amount)
                .GreaterThan(999).WithMessage("{PropertyName} must be within a 1000 and above");


            this._MemberContributionRepository = MemberContributionRepository;
            _memberProfileRepository = memberProfileRepositor;
            _employeeProfileRepository = employeeProfileRepository;
            _contributionTypeRepository = contributionTypeRepository;
        }

        private async Task<bool> MemberProfileMustExist(Guid id, CancellationToken token)
        {
            return await _memberProfileRepository.Exist(id);
        }

        private async Task<bool> EmployeeProfileMustExist(int id, CancellationToken token)
        {
            return await _employeeProfileRepository.Exist(id);
        }

        private async Task<bool> ContributionTypeMustExist(int id, CancellationToken token)
        {
            return await _contributionTypeRepository.Exist(id);
        }
    }
}
