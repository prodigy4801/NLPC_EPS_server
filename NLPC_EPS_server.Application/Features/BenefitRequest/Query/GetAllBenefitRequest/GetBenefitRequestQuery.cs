using MediatR;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetAllBenefitRequest
{
    public record GetBenefitRequestQuery : IRequest<List<BenefitRequestDTO>>;
}
