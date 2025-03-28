using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLPC_EPS_server.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Persistence.Configurations
{
    public class EmployeeProfileConfiguration : IEntityTypeConfiguration<EmployeeProfile>
    {
        public void Configure(EntityTypeBuilder<EmployeeProfile> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasMany(x => x.MemberProfiles)
                .WithOne(x => x.EmployeeProfile)
                .HasForeignKey(x => x.EmployeeProfileId);
        }
    }
}
