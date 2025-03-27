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

            builder.HasOne(x => x.ContributionType)
                .WithMany()
                .HasForeignKey(x => x.ContributionTypeId)
                .IsRequired();

            builder.Property(x => x.Description)
                .HasMaxLength(550)
                .IsRequired(false);

            builder.Property(x => x.Amount)
                .IsRequired(true)
                .HasColumnType("decimal(16,2)");
        }
    }
}
