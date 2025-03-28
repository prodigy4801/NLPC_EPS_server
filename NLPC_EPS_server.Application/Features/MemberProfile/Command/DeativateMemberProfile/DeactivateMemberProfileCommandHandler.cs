using MediatR;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.MemberProfile.Command.DeleteMemberProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.MemberProfile.Command.DeleteMemberProfile
{
    public class DeactivateMemberProfileCommandHandler : IRequestHandler<DeactivateMemberProfileCommand, Unit>
    {
        private readonly IMemberProfileRepository _memberProfileRepository;

        public DeactivateMemberProfileCommandHandler(IMemberProfileRepository memberProfileRepository) =>
            this._memberProfileRepository = memberProfileRepository;

        public async Task<Unit> Handle(DeactivateMemberProfileCommand request, CancellationToken cancellationToken)
        {
            // 1. Retireve  domain entity object
            var memberProfileToDeactivate = await _memberProfileRepository.DeactivateMember(request.Id);

            // 2. Verify that MemberProfileToDelete exist
            if (!memberProfileToDeactivate) throw new NotFoundExceptions(nameof(memberProfileToDeactivate), request.Id);
            
            // 3. return record id
            return Unit.Value;
        }
    }
}
