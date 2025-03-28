using AutoMapper;
using Moq;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.BenefitRequest.Query.GetAllBenefitRequest;
using NLPC_EPS_server.Application.MappingProfiles;
using NLPC_EPS_server.UnitTest.Mocks;
using Shouldly;

namespace NLPC_EPS_server.UnitTest.Features.BenefitRequest.Query
{
    public class GetBenefitRequestQueryHandlerTests
    {
        private readonly Mock<IBenefitRequestRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetBenefitRequestQueryHandler>> _mockAppLogger;

        public GetBenefitRequestQueryHandlerTests()
        {
            _mockRepo = MockBenefitRequestRepository.GetMockBenefitRequest();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<BenefitRequestProfileMapper>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetBenefitRequestQueryHandler>>();
        }

        [Fact]
        public async Task GetBenefitRequestListTest()
        {
            var handler = new GetBenefitRequestQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetBenefitRequestQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<BenefitRequestDTO>>();
            result.Count.ShouldBe(3);
        }
    }
}
