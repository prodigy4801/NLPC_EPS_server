using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.MemberProfile.Command.DeleteMemberProfile
{
    public class DeleteMemberProfileCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
