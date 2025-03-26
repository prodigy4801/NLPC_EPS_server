using MediatR;

namespace NLPC_EPS_server.Application.Features.State.Query.GetAllState
{
    public record GetStateQuery : IRequest<List<StateDTO>>;
}
