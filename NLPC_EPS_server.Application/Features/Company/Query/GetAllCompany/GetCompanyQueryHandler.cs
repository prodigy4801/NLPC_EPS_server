using AutoMapper;
using MediatR;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Exceptions;
using System;
namespace NLPC_EPS_server.Application.Features.Company.Query.GetAllCompany
{
    public class GetCompanyQueryHandler : IRequestHandler<GetCompanyQuery, List<CompanyDTO>>
    {
        private readonly IMapper _mapper;
        private readonly ICompanyRepository _companyRepository;
        private readonly IAppLogger<GetCompanyQueryHandler> _logger;

        public GetCompanyQueryHandler(
            IMapper mapper,
            ICompanyRepository companyRepository,
            IAppLogger<GetCompanyQueryHandler> logger
        )
        {
            this._mapper = mapper;
            this._companyRepository = companyRepository;
            this._logger = logger;
        }
        public async Task<List<CompanyDTO>> Handle(GetCompanyQuery request, CancellationToken cancellationToken)
        {
            // 1. Query the Database
            var companies = await _companyRepository.GetAsync();
            if (companies == null || companies.Count == 0)
            {
                _logger.LogInformation("Get All Company contains no information.", nameof(companies));
                throw new NotFoundExceptions(nameof(companies), "getAllCompany");
            }

            // 2. Convert data objects to DTO object
            var data = _mapper.Map<List<CompanyDTO>>(companies);
            _logger.LogInformation("Companies were retrieved successfully", nameof(companies));

            // 3. Return list of DTO Object
            return data;
        }
    }
}
