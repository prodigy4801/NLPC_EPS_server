using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Persistence.Configurations
{
    public class ContributionTypeConfiguration : IEntityTypeConfiguration<ContributionType>
    {
        public void Configure(EntityTypeBuilder<ContributionType> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.Property(x => x.Type)
               .IsRequired(true)
               .HasMaxLength(100);
            builder.HasIndex(x => x.Type).IsUnique();

            builder.Property(x => x.Description)
               .IsRequired(false)
               .HasMaxLength(550);

            builder.HasMany(x => x.MemberContributions)
                .WithOne(x => x.ContributionType)
                .HasForeignKey(x => x.ContributionTypeId);
        }
    }
}
