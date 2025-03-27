using MediatR;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;

namespace NLPC_EPS_server.Application.Features.Company.Command.DeleteCompany
{
    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Unit>
    {
        private readonly ICompanyRepository _companyRepository;

        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository) =>
            this._companyRepository = companyRepository;

        public async Task<Unit> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            // 1. Retireve  domain entity object
            var companyToDelete = await _companyRepository.GetByIdAsync(request.Id);

            // 2. Verify that CompanyToDelete exist
            if (companyToDelete is null) throw new NotFoundExceptions(nameof(Company), request.Id);

            // 3. Update to deactivate user
            companyToDelete.DeleteStatus = false;
            companyToDelete.DateDeleted = DateTime.UtcNow;
            companyToDelete.DateModified = DateTime.UtcNow;
            await _companyRepository.UpdateAsync(companyToDelete);
            // 
            // 4. return record id
            return Unit.Value;
        }
    }
}
