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
    public class StateConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id)
               .IsRequired()
               .HasValueGenerator<SequentialGuidStringGenerator>();

            builder.HasIndex(x => x.Name).IsUnique();
            builder.Property(x => x.Name)
             .IsRequired(true)
             .HasMaxLength(255);

            builder.Property(x => x.Code)
             .IsRequired(false)
             .HasMaxLength(50);

            builder.HasOne(x => x.Country)
                .WithMany()
                .HasForeignKey(x => x.CountryId)
                .IsRequired();

            builder.HasMany(x => x.Companies)
                .WithOne(x => x.State)
                .HasForeignKey(x => x.StateId);
        }
    }
}
