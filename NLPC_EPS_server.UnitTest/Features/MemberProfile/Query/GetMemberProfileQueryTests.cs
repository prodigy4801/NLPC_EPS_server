using AutoMapper;
using Moq;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.MemberProfile.Query.GetAllMemberProfile;
using NLPC_EPS_server.Application.MappingProfiles;
using NLPC_EPS_server.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.UnitTest.Features.MemberProfile.Query
{
    public class GetMemberProfileQueryHandlerTests
    {
        private readonly Mock<IMemberProfileRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetMemberProfileQueryHandler>> _mockAppLogger;

        public GetMemberProfileQueryHandlerTests()
        {
            _mockRepo = MockMemberProfileRepository.GetMockMemberProfile();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MemberProfileMapper>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetMemberProfileQueryHandler>>();
        }

        [Fact]
        public async Task GetMemberProfileListTest()
        {
            var handler = new GetMemberProfileQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetMemberProfileQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<MemberProfileDTO>>();
            result.Count.ShouldBe(3);
        }
    }
}
