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
    public class MockMemberContributionRepository
    {
        public static Mock<IMemberContributionRepository> GetMockMemberContribution()
        {
            var companies = new List<MemberContribution>
            {
                new MemberContribution
                {
                      Id = 1,
                       Amount = 10000,
                       ContributionDate = DateTime.Now,
                       ContributionTypeId = 1,
                      DateCreated = DateTime.Now,
                       Description = "Just Testing 1",
                       EmployeeProfileId = 3,
                       MemberProfileId = 7,
                      DateModified = DateTime.Now,
                },
                new MemberContribution
                {
                      Id = 2,
                      Amount = 20000,
                      ContributionDate = DateTime.Now,
                      ContributionTypeId = 2,
                      DateCreated = DateTime.Now,
                      Description = "Just Testing 2",
                      EmployeeProfileId = 9,
                      MemberProfileId = 15,
                      DateModified = DateTime.Now,
                },
            };

            var mockRepo = new Mock<IMemberContributionRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(companies);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<MemberContribution>()))
                .Returns((MemberContribution MemberContribution) =>
                {
                    companies.Add(MemberContribution);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
