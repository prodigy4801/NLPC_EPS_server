using FluentValidation;

namespace NLPC_EPS_server.Application.Features.MemberContribution.Command.UpdateMemberContribution
{
    public class UpdateMemberContributionCommandValidator : AbstractValidator<UpdateMemberContributionCommand>
    {
        public UpdateMemberContributionCommandValidator()
        {
            RuleFor(p => p.Amount)
                .GreaterThan(999).WithMessage("{PropertyName} must be within a 1000 and above");
        }
    }
}
