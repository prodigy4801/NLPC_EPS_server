using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Command.UpdateEmployeeProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.EmployeeProfile.Command.UpdateEmployeeProfile
{
    public class UpdateEmployeeProfileCommandHandler : IRequestHandler<UpdateEmployeeProfileCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeProfileRepository _employeeProfileRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IAppLogger<UpdateEmployeeProfileCommandHandler> _logger;

        public UpdateEmployeeProfileCommandHandler(
            IMapper mapper,
            IEmployeeProfileRepository employeeProfileRepository,
            IAppLogger<UpdateEmployeeProfileCommandHandler> logger,
            ICompanyRepository companyRepository
        )
        {
            this._mapper = mapper;
            this._employeeProfileRepository = employeeProfileRepository;
            this._logger = logger;
            this._companyRepository = companyRepository;
        }
        public async Task<Unit> Handle(UpdateEmployeeProfileCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate Incoming Data
            var validator = new UpdateEmployeeProfileCommandValidator(_employeeProfileRepository, this._companyRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Vaidation Error(s) in update request for {0} - {1}", nameof(EmployeeProfile), request.Email);
                throw new BadRequestExceptions("Invalid EmployeeProfile", validationResult);
            }

            // 2. Convert to domain entity type object
            var employeeProfileToUpdate = _mapper.Map<DAL.EmployeeProfile>(request);
            employeeProfileToUpdate.DeleteStatus = false;
            employeeProfileToUpdate.DateModified = DateTime.UtcNow;

            // 3. Add to database
            await _employeeProfileRepository.UpdateAsync(employeeProfileToUpdate);
            // 
            // 4. return record id
            return Unit.Value;
        }
    }
}
