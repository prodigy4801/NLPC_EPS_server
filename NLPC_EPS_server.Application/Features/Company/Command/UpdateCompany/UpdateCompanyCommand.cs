using MediatR;

namespace NLPC_EPS_server.Application.Features.Company.Command.UpdateCompany
{
    public class UpdateCompanyCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int? CountryId { get; set; }
        public Guid? StateId { get; set; }
    }
}
