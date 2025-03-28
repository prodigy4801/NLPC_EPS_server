using AutoMapper;
using Moq;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Application.Features.Company.Command.CreateCompany;
using NLPC_EPS_server.Application.MappingProfiles;
using NLPC_EPS_server.UnitTest.Mocks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.UnitTest.Features.Company.Command
{
    public class CreateCompanyCommandTests
    {
        private readonly IMapper _mapper;
        private readonly Mock<ICompanyRepository> _mockCategoryRepository;
        private Mock<ICompanyRepository> _mockRepo;

        public CreateCompanyCommandTests()
        {
            _mockRepo = MockCompanyRepository.GetMockCompany();

            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<CompanyProfileMapper>();
            });

            _mapper = mapperConfig.CreateMapper();
        }

        [Fact]
        public async Task Handle_ValidCategory_AddedToCategoriesRepo()
        {
            var handler = new CreateCompanyCommandHandler(_mapper, _mockRepo.Object);

            await handler.Handle(new CreateCompanyCommand() 
            {
                Address = "RRRRR UUUUU WWWWWWW",
                CountryId = 2,
                Name = "EEEEEEE FFFFFFF",
                StateId = 10,
            }, CancellationToken.None);

            var companies = await _mockCategoryRepository.Object.GetAsync();
            companies.Count.ShouldBe(4);
        }
    }
}
