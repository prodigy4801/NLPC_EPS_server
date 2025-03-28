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
            builder.Property(x => x.Id).ValueGeneratedOnAdd();


            builder.HasOne(x => x.Country)
                .WithMany()
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.State)
                .WithMany()
                .HasForeignKey(x => x.StateId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasMany(x => x.EmployeeProfiles)
                .WithOne(x => x.Company)
                .HasForeignKey(x => x.CompanyId);

        }
    }
}
