using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.MemberProfile.Command.CreateMemberProfile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Application.Features.MemberProfile.Command.CreateMemberProfile
{
    public class CreateMemberProfileCommandHandler : IRequestHandler<CreateMemberProfileCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly IMemberProfileRepository _memberProfileRepository;

        public CreateMemberProfileCommandHandler(
            IMapper mapper, 
            IMemberProfileRepository memberProfileRepository
        )
        {
            this._mapper = mapper;
            this._memberProfileRepository = memberProfileRepository;
        }
        public async Task<int> Handle(CreateMemberProfileCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate Incoming Data
            var validator = new CreateMemberProfileCommandValidator(_memberProfileRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any()) throw new BadRequestExceptions("Invalid MemberProfile", validationResult);

            // 2. Convert to domain entity type object
            var memberProfileToCreate = _mapper.Map<DAL.MemberProfile>(request);
            memberProfileToCreate.DateCreated = DateTime.UtcNow;

            // 3. Add to database
            await _memberProfileRepository.CreateAsync(memberProfileToCreate);
            // 
            // 4. return record id
            return memberProfileToCreate.Id;
        }
    }
}
