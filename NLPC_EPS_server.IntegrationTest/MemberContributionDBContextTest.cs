using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.Application.Contracts.Identity;
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
    public class MemberContributionDBContextTest
    {
        private EPSDatabaseContext _context;
        private readonly IEmployeeProfileService _employeeProfileService;

        public MemberContributionDBContextTest(IEmployeeProfileService employeeProfileService)
        {
            var dbOptions = new DbContextOptionsBuilder<EPSDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;
            _employeeProfileService = employeeProfileService;

            _context = new EPSDatabaseContext(dbOptions, _employeeProfileService);
        }



        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            // Arrange
            var memberContribution = new MemberContribution
            {
                Id = 2,
                Amount = 20000,
                ContributionDate = DateTime.Now,
                ContributionTypeId = 2,
                DateCreated = DateTime.Now,
                Description = "Just Testing 2",
                MemberProfileId = 15,
                DateModified = DateTime.Now,
            };

            // Act
            await _context.MemberContributions.AddAsync(memberContribution);
            await _context.SaveChangesAsync();

            // Assert
            memberContribution.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            // Arrange
            var memberContribution = new MemberContribution
            {
                Id = 2,
                Amount = 20000,
                ContributionDate = DateTime.Now,
                ContributionTypeId = 2,
                DateCreated = DateTime.Now,
                Description = "Just Testing 2",
                MemberProfileId = 15,
                DateModified = DateTime.Now,
            };

            // Act
            await _context.MemberContributions.AddAsync(memberContribution);
            await _context.SaveChangesAsync();

            // Assert
            memberContribution.DateModified.ShouldNotBeNull();
        }
    }
}
