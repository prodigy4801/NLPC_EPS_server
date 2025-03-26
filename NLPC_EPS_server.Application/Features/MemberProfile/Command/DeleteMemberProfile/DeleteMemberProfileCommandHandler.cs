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
            var memberProfileToDelete = await _memberProfileRepository.Get(request.Id);

            // 2. Verify that MemberProfileToDelete exist
            if (memberProfileToDelete is null) throw new NotFoundExceptions(nameof(memberProfileToDelete), request.Id);

            // 3. Update to deactivate user
            memberProfileToDelete.DeleteStatus = false;
            memberProfileToDelete.DateDeleted = DateTime.UtcNow;
            memberProfileToDelete.DateModified = DateTime.UtcNow;
            await _memberProfileRepository.Update(memberProfileToDelete);
            // 
            // 4. return record id
            return Unit.Value;
        }
    }
}
