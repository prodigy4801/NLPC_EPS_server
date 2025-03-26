using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;

namespace NLPC_EPS_server.Application.Features.Company.Command.UpdateCompany
{
    public class UpdateCompanyCommandHandler : IRequestHandler<UpdateCompanyCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly IAppLogger<UpdateCompanyCommandHandler> _logger;

        public UpdateCompanyCommandHandler(
            IMapper mapper,
            ICompanyRepository companyRepository,
            IAppLogger<UpdateCompanyCommandHandler> logger
        )
        {
            this._mapper = mapper;
            this._companyRepository = companyRepository;
            this._logger = logger;
        }
        public async Task<Unit> Handle(UpdateCompanyCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate Incoming Data
            var validator = new UpdateCompanyCommandValidator(_companyRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any())
            {
                _logger.LogWarning("Vaidation Error(s) in update request for {0} - {1}", nameof(Company), request.Id);
                throw new BadRequestExceptions("Invalid Company", validationResult);
            }

            // 2. Convert to domain entity type object
            var CompanyToUpdate = _mapper.Map<DAL.Company>(request);

            // 3. Add to database
            await _companyRepository.Update(CompanyToUpdate);
            // 
            // 4. return record id
            return Unit.Value;
        }
    }
}
