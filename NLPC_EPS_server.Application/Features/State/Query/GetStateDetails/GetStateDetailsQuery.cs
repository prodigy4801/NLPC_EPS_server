using MediatR;
using NLPC_EPS_server.Application.Features.State.Query.GetStateDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.State.Query.GetStateDetails
{
    public record GetStateDetailsQuery(int Id) : IRequest<StateDetailsDTO>;
}
