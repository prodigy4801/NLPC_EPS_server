using MediatR;

namespace NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetBenefitProcessDetails
{
    public record GetBenefitProcessDetailsQuery(int Id) : IRequest<BenefitProcessDetailsDTO>;
}
