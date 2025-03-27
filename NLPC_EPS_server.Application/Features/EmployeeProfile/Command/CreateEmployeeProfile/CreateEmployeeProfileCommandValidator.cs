using FluentValidation;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Command.CreateEmployeeProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.EmployeeProfile.Command.CreateEmployeeProfile
{
    internal class CreateEmployeeProfileCommandValidator : AbstractValidator<CreateEmployeeProfileCommand>
    {
        private readonly IEmployeeProfileRepository _employeeProfileRepository;
        private readonly ICompanyRepository _companyRepository;

        public CreateEmployeeProfileCommandValidator(IEmployeeProfileRepository employeeProfileRepository, ICompanyRepository companyRepository)
        {
            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null or empty")
                .MinimumLength(4).WithMessage("{PropertyName} below the number of allowed characters for a Full Name")
                .MaximumLength(500).WithMessage("{PropertyName} exceeded number of allowed characters");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null or empty")
                .EmailAddress().WithMessage("{PropertyName} is unrecognised.")
                .MinimumLength(5).WithMessage("{PropertyName} is below number of allowed characters");

            RuleFor(p => p.CompanyId)
                .NotEmpty().WithMessage("{PropertyName} is required.")
                .NotNull().WithMessage("{PropertyName} cannot be null or empty.")
                .MustAsync(CompanyMustExist).WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p)
                .MustAsync(EmployeeProfileNameUnique).WithMessage("EmployeeProfile Email already exist");


            this._employeeProfileRepository = employeeProfileRepository;
            this._companyRepository = companyRepository;
        }

        private async Task<bool> EmployeeProfileNameUnique(CreateEmployeeProfileCommand command, CancellationToken token)
        {
            return !await _employeeProfileRepository.ExistByEmail(command.Email);
        }
        private async Task<bool> CompanyMustExist(int id, CancellationToken token)
        {
            return await _companyRepository.Exist(id);
        }
    }
}
