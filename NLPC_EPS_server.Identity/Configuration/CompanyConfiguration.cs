using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NLPC_EPS_server.Application.Models.Identity;

namespace NLPC_EPS_server.Identity.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData(
                 new Company
                 {
                     Id = 1,
                     Name = "NLPC Pension Fund Administrators Limited",
                      ActiveStatus = true,
                     Address = "312 Ikorodu Rd, Anthony, Lagos 105102, Lagos.",
                     DeleteStatus = false,
                 }
            );
        }
    }
}
