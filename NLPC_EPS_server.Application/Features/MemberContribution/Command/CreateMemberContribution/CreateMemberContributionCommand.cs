using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.MemberContribution.Command.CreateMemberContribution
{
    public class CreateMemberContributionCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public Guid MemberProfileId { get; set; }
        public int EmployeeProfileId { get; set; }
        public int ContributionTypeId { get; set; }
        public decimal Amount { get; set; }
    }
}
