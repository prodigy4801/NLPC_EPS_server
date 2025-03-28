using MediatR;

namespace NLPC_EPS_server.Application.Features.State.Query.GetStateDetails
{
    public record GetStateDetailsQuery(int Id) : IRequest<StateDetailsDTO>;
}
