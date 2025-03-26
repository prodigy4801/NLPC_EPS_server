using MediatR;

namespace NLPC_EPS_server.Application.Features.Company.Command.DeleteCompany
{
    public class UpdateCompanyCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
