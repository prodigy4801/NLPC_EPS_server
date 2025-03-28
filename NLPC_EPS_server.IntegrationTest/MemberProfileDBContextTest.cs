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
    public class MemberProfileDBContextTest
    {
        private EPSDatabaseContext _context;
        private readonly IEmployeeProfileService _employeeProfileService;

        public MemberProfileDBContextTest(IEmployeeProfileService employeeProfileService)
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
            var memberProfile = new MemberProfile
            {
                Id = 1,
                ActiveStatus = true,
                Address = "AAAAAA BBBBB CCCCC",
                CountryId = 2,
                DateCreated = DateTime.Now,
                StateId = 1,
                DateDeleted = DateTime.Now,
                DateModified = DateTime.Now,
                DeleteStatus = false,
                DateOfBirth = DateTime.Now,
                Email = "superman@yahoomail.com",
                FullName = "KKKKK YYYYYY",
                PhoneNumber = "1234567890"
            };

            // Act
            await _context.MemberProfiles.AddAsync(memberProfile);
            await _context.SaveChangesAsync();

            // Assert
            memberProfile.DateCreated.ShouldNotBeNull();
        }

        [Fact]
        public async void Save_SetDateModifiedValue()
        {
            // Arrange
            var memberProfile = new MemberProfile
            {
                Id = 1,
                ActiveStatus = true,
                Address = "AAAAAA BBBBB CCCCC",
                CountryId = 2,
                DateCreated = DateTime.Now,
                StateId = 1,
                DateDeleted = DateTime.Now,
                DateModified = DateTime.Now,
                DeleteStatus = false,
                DateOfBirth = DateTime.Now,
                Email = "superman@yahoomail.com",
                FullName = "KKKKK YYYYYY",
                PhoneNumber = "1234567890"
            };

            // Act
            await _context.MemberProfiles.AddAsync(memberProfile);
            await _context.SaveChangesAsync();

            // Assert
            memberProfile.DateModified.ShouldNotBeNull();
        }
    }
}
