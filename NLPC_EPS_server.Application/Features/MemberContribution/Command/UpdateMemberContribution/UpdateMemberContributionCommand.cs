using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.MemberContribution.Command.UpdateMemberContribution
{
    public class UpdateMemberContributionCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime ContributionDate { get; set; }
    }
}
