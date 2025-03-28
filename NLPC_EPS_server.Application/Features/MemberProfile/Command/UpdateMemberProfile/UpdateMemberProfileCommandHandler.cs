using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.MemberProfile.Command.UpdateMemberProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.MemberProfile.Command.UpdateMemberProfile
{
    public class UpdateMemberProfileCommandHandler : IRequestHandler<UpdateMemberProfileCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IMemberProfileRepository _memberProfileRepository;
        private readonly IEmployeeProfileRepository _employeeProfileRepository;
        private readonly IAppLogger<UpdateMemberProfileCommandHandler> _logger;

        public UpdateMemberProfileCommandHandler(
            IMapper mapper,
            IMemberProfileRepository memberProfileRepository,
            IAppLogger<UpdateMemberProfileCommandHandler> logger,
            IEmployeeProfileRepository employeeProfileRepository
        )
        {
            this._mapper = mapper;
            this._logger = logger;
            _memberProfileRepository = memberProfileRepository;
            _employeeProfileRepository = employeeProfileRepository;
        }
        public async Task<Unit> Handle(UpdateMemberProfileCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate Incoming Data
            var validator = new UpdateMemberProfileCommandValidator(
                _memberProfileRepository, 
                _employeeProfileRepository
            );
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Vaidation Error(s) in update request for {0} - {1}", nameof(MemberProfile), request.Email);
                throw new BadRequestExceptions("Invalid MemberProfile", validationResult);
            }

            // 2. Convert to domain entity type object
            var memberProfileToUpdate = _mapper.Map<DAL.MemberProfile>(request);
            memberProfileToUpdate.DeleteStatus = false;
            memberProfileToUpdate.DateModified = DateTime.UtcNow;

            // 3. Add to database
            await _memberProfileRepository.UpdateAsync(memberProfileToUpdate);
            // 
            // 4. return record id
            return Unit.Value;
        }
    }
}
