using MediatR;

namespace NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetAllBenefitProcess
{
    public record GetBenefitProcessQuery : IRequest<List<BenefitProcessDTO>>;
}
