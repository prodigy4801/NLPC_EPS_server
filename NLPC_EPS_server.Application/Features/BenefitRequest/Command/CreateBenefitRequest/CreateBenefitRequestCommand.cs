using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Command.CreateBenefitRequest
{
    public class CreateBenefitRequestCommand : IRequest<Guid>
    {
        public string MemberProfileId { get; set; } = string.Empty;
        public int EmployeeProfileId { get; set; }
        public int BenefitProcessId { get; set; }
        public string RequestDescription { get; set; } = string.Empty;
        public decimal RequestedAmount { get; set; }
        public DateTime DateDispatched { get; set; }
    }
}
