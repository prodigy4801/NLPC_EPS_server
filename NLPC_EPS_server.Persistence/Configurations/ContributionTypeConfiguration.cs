using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NLPC_EPS_server.DAL;

namespace NLPC_EPS_server.Persistence.Configurations
{
    public class ContributionTypeConfiguration : IEntityTypeConfiguration<ContributionType>
    {
        public void Configure(EntityTypeBuilder<ContributionType> builder)
        {
            builder.Property(x => x.Id).ValueGeneratedOnAdd();

            builder.HasMany(x => x.MemberContributions)
                .WithOne(x => x.ContributionType)
                .HasForeignKey(x => x.ContributionTypeId);

            builder.HasData(
                new ContributionType
                {
                    Id = 1,
                    Type = "Monthly Contribution",
                    Description = "Contribution done monthly through a well organised system or organization."
                },
                new ContributionType
                {
                    Id = 2,
                    Type = "Voluntary Contribution",
                    Description = "Contribution made by the Member and its done at any given time."
                }
            );
        }
    }
}
