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
    public class MockBenefitRequestRepository
    {
        public static Mock<IBenefitRequestRepository> GetMockBenefitRequest()
        {
            var companies = new List<BenefitRequest>
            {
                new BenefitRequest
                {
                      Id = 1,
                      BenefitProcessId = 1,
                      DateDispatched = DateTime.Now,
                      DispatchedAmount = 300000,
                      EmployeeComment = "Just Testing",
                      EmployeeProfileId = 1,
                      MemberProfileId = 1,
                      RequestDescription = "Just Testing",
                      RequestedAmount = 500000
                },
                new BenefitRequest
                {
                      Id = 2,
                      BenefitProcessId = 2,
                      DateDispatched = DateTime.Now,
                      DispatchedAmount = 300000,
                      EmployeeComment = "Just Testing",
                      EmployeeProfileId = 5,
                      MemberProfileId = 3,
                      RequestDescription = "Just Testing",
                      RequestedAmount = 500000
                }
            };

            var mockRepo = new Mock<IBenefitRequestRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(companies);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<BenefitRequest>()))
                .Returns((BenefitRequest BenefitRequest) =>
                {
                    companies.Add(BenefitRequest);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
