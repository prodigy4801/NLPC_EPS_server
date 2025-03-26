using AutoMapper;
using NLPC_EPS_server.Application.Features.Country.Query.GetAllCountry;
using NLPC_EPS_server.Application.Features.Country.Query.GetCountryDetails;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Application.MappingProfiles
{
    public class CountryProfileMapper : Profile
    {
        public CountryProfileMapper()
        {
            CreateMap<Country, CountryDTO>();
            CreateMap<Country, CountryDetailsDTO>();
        }
    }
}
