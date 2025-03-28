using AutoMapper;
using Moq;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.MemberContribution.Query.GetAllMemberContribution;
using NLPC_EPS_server.Application.MappingProfiles;
using NLPC_EPS_server.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.UnitTest.Features.MemberContribution.Query
{
    public class GetMemberContributionQueryHandlerTests
    {
        private readonly Mock<IMemberContributionRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetMemberContributionQueryHandler>> _mockAppLogger;

        public GetMemberContributionQueryHandlerTests()
        {
            _mockRepo = MockMemberContributionRepository.GetMockMemberContribution();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MemberContributionProfileMapper>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetMemberContributionQueryHandler>>();
        }

        [Fact]
        public async Task GetMemberContributionListTest()
        {
            var handler = new GetMemberContributionQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetMemberContributionQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<MemberContributionDTO>>();
            result.Count.ShouldBe(3);
        }
    }
}
