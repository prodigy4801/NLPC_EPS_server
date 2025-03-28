using FluentValidation;
using NLPC_EPS_server.Application.Contracts.Persistence;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Command.CreateBenefitRequest
{
    public class CreateBenefitRequestCommandValidator : AbstractValidator<CreateBenefitRequestCommand>
    {
        private readonly IBenefitRequestRepository _benefitRequestRepository;
        private readonly IMemberProfileRepository _memberProfileRepository;

        public CreateBenefitRequestCommandValidator(
            IBenefitRequestRepository benefitRequestRepository,
            IMemberProfileRepository memberProfileRepositor
        )
        {
            RuleFor(p => p.MemberProfileId)
                .MustAsync(MemberProfileMustExist).WithMessage("{PropertyName} is does not exist");

            RuleFor(p => p)
                .MustAsync(BenefitRequestUnique).WithMessage("Benefit has been Initiated. Cannot request for benefit.");


            this._benefitRequestRepository = benefitRequestRepository;
            _memberProfileRepository = memberProfileRepositor;
        }

        private async Task<bool> MemberProfileMustExist(int id, CancellationToken token)
        {
            return await _memberProfileRepository.Exist(id);
        }

        private async Task<bool> BenefitRequestUnique(CreateBenefitRequestCommand command, CancellationToken token)
        {
            return !await _benefitRequestRepository.Exist(command.MemberProfileId);
        }
    }
}
