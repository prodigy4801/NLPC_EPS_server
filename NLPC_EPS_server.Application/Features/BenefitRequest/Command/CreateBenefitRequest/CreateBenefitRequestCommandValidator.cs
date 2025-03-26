using FluentValidation;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.BenefitRequest.Command.CreateBenefitRequest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Command.CreateBenefitRequest
{
    public class CreateBenefitRequestCommandValidator : AbstractValidator<CreateBenefitRequestCommand>
    {
        private readonly IBenefitRequestRepository _benefitRequestRepository;
        private readonly IMemberProfileRepository _memberProfileRepository;
        private readonly IEmployeeProfileRepository _employeeProfileRepository;

        public CreateBenefitRequestCommandValidator(
            IBenefitRequestRepository benefitRequestRepository,
            IMemberProfileRepository memberProfileRepositor,
            IEmployeeProfileRepository employeeProfileRepository
        )
        {
            RuleFor(p => p.MemberProfileId)
                .MustAsync(MemberProfileMustExist).WithMessage("{PropertyName} is does not exist");

            RuleFor(p => p.EmployeeProfileId)
                .MustAsync(EmployeeProfileMustExist).WithMessage("{PropertyName} is does not exist"); ;

            RuleFor(p => p)
                .MustAsync(BenefitRequestUnique).WithMessage("Benefit has been Initiated. Cannot request for benefit.");


            this._benefitRequestRepository = benefitRequestRepository;
            _memberProfileRepository = memberProfileRepositor;
            _employeeProfileRepository = employeeProfileRepository;
        }

        private async Task<bool> MemberProfileMustExist(string id, CancellationToken token)
        {
            return await _memberProfileRepository.Exist(id);
        }

        private async Task<bool> EmployeeProfileMustExist(int id, CancellationToken token)
        {
            return await _employeeProfileRepository.Exist(id);
        }

        private async Task<bool> BenefitRequestUnique(CreateBenefitRequestCommand command, CancellationToken token)
        {
            return !await _benefitRequestRepository.Exist(command.MemberProfileId);
        }
    }
}
