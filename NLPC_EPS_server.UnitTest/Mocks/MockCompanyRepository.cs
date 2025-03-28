using Moq;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.UnitTest.Mocks
{
    public class MockCompanyRepository
    {
        public static Mock<ICompanyRepository> GetMockCompany()
        {
            var companies = new List<Company>
            {
                new Company
                {
                      Id = 1,
                      ActiveStatus = true,
                      Address = "AAAAAA BBBBB CCCCC",
                      CountryId = 2,
                      DateCreated = DateTime.Now,
                      Name = "BBBBBBBB GGGGGGG",
                      StateId = 1,
                      DateDeleted = DateTime.Now,
                      DateModified = DateTime.Now,
                      DeleteStatus = false,
                },
                new Company
                {
                      Id = 2,
                      ActiveStatus = false,
                      Address = "ZZZZZZ YYYYY XXXXX",
                      CountryId = 2,
                      DateCreated = DateTime.Now,
                      Name = "kkkkkkkk JJJJJJJJ",
                      StateId = 8,
                      DateDeleted = DateTime.Now,
                      DateModified = DateTime.Now,
                      DeleteStatus = false,
                },
                new Company
                {
                      Id = 3,
                      ActiveStatus = true,
                      Address = "RRRRRR SSSSS TTTT",
                      CountryId = 2,
                      DateCreated = DateTime.Now,
                      Name = "JJJJJJJJ LLLLLLLSL",
                      StateId = 5,
                      DateDeleted = DateTime.Now,
                      DateModified = DateTime.Now,
                      DeleteStatus = false,
                }
            };

            var mockRepo = new Mock<ICompanyRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(companies);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<Company>()))
                .Returns((Company company) =>
                {
                    companies.Add(company);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
