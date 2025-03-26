using FluentValidation;
using NLPC_EPS_server.Application.Contracts.Persistence;

namespace NLPC_EPS_server.Application.Features.Company.Command.UpdateCompany
{
    public class UpdateCompanyCommandValidator : AbstractValidator<UpdateCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;

        public UpdateCompanyCommandValidator(ICompanyRepository companyRepository)
        {
            RuleFor(p => p.Id)
                .GreaterThan(0).WithMessage("{PropertyName} must be greater than 0.")
                .MustAsync(CompanyMustExist).WithMessage("{PropertyName} does not exist.");

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

        private async Task<bool> CompanyMustExist(int id, CancellationToken token)
        {
            return await _companyRepository.Exist(id);
        }

        private async Task<bool> CompanyNameUnique(UpdateCompanyCommand command, CancellationToken token)
        {
            return !await _companyRepository.Exist(command.Name);
        }
    }
}
