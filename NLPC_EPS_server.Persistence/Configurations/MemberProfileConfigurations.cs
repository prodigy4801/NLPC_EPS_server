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
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasIndex(x => x.Email).IsUnique();

            builder.HasOne(x => x.Country)
                .WithMany()
                .HasForeignKey(x => x.CountryId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.State)
                .WithMany()
                .HasForeignKey(x => x.StateId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
