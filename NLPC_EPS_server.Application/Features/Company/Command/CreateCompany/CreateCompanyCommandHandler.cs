using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;

namespace NLPC_EPS_server.Application.Features.Company.Command.CreateCompany
{
    public class CreateCompanyCommandHandler : IRequestHandler<CreateCompanyCommand, int>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;

        public CreateCompanyCommandHandler(IMapper mapper, ICompanyRepository companyRepository)
        {
            this._mapper = mapper;
            this._companyRepository = companyRepository;
        }
        public async Task<int> Handle(CreateCompanyCommand request, CancellationToken cancellationToken)
        {
            // 1. Validate Incoming Data
            var validator = new CreateCompanyCommandValidator(this._companyRepository);
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (validationResult.Errors.Any()) throw new BadRequestExceptions("Invalid Company", validationResult);

            // 2. Convert to domain entity type object
            var companyToCreate = _mapper.Map<DAL.Company>(request);
            companyToCreate.ActiveStatus = true;

            // 3. Add to database
            await _companyRepository.CreateAsync(companyToCreate);
            // 
            // 4. return record id
            return companyToCreate.Id;
        }
    }
}
