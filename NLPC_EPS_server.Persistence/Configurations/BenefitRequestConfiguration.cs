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
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasOne(x => x.MemberProfile)
                .WithMany()
                .HasForeignKey(x => x.MemberProfileId)
                .IsRequired();

            builder.HasOne(x => x.EmployeeProfile)
                .WithMany()
                .HasForeignKey(x => x.EmployeeProfileId)
                .IsRequired();

            builder.Property(x => x.RequestDescription)
                .IsRequired(true);

            builder.Property(x => x.RequestedAmount)
                .IsRequired(true)
                .HasColumnType("decimal(16,2)");

            builder.Property(x => x.DispatchedAmount)
                .IsRequired(false)
                .HasColumnType("decimal(16,2)");

            builder.HasOne(x => x.BenefitProcess)
                .WithMany()
                .HasForeignKey(x => x.BenefitProcessId)
                .IsRequired();

            builder.Property(x => x.EmployeeComment)
                .IsRequired(false)
                .HasMaxLength(550);

            builder.Property(x => x.DateDispatched)
                .IsRequired(false);
        }
    }
}
