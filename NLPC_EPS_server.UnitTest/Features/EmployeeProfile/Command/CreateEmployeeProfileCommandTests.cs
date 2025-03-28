using AutoMapper;
using Moq;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.EmployeeProfile.Command.CreateEmployeeProfile;
using NLPC_EPS_server.Application.MappingProfiles;
using NLPC_EPS_server.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.UnitTest.Features.EmployeeProfile.Command
{
    public class CreateEmployeeProfileCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<IEmployeeProfileRepository> _mockCategoryRepository;
        private Mock<IEmployeeProfileRepository> _mockRepo;
        private Mock<ICompanyRepository> _mockCompanyRepo;

        public CreateEmployeeProfileCommandTests()
        {
            _mockRepo = MockEmployeeProfileRepository.GetMockEmployeeProfile();
            _mockCompanyRepo = MockCompanyRepository.GetMockCompany();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<EmployeeProfileMapper>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateEmployeeProfileCommandHandler(_mapper, _mockRepo.Object, _mockCompanyRepo.Object);

            await handler.Handle(new CreateEmployeeProfileCommand()
            {
                CompanyId = 7,
                Email = "testemail6@gmail.com",
                FullName = "NEW Name",
                Password = "password",
            }, CancellationToken.None);

            var companies = await _mockCategoryRepository.Object.GetAsync();
            companies.Count.ShouldBe(4);
        }
    }
}
