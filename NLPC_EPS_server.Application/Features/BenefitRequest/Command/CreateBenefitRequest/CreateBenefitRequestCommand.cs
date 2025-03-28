using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.BenefitRequest.Command.CreateBenefitRequest
{
    public class CreateBenefitRequestCommand : IRequest<int>
    {
        public int MemberProfileId { get; set; }
        public string RequestDescription { get; set; } = string.Empty;
        public decimal RequestedAmount { get; set; }
        public DateTime DateDispatched { get; set; }
    }
}
