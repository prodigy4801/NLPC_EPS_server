using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;

namespace NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetEmployeeProfileDetails
{
    public class GetEmployeeProfileDetailsQueryHandler : IRequestHandler<GetEmployeeProfileDetailsQuery, EmployeeProfileDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeProfileRepository _employeeProfileRepository;
        private readonly IAppLogger<GetEmployeeProfileDetailsQueryHandler> _logger;

        public GetEmployeeProfileDetailsQueryHandler(
            IMapper mapper,
            IEmployeeProfileRepository employeeProfileRepository,
            IAppLogger<GetEmployeeProfileDetailsQueryHandler> logger
        )
        {
            this._mapper = mapper;
            this._employeeProfileRepository = employeeProfileRepository;
            this._logger = logger;
        }
        public async Task<EmployeeProfileDetailsDTO> Handle(GetEmployeeProfileDetailsQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var employeeProfile = await _employeeProfileRepository.GetByIdAsync(request.Id);
            if (employeeProfile == null)
            {
                _logger.LogInformation("Get Employee Profile Details contains no information.", nameof(employeeProfile));
                throw new NotFoundExceptions(nameof(employeeProfile), "getEmployeeProfileDetails");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<EmployeeProfileDetailsDTO>(employeeProfile);
            _logger.LogInformation("Employee Profile was retrieved successfully", nameof(employeeProfile));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
