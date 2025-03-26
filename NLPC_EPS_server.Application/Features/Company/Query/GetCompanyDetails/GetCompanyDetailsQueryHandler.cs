using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using NLPC_EPS_server.Application.Features.Company.Query.GetCompanyDetails;

namespace NLPC_EPS_server.Application.Features.BenefitProcess.Query.GetBenefitProcessDetails
{
    public class GetCompanyDetailsQueryHandler : IRequestHandler<GetCompanyDetailsQuery, CompanyDetailsDTO>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly IAppLogger<GetCompanyDetailsQueryHandler> _logger;

        public GetCompanyDetailsQueryHandler(
            IMapper mapper,
            ICompanyRepository companyRepository,
            IAppLogger<GetCompanyDetailsQueryHandler> logger
        )
        {
            this._mapper = mapper;
            this._companyRepository = companyRepository;
            this._logger = logger;
        }
        public async Task<CompanyDetailsDTO> Handle(GetCompanyDetailsQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var company = await _companyRepository.Get(request.Id);
            if (company == null)
            {
                _logger.LogInformation("Get Company Details contains no information.", nameof(company));
                throw new NotFoundExceptions(nameof(company), "getCompanyDetails");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<CompanyDetailsDTO>(company);
            _logger.LogInformation("Company was retrieved successfully", nameof(company));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
