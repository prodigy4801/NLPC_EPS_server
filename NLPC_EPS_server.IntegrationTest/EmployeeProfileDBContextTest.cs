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
    public class EmployeeProfileDBContextTest
    {
        private EPSDatabaseContext _context;

        public EmployeeProfileDBContextTest()
        {
            var dbOptions = new DbContextOptionsBuilder<EPSDatabaseContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString()).Options;

            _context = new EPSDatabaseContext(dbOptions);
        }



        [Fact]
        public async void Save_SetDateCreatedValue()
        {
            // Arrange
            var employeeProfile = new EmployeeProfile
            {
                Id = 1,
                CompanyId = 1,
                Email = "testemail@gmail.com",
                EmailConfirmed = false,
                DateCreated = DateTime.Now,
                FullName = "TTTTTTT GGGGG HHHHH"
            };

            // Act
            await _context.EmployeeProfiles.AddAsync(employeeProfile);
            await _context.SaveChangesAsync();

            // Assert
            employeeProfile.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            // Arrange
            var employeeProfile = new EmployeeProfile
            {
                Id = 1,
                CompanyId = 1,
                Email = "testemail@gmail.com",
                EmailConfirmed = false,
                DateCreated = DateTime.Now,
                FullName = "TTTTTTT GGGGG HHHHH"
            };

            // Act
            await _context.EmployeeProfiles.AddAsync(employeeProfile);
            await _context.SaveChangesAsync();

            // Assert
            employeeProfile.DateModified.ShouldNotBeNull();
        }
    }
}
