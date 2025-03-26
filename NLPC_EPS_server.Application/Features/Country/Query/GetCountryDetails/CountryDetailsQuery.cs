using MediatR;

namespace NLPC_EPS_server.Application.Features.Country.Query.GetCountryDetails
{
    public record GetCountryDetailsQuery(int Id) : IRequest<CountryDetailsDTO>;
}
