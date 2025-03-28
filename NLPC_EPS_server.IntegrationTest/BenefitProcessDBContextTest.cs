using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.Application.Contracts.Identity;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.Persistence.DataAccess;
using Shouldly;

namespace NLPC_EPS_server.IntegrationTest
{
    public class BenefitProcessDBContextTest
    {
        private EPSDatabaseContext _context;
        private readonly IEmployeeProfileService _employeeProfileService;

        public BenefitProcessDBContextTest(IEmployeeProfileService employeeProfileService)
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
            var benefitProcess = new BenefitProcess
            {
                Id = 1,
                Description = "Test",
                ProcessCode = "Test",
            };

            // Act
            await _context.BenefitProcesses.AddAsync(benefitProcess);
            await _context.SaveChangesAsync();

            // Assert
            benefitProcess.Id.ShouldBeGreaterThan(0);
        }

        [Fact]
        public async void Get_SetDateCreatedValue()
        {
            // Act
            var list = await _context.BenefitProcesses.AsNoTracking().ToListAsync();

            // Assert
            list.Count().ShouldBeGreaterThan(0);
        }

        //[Fact]
        //public async void Save_SetDateModifiedValue()
        //{
        //    // Arrange
        //    var leaveType = new LeaveType
        //    {
        //        Id = 1,
        //        DefaultDays = 10,
        //        Name = "Test Vacation"
        //    };

        //    // Act
        //    await _hrDatabaseContext.LeaveTypes.AddAsync(leaveType);
        //    await _hrDatabaseContext.SaveChangesAsync();

        //    // Assert
        //    leaveType.DateModified.ShouldNotBeNull();
        //}
    }
}