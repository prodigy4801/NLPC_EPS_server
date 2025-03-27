using FluentValidation;
using NLPC_EPS_server.Application.Contracts.Persistence;

namespace NLPC_EPS_server.Application.Features.Company.Command.CreateCompany
{
    public class CreateCompanyCommandValidator : AbstractValidator<CreateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyCommandValidator(ICompanyRepository companyRepository)
        {
            RuleFor(p => p.Name)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null or empty");

            RuleFor(p => p.Address)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null or empty");

            RuleFor(p => p)
                .MustAsync(CompanyNameUnique).WithMessage("Company already exist");


            this._companyRepository = companyRepository;
        }

        private async Task<bool> CompanyNameUnique(CreateCompanyCommand command, CancellationToken token)
        {
            return !await _companyRepository.ExistByName(command.Name);
        }
    }
}
