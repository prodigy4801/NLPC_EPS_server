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
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Name)
               .IsRequired(true)
               .HasMaxLength(255);
            builder.HasIndex(x => x.Name).IsUnique();

            builder.Property(x => x.Address)
                .IsRequired()
                .HasMaxLength(550);

            builder.HasOne(x => x.Country)
                .WithMany()
                .HasForeignKey(x => x.CountryId)
                .IsRequired(false);

            builder.HasOne(x => x.State)
                .WithMany()
                .HasForeignKey(x => x.StateId)
                .IsRequired(false);

            builder.HasMany(x => x.EmployeeProfiles)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);
        }
    }
}
