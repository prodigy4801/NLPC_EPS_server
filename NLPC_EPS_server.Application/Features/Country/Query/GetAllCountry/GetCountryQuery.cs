using MediatR;

namespace NLPC_EPS_server.Application.Features.Country.Query.GetAllCountry
{
    public record GetCountryQuery : IRequest<List<CountryDTO>>;
}
