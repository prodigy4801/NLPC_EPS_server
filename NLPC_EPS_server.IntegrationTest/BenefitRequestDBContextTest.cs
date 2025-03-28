using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.Persistence.DataAccess;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.IntegrationTest
{
    public class BenefitRequestDBContextTest
    {
        private EPSDatabaseContext _context;

        public BenefitRequestDBContextTest()
        {
            var dbOptions = new DbContextOptionsBuilder<EPSDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _context = new EPSDatabaseContext(dbOptions);
        }



        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            // Arrange
            var BenefitRequest = new BenefitRequest
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
            };

            // Act
            await _context.BenefitRequests.AddAsync(BenefitRequest);
            await _context.SaveChangesAsync();

            // Assert
            BenefitRequest.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            // Arrange
            var benefitRequest = new BenefitRequest
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
            };

            // Act
            await _context.BenefitRequests.AddAsync(benefitRequest);
            await _context.SaveChangesAsync();

            // Assert
            benefitRequest.DateModified.ShouldNotBeNull();
        }
    }
}
