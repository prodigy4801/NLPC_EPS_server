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
    public class CompanyDBContextTest
    {
        private EPSDatabaseContext _context;

        public CompanyDBContextTest()
        {
            var dbOptions = new DbContextOptionsBuilder<EPSDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _context = new EPSDatabaseContext(dbOptions);
        }



        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            // Arrange
            var Company = new Company
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
            };

            // Act
            await _context.Companies.AddAsync(Company);
            await _context.SaveChangesAsync();

            // Assert
            Company.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            // Arrange
            var company = new Company
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
            };

            // Act
            await _context.Companies.AddAsync(company);
            await _context.SaveChangesAsync();

            // Assert
            company.DateModified.ShouldNotBeNull();
        }
    }
}
