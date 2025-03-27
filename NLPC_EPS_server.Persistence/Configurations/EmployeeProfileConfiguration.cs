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
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.Company)
                .WithMany()
                .HasForeignKey(x => x.CompanyId)
                .IsRequired(false);

            builder.Property(x => x.FullName)
              .IsRequired(true)
              .HasMaxLength(550);

            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email)
              .IsRequired(true)
              .HasMaxLength(550);

            builder.Property(x => x.RefreshToken)
                .IsRequired(false);

            builder.Property(x => x.RefreshTokenExpiration)
                .IsRequired(false);

            builder.HasMany(x => x.MemberProfiles)
                .WithOne(x => x.EmployeeProfile)
                .HasForeignKey(x => x.EmployeeProfileId);
        }
    }
}
