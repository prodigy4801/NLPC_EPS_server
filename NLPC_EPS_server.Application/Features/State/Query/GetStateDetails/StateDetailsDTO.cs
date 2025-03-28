using NLPC_EPS_server.Application.Features.Country.Query.GetAllCountry;

namespace NLPC_EPS_server.Application.Features.State.Query.GetStateDetails
{
    public class StateDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public CountryDTO Country { get; set; }
    }
}
