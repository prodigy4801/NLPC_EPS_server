using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;

namespace NLPC_EPS_server.Application.Features.Country.Query.GetAllCountry
{
    public class GetCountryQueryHandler : IRequestHandler<GetCountryQuery, List<CountryDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICountryRepository _countryRepository;
        private readonly IAppLogger<GetCountryQueryHandler> _logger;

        public GetCountryQueryHandler(
            IMapper mapper,
            ICountryRepository countryRepository,
            IAppLogger<GetCountryQueryHandler> logger
        )
        {
            this._mapper = mapper;
            this._countryRepository = countryRepository;
            this._logger = logger;
        }
        public async Task<List<CountryDTO>> Handle(GetCountryQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var countries = await _countryRepository.GetAsync();
            if (countries == null || countries.Count == 0)
            {
                _logger.LogInformation("Get All Countries contains no information.", nameof(countries));
                throw new NotFoundExceptions(nameof(countries), "getAllCountries");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<List<CountryDTO>>(countries);
            _logger.LogInformation("Countries were retrieved successfully", nameof(countries));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
