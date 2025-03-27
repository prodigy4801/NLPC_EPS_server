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

            builder.HasData(
                new BenefitProcess
                {
                    Id = 1,
                     Description = "Benefit Request is just initiated",
                      ProcessCode = "PENDING",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new BenefitProcess
                {
                    Id = 2,
                    Description = "Benefit Request is on the Verification Stage",
                    ProcessCode = "VERIFICATION",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new BenefitProcess
                {
                    Id = 3,
                    Description = "Benefit Request has been denied",
                    ProcessCode = "DENIED",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new BenefitProcess
                {
                    Id = 4,
                    Description = "Benefit Request has been confirmed",
                    ProcessCode = "CONFIRMED",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                },
                new BenefitProcess
                {
                    Id = 5,
                    Description = "Requested Benefit has been sent to Member's Account.",
                    ProcessCode = "DISBURSED",
                    DateCreated = DateTime.Now,
                    DateModified = DateTime.Now
                }
            );
        }
    }
}
