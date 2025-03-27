using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.Persistence.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Persistence.Configurations
{
    public class MemberProfileConfiguration : IEntityTypeConfiguration<MemberProfile>
    {
        public void Configure(EntityTypeBuilder<MemberProfile> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.EmployeeProfile)
                .WithMany()
                .HasForeignKey(x => x.EmployeeProfileId)
                .IsRequired();

            builder.Property(x => x.FullName)
              .IsRequired(true)
              .HasMaxLength(550);

            builder.HasIndex(x => x.Email).IsUnique();
            builder.Property(x => x.Email)
              .IsRequired(true)
              .HasMaxLength(550);

            builder.Property(x => x.PhoneNumber)
              .IsRequired(false)
              .HasMaxLength(50);

            builder.HasOne(x => x.Country)
                .WithMany()
                .HasForeignKey(x => x.CountryId)
                .IsRequired();

            builder.HasOne(x => x.State)
                    .WithMany()
                    .HasForeignKey(x => x.StateId)
                    .IsRequired();

            builder.HasMany(x => x.MemberContributions)
                .WithOne(x => x.MemberProfile)
                .HasForeignKey(x => x.MemberProfileId);
        }
    }
}
