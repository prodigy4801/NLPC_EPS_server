using MediatR;

namespace NLPC_EPS_server.Application.Features.Company.Command.CreateCompany
{
    public class CreateCompanyCommand : IRequest<int>
    {
        public string Name { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public int? CountryId { get; set; }
        public long? StateId { get; set; }
    }
}
