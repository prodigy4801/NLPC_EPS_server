using MediatR;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Command.UpdateBenefitRequest
{
    public class UpdateBenefitRequestCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public int BenefitProcessId { get; set; }
        public string RequestDescription { get; set; } = string.Empty;
        public decimal? DispatchedAmount { get; set; }
        public string? EmployeeComment { get; set; }
        public DateTime? DateDispatched { get; set; }
    }
}
