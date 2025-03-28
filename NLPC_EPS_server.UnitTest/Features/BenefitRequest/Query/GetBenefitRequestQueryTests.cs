using AutoMapper;
using Moq;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetAllBenefitRequest;
using NLPC_EPS_server.Application.Features.Company.Query.GetAllCompany;
using NLPC_EPS_server.Application.MappingProfiles;
using NLPC_EPS_server.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.UnitTest.Features.BenefitRequest.Query
{
    public class GetCompanyQueryHandlerTests
    {
        private readonly Mock<ICompanyRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetCompanyQueryHandler>> _mockAppLogger;

        public GetCompanyQueryHandlerTests()
        {
            _mockRepo = MockCompanyRepository.GetMockCompany();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<BenefitRequestProfileMapper>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetCompanyQueryHandler>>();
        }

        [Fact]
        public async Task GetCompanyListTest()
        {
            var handler = new GetCompanyQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetCompanyQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<BenefitRequestDTO>>();
            result.Count.ShouldBe(3);
        }
    }
}
