using MediatR;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;

namespace NLPC_EPS_server.Application.Features.EmployeeProfile.Command.DeleteEmployeeProfile
{
    public class DeleteEmployeeProfileCommandHandler : IRequestHandler<DeleteEmployeeProfileCommand, Unit>
    {
        private readonly IEmployeeProfileRepository _employeeProfileRepository;

        public DeleteEmployeeProfileCommandHandler(IEmployeeProfileRepository employeeProfileRepository) =>
            this._employeeProfileRepository = employeeProfileRepository;

        public async Task<Unit> Handle(DeleteEmployeeProfileCommand request, CancellationToken cancellationToken)
        {
            // 1. Retireve  domain entity object
            var employeeProfileToDelete = await _employeeProfileRepository.Get(request.Id);

            // 2. Verify that EmployeeProfileToDelete exist
            if (employeeProfileToDelete is null) throw new NotFoundExceptions(nameof(EmployeeProfile), request.Id);

            // 3. Update to deactivate user
            employeeProfileToDelete.DeleteStatus = false;
            employeeProfileToDelete.DateDeleted = DateTime.UtcNow;
            employeeProfileToDelete.DateModified = DateTime.UtcNow;
            await _employeeProfileRepository.Update(employeeProfileToDelete);
            // 
            // 4. return record id
            return Unit.Value;
        }
    }
}
