using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.Country.Query.GetCountryDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.Country.Query.GetCountryDetails
{
    public class GetCountryQueryHandler : IRequestHandler<GetCountryDetailsQuery, CountryDetailsDTO>
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
        public async Task<CountryDetailsDTO> Handle(GetCountryDetailsQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var country = await _countryRepository.Get(request.Id);
            if (country == null)
            {
                _logger.LogInformation("Get Country Details contains no information.", nameof(country));
                throw new NotFoundExceptions(nameof(country), "getCountryDetails");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<CountryDetailsDTO>(country);
            _logger.LogInformation("Country was retrieved successfully", nameof(country));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
