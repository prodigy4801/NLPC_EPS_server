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
    public class MockContributionTypeRepository
    {
        public static Mock<IContributionTypeRepository> GetMockContributionType()
        {
            var companies = new List<ContributionType>
            {
                new ContributionType
                {
                      Id = 1,
                      Type = "ER Contribution",
                      Description = "Contribution Made by your organization"
                },
                new ContributionType
                {
                      Id = 2,
                      Type = "Self-Invested Personal",
                      Description = "Self-Invested Personal Pensions (SIPPs) SIPPs are a modern type of personal pension that allow you to choose from a wide range of investments."
                },
                new ContributionType
                {
                      Id = 3,
                      Type = "Stakeholder Pension",
                      Description = "Stakeholder Pensions are a straight-forward type of personal pension with low minimum contributions"
                },
            };

            var mockRepo = new Mock<IContributionTypeRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(companies);

            return mockRepo;
        }
    }
}
