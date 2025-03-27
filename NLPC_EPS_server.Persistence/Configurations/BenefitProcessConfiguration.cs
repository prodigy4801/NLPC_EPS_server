using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Persistence.Configurations
{
    public class BenefitProcessConfiguration : IEntityTypeConfiguration<BenefitProcess>
    {
        public void Configure(EntityTypeBuilder<BenefitProcess> builder)
        {
            builder.HasKey(q => q.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(q => q.ProcessCode)
                .IsRequired()
                .HasMaxLength(50);

            builder.HasMany(x => x.BenefitRequests)
                .WithOne(x => x.BenefitProcess)
                .HasForeignKey(x => x.BenefitProcessId);
        }
    }
}
