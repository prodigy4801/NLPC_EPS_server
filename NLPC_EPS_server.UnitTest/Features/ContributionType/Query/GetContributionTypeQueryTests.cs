using AutoMapper;
using Moq;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.ContributionType.Query.GetAllContributionType;
using NLPC_EPS_server.Application.MappingProfiles;
using NLPC_EPS_server.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.UnitTest.Features.ContributionType.Query
{
    public class GetContributionTypeQueryHandlerTests
    {
        private readonly Mock<IContributionTypeRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetContributionTypeQueryHandler>> _mockAppLogger;

        public GetContributionTypeQueryHandlerTests()
        {
            _mockRepo = MockContributionTypeRepository.GetMockContributionType();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<ContributionTypeProfileMapper>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetContributionTypeQueryHandler>>();
        }

        [Fact]
        public async Task GetContributionTypeListTest()
        {
            var handler = new GetContributionTypeQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetContributionTypeQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<ContributionTypeDTO>>();
            result.Count.ShouldBe(3);
        }
    }
}
