using FluentValidation;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.MemberProfile.Command.CreateMemberProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.MemberProfile.Command.CreateMemberProfile
{
    public class CreateMemberProfileCommandValidator : AbstractValidator<CreateMemberProfileCommand>
    {
        private readonly IMemberProfileRepository _memberProfileRepository;
        private readonly IEmployeeProfileRepository _employeeProfileRepository;
        private readonly ICountryRepository _countryRepository;

        public CreateMemberProfileCommandValidator(
            IMemberProfileRepository memberProfileRepository,
            IEmployeeProfileRepository employeeProfileRepository,
            ICountryRepository countryRepository
        )
        {
            RuleFor(p => p.EmployeeProfileId)
                .MustAsync(EmployeeProfileMustExist).WithMessage("{PropertyName} does not exist");

            RuleFor(p => p.FullName)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null or empty")
                .MinimumLength(4).WithMessage("{PropertyName} below the number of allowed characters for a Full Name")
                .MaximumLength(500).WithMessage("{PropertyName} exceeded number of allowed characters");

            RuleFor(p => p.Email)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null or empty")
                .EmailAddress().WithMessage("{PropertyName} is not in a valid email format.")
                .MinimumLength(5).WithMessage("{PropertyName} is below number of allowed characters");

            RuleFor(p => p.PhoneNumber)
                .NotEmpty().WithMessage("{PropertyName} is required")
                .NotNull().WithMessage("{PropertyName} cannot be null or empty")
                .MaximumLength(12).WithMessage("{PropertyName} has exceeded number of allowed characters")
                .MinimumLength(10).WithMessage("{PropertyName} is below number of allowed characters");

            RuleFor(p => p.CountryId)
                .MustAsync(CountryMustExist).WithMessage("{PropertyName} does not exist.");

            RuleFor(p => p.DateOfBirth)
                .Must(ValidateAge).WithMessage("");

            _memberProfileRepository = memberProfileRepository;
            _employeeProfileRepository = employeeProfileRepository;
            _countryRepository = countryRepository;
        }

        private async Task<bool> MemberProfileMustExist(Guid id, CancellationToken token)
        {
            return await _memberProfileRepository.Exist(id);
        }

        private async Task<bool> EmployeeProfileMustExist(int id, CancellationToken token)
        {
            return await _employeeProfileRepository.Exist(id);
        }

        private async Task<bool> CountryMustExist(int id, CancellationToken token)
        {
            return await _countryRepository.Exist(id);
        }

        private bool ValidateAge(DateTime dateofBirth)
        {
            DateTime today = DateTime.Today;
            var age = today.Year - dateofBirth.Year;

            if (age > 17 && age < 70) return true;

            return false;
        }
    }
}
