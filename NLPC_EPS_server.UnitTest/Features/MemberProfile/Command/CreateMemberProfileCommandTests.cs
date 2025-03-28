﻿using AutoMapper;
using Moq;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.MemberProfile.Command.CreateMemberProfile;
using NLPC_EPS_server.Application.MappingProfiles;
using NLPC_EPS_server.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.UnitTest.Features.MemberProfile.Command
{
    public class CreateMemberProfileCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IMemberProfileRepository> _mockCategoryRepository;
        private Mock<IMemberProfileRepository> _mockRepo;
        private Mock<IEmployeeProfileRepository> _mockEmployeeProfileRepo;

        public CreateMemberProfileCommandTests()
        {
            _mockRepo = MockMemberProfileRepository.GetMockMemberProfile();
            _mockEmployeeProfileRepo = MockEmployeeProfileRepository.GetMockEmployeeProfile();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MemberProfileMapper>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateMemberProfileCommandHandler(_mapper, _mockRepo.Object, _mockEmployeeProfileRepo.Object);

            await handler.Handle(new CreateMemberProfileCommand()
            {
                Address = "AAAAAA BBBBB CCCCC",
                CountryId = 2,
                StateId = 1,
                DateOfBirth = DateTime.Now,
                Email = "superman@yahoomail.com",
                EmployeeProfileId = 3,
                FullName = "KKKKK YYYYYY",
                PhoneNumber = "1234567890",
            }, CancellationToken.None);

            var companies = await _mockCategoryRepository.Object.GetAsync();
            companies.Count.ShouldBe(4);
        }
    }
}
