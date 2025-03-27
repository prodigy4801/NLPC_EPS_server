using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Command.CreateEmployeeProfile;

namespace NLPC_EPS_server.Application.Features.EmployeeProfile.Command.CreateEmployeeProfile
{
    public class CreateEmployeeProfileCommandHandler : IRequestHandler<CreateEmployeeProfileCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeProfileRepository _employeeProfileRepository;
        private readonly ICompanyRepository _companyRepository;

        public CreateEmployeeProfileCommandHandler(IMapper mapper, IEmployeeProfileRepository employeeProfileRepository, ICompanyRepository companyRepository)
        {
            this._mapper = mapper;
            this._employeeProfileRepository = employeeProfileRepository;
            this._companyRepository = companyRepository;
        }
        public async Task<int> Handle(CreateEmployeeProfileCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate Incoming Data
            var validator = new CreateEmployeeProfileCommandValidator(this._employeeProfileRepository, this._companyRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any()) throw new BadRequestExceptions("Invalid EmployeeProfile", validationResult);

            // 2. Convert to domain entity type object
            var employeeProfileToCreate = _mapper.Map<DAL.EmployeeProfile>(request);

            // 3. Add to database
            await _employeeProfileRepository.CreateAsync(employeeProfileToCreate);
            // 
            // 4. return record id
            return employeeProfileToCreate.Id;
        }
    }
}
