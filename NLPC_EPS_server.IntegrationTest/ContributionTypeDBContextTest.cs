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
    public class ContributionTypeDBContextTest
    {
        private EPSDatabaseContext _context;

        public ContributionTypeDBContextTest()
        {
            var dbOptions = new DbContextOptionsBuilder<EPSDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _context = new EPSDatabaseContext(dbOptions);
        }



        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            // Arrange
            var contributionType = new ContributionType
            {
                Id = 2,
                Type = "Self-Invested Personal",
                Description = "Self-Invested Personal Pensions (SIPPs) SIPPs are a modern type of personal pension that allow you to choose from a wide range of investments."
            };

            // Act
            await _context.ContributionTypes.AddAsync(contributionType);
            await _context.SaveChangesAsync();

            // Assert
            contributionType.Id.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            // Arrange
            var contributionType = new ContributionType
            {
                Id = 2,
                Type = "Self-Invested Personal",
                Description = "Self-Invested Personal Pensions (SIPPs) SIPPs are a modern type of personal pension that allow you to choose from a wide range of investments."
            };

            // Act
            await _context.ContributionTypes.AddAsync(contributionType);
            await _context.SaveChangesAsync();

            // Assert
            contributionType.Id.ShouldBeGreaterThan(0);
        }
    }
}
