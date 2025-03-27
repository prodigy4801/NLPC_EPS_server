using FluentValidation;
using NLPC_EPS_server.Application.Contracts.Persistence;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Command.UpdateBenefitRequest
{
    public class UpdateBenefitRequestCommandValidator : AbstractValidator<UpdateBenefitRequestCommand>
    {
        private readonly IBenefitRequestRepository _benefitRequestRepository;

        public UpdateBenefitRequestCommandValidator(IBenefitRequestRepository benefitRequestRepository)
        {
            RuleFor(p => p.EmployeeComment)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null or empty");

            RuleFor(p => p.Id)
                .MustAsync(BenefitRequestMustExist).WithMessage("{PropertyName} does not exist.");

            this._benefitRequestRepository = benefitRequestRepository;
        }
        private async Task<bool> BenefitRequestMustExist(int id, CancellationToken token)
        {
            return await _benefitRequestRepository.Exist(id);
        }
    }
}
