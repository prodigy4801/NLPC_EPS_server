using AutoMapper;
using Moq;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.MemberContribution.Command.CreateMemberContribution;
using NLPC_EPS_server.Application.MappingProfiles;
using NLPC_EPS_server.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.UnitTest.Features.MemberContribution.Command
{
    public class CreateMemberContributionCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMemberContributionRepository> _mockCategoryRepository;
        private Mock<IMemberContributionRepository> _mockRepo;
        private Mock<IMemberProfileRepository> _mockMemberProfileRepo;
        private Mock<IContributionTypeRepository> _mockContributionTypeRepo;

        public CreateMemberContributionCommandTests()
        {
            _mockRepo = MockMemberContributionRepository.GetMockMemberContribution();
            _mockContributionTypeRepo = MockContributionTypeRepository.GetMockContributionType();
            _mockMemberProfileRepo = MockMemberProfileRepository.GetMockMemberProfile();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MemberContributionProfileMapper>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateMemberContributionCommandHandler(_mapper, _mockRepo.Object, _mockMemberProfileRepo.Object, _mockContributionTypeRepo.Object);

            await handler.Handle(new CreateMemberContributionCommand()
            {
                Id = 6,
                Amount = 50000,
                ContributionTypeId = 2,
                MemberProfileId = 26,
            }, CancellationToken.None);

            var companies = await _mockCategoryRepository.Object.GetAsync();
            companies.Count.ShouldBe(4);
        }
    }
}
