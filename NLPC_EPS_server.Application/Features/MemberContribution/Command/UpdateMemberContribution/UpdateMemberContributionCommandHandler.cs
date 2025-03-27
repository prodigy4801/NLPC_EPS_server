using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.MemberContribution.Command.UpdateMemberContribution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.MemberContribution.Command.UpdateMemberContribution
{
    public class UpdateMemberContributionCommandHandler : IRequestHandler<UpdateMemberContributionCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IMemberContributionRepository _memberContributionRepository;
        private readonly IAppLogger<UpdateMemberContributionCommandHandler> _logger;

        public UpdateMemberContributionCommandHandler(
            IMapper mapper,
            IMemberContributionRepository memberContributionRepository,
            IAppLogger<UpdateMemberContributionCommandHandler> logger
        )
        {
            this._mapper = mapper;
            this._memberContributionRepository = memberContributionRepository;
            this._logger = logger;
        }
        public async Task<Unit> Handle(UpdateMemberContributionCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate Incoming Data
            var validator = new UpdateMemberContributionCommandValidator();
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Vaidation Error(s) in update request for {0} - {1}", nameof(MemberContribution), request.Id);
                throw new BadRequestExceptions("Invalid Benefit Request", validationResult);
            }

            // 2. Convert to domain entity type object
            var MemberContributionToUpdate = _mapper.Map<DAL.MemberContribution>(request);

            // 3. Add to database
            await _memberContributionRepository.UpdateAsync(MemberContributionToUpdate);
            // 
            // 4. return record id
            return Unit.Value;
        }
    }
}
