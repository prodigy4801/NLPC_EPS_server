using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.MemberContribution.Command.CreateMemberContribution
{
    public class CreateMemberContributionCommand : IRequest<int>
    {
        public int Id { get; set; }
        public int MemberProfileId { get; set; }
        public int ContributionTypeId { get; set; }
        public decimal Amount { get; set; }
    }
}
