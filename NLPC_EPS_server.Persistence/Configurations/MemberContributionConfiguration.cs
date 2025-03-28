using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.Persistence.DataAccess;

namespace NLPC_EPS_server.Persistence.Configurations
{
    public class MemberContributionConfiguration : IEntityTypeConfiguration<MemberContribution>
    {
        public void Configure(EntityTypeBuilder<MemberContribution> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Amount)
                .HasColumnType("decimal(16,2)");

            builder.HasOne(x => x.MemberProfile)
                .WithMany()
                .HasForeignKey(x => x.MemberProfileId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
