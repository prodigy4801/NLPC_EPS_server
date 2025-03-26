using NLPC_EPS_server.Application.Features.Country.Query.GetAllCountry;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.State.Query.GetStateDetails
{
    public class StateDetailsDTO
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public CountryDTO Country { get; set; }
    }
}
