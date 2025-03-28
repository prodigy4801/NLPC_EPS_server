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
    public class MockEmployeeProfileRepository
    {
        public static Mock<IEmployeeProfileRepository> GetMockEmployeeProfile()
        {
            var companies = new List<EmployeeProfile>
            {
                new EmployeeProfile
                {
                      Id = 1,
                      CompanyId = 1,
                      Email = "testemail@gmail.com",
                      EmailConfirmed = false,
                      DateCreated = DateTime.Now,
                      FullName = "TTTTTTT GGGGG HHHHH"
                },
                new EmployeeProfile
                {
                      Id = 2,
                      CompanyId = 9,
                      Email = "testemail2@gmail.com",
                      EmailConfirmed = false,
                      DateCreated = DateTime.Now,
                      FullName = "TTTTTTT GGGGG HHHHH"
                },
                new EmployeeProfile
                {
                      Id = 3,
                      CompanyId = 5,
                      Email = "testemail3@gmail.com",
                      EmailConfirmed = false,
                      DateCreated = DateTime.Now,
                      FullName = "TTTTTTT GGGGG HHHHH"
                },
                new EmployeeProfile
                {
                      Id = 4,
                      CompanyId =6,
                      Email = "testemail4@gmail.com",
                      EmailConfirmed = false,
                      DateCreated = DateTime.Now,
                      FullName = "TTTTTTT GGGGG HHHHH"
                },
            };

            var mockRepo = new Mock<IEmployeeProfileRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(companies);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<EmployeeProfile>()))
                .Returns((EmployeeProfile EmployeeProfile) =>
                {
                    companies.Add(EmployeeProfile);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
