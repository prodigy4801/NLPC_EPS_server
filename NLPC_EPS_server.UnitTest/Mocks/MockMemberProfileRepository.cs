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
    public class MockMemberProfileRepository
    {
        public static Mock<IMemberProfileRepository> GetMockMemberProfile()
        {
            var companies = new List<MemberProfile>
            {
                new MemberProfile
                {
                      Id = 1,
                      ActiveStatus = true,
                      Address = "AAAAAA BBBBB CCCCC",
                      DateCreated = DateTime.Now,
                      DateDeleted = DateTime.Now,
                      DateModified = DateTime.Now,
                      DeleteStatus = false,
                      DateOfBirth = DateTime.Now,
                      Email = "superman@yahoomail.com",
                      FullName = "KKKKK YYYYYY",
                      PhoneNumber = "1234567890"
                },
                
            };

            var mockRepo = new Mock<IMemberProfileRepository>();

            mockRepo.Setup(r => r.GetAsync()).ReturnsAsync(companies);

            mockRepo.Setup(r => r.CreateAsync(It.IsAny<MemberProfile>()))
                .Returns((MemberProfile MemberProfile) =>
                {
                    companies.Add(MemberProfile);
                    return Task.CompletedTask;
                });

            return mockRepo;
        }
    }
}
