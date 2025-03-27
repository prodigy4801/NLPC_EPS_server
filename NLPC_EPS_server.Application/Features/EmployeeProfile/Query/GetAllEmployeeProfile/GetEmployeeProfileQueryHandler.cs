using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetAllEmployeeProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetAllEmployeeProfile
{
    public class GetEmployeeProfileQueryHandler : IRequestHandler<GetEmployeeProfileQuery, List<EmployeeProfileDTO>>
    {
        private readonly IMapper _mapper;
        private readonly IEmployeeProfileRepository _employeeProfileRepository;
        private readonly IAppLogger<GetEmployeeProfileQueryHandler> _logger;

        public GetEmployeeProfileQueryHandler(
            IMapper mapper,
            IEmployeeProfileRepository employeeProfileRepository,
            IAppLogger<GetEmployeeProfileQueryHandler> logger
        )
        {
            this._mapper = mapper;
            this._employeeProfileRepository = employeeProfileRepository;
            this._logger = logger;
        }
        public async Task<List<EmployeeProfileDTO>> Handle(GetEmployeeProfileQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var employees = await _employeeProfileRepository.GetAsync();
            if (employees == null || employees.Count == 0)
            {
                _logger.LogInformation("Get All Employee Profile contains no information.", nameof(employees));
                throw new NotFoundExceptions(nameof(employees), "getAllEmployeeProfile");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<List<EmployeeProfileDTO>>(employees);
            _logger.LogInformation("Employees were retrieved successfully", nameof(employees));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
