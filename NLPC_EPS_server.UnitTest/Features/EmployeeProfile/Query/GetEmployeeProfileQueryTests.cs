using AutoMapper;
using Moq;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Query.GetAllEmployeeProfile;
using NLPC_EPS_server.Application.MappingProfiles;
using NLPC_EPS_server.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.UnitTest.Features.EmployeeProfile.Query
{
    public class GetEmployeeProfileQueryHandlerTests
    {
        private readonly Mock<IEmployeeProfileRepository> _mockRepo;
        private IMapper _mapper;
        private Mock<IAppLogger<GetEmployeeProfileQueryHandler>> _mockAppLogger;

        public GetEmployeeProfileQueryHandlerTests()
        {
            _mockRepo = MockEmployeeProfileRepository.GetMockEmployeeProfile();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<EmployeeProfileMapper>();
            });

            _mapper = mapperConfig.CreateMapper();
            _mockAppLogger = new Mock<IAppLogger<GetEmployeeProfileQueryHandler>>();
        }

        [Fact]
        public async Task GetEmployeeProfileListTest()
        {
            var handler = new GetEmployeeProfileQueryHandler(_mapper, _mockRepo.Object, _mockAppLogger.Object);

            var result = await handler.Handle(new GetEmployeeProfileQuery(), CancellationToken.None);

            result.ShouldBeOfType<List<EmployeeProfileDTO>>();
            result.Count.ShouldBe(3);
        }
    }
}
