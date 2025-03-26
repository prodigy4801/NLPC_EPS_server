using MediatR;

namespace NLPC_EPS_server.Application.Features.Company.Command.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
