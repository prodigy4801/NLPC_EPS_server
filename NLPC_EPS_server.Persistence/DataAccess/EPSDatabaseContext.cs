using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.DAL.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Persistence.DataAccess
{
    public class EPSDatabaseContext : DbContext
    {
        public EPSDatabaseContext(DbContextOptions<EPSDatabaseContext> options) : base(options)
        { }

        public DbSet<BenefitProcess> BenefitProcesses { get; set; }
        public DbSet<BenefitRequest> BenefitRequests { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ContributionType> ContributionTypes { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<EmployeeProfile> EmployeeProfiles { get; set; }
        public DbSet<MemberContribution> MemberContributions { get; set; }
        public DbSet<MemberProfile> MemberProfiles { get; set; }
        public DbSet<State> States { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(EPSDatabaseContext).Assembly);
            base.OnModelCreating(modelBuilder);
        }

        public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            foreach (var entry in base.ChangeTracker.Entries<BaseEntity>()
                .Where(q => q.State == EntityState.Added || q.State == EntityState.Modified))
            {
                entry.Entity.DateModified = DateTime.UtcNow;
                if (entry.State == EntityState.Added) entry.Entity.DateCreated = DateTime.UtcNow;
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
