using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.DAL;
using NLPC_EPS_server.Persistence.DataAccess;

namespace NLPC_EPS_server.Persistence.Configurations
{
    public class BenefitRequestConfiguration : IEntityTypeConfiguration<BenefitRequest>
    {
        public void Configure(EntityTypeBuilder<BenefitRequest> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.RequestedAmount)
                .HasColumnType("decimal(16,2)");

            builder.Property(x => x.DispatchedAmount)
                .HasColumnType("decimal(16,2)");

            builder.HasOne(x => x.MemberProfile)
                .WithMany()
                .HasForeignKey(x => x.MemberProfileId)
                .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne(x => x.BenefitProcess)
                .WithMany()
                .HasForeignKey(x => x.BenefitProcessId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
