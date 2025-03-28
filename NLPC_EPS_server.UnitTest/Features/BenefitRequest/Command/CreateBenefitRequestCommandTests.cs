using AutoMapper;
using Moq;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.BenefitRequest.Command.CreateBenefitRequest;
using NLPC_EPS_server.Application.MappingProfiles;
using NLPC_EPS_server.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.UnitTest.Features.BenefitRequest.Command
{
    public class CreateBenefitRequestCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IBenefitRequestRepository> _mockCategoryRepository;
        private Mock<IBenefitRequestRepository> _mockRepo;
        private Mock<IMemberProfileRepository> _mockMemberProfileRepo;

        public CreateBenefitRequestCommandTests()
        {
            _mockRepo = MockBenefitRequestRepository.GetMockBenefitRequest();
            _mockMemberProfileRepo = MockMemberProfileRepository.GetMockMemberProfile();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<BenefitRequestProfileMapper>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateBenefitRequestCommandHandler(_mapper, _mockRepo.Object, _mockMemberProfileRepo.Object);

            await handler.Handle(new CreateBenefitRequestCommand()
            {
                DateDispatched = DateTime.Now,
                MemberProfileId = 3,
                RequestDescription = "Just Testing",
                RequestedAmount = 500000
            }, CancellationToken.None);

            var companies = await _mockCategoryRepository.Object.GetAsync();
            companies.Count.ShouldBe(4);
        }
    }
}
