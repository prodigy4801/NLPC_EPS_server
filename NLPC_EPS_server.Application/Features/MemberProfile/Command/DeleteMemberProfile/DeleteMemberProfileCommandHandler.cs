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
    public class DeleteMemberProfileCommandHandler : IRequestHandler<DeleteMemberProfileCommand, Unit>
    {
        private readonly IMemberProfileRepository _memberProfileRepository;

        public DeleteMemberProfileCommandHandler(IMemberProfileRepository memberProfileRepository) =>
            this._memberProfileRepository = memberProfileRepository;

        public async Task<Unit> Handle(DeleteMemberProfileCommand request, CancellationToken cancellationToken)
        {
            // 1. Retireve  domain entity object
            var memberProfileToDeactivate = await _memberProfileRepository.GetByIdAsync(request.Id);

            // 2. Verify that MemberProfileToDelete exist
            if (memberProfileToDeactivate is null) throw new NotFoundExceptions(nameof(memberProfileToDeactivate), request.Id);

            // 3. Update to deactivate user
            memberProfileToDeactivate.DeleteStatus = false;
            memberProfileToDeactivate.DateDeleted = DateTime.UtcNow;
            memberProfileToDeactivate.DateModified = DateTime.UtcNow;
            await _memberProfileRepository.UpdateAsync(memberProfileToDeactivate);
            // 
            // 4. return record id
            return Unit.Value;
        }
    }
}
