using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using NLPC_EPS_server.Identity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLPC_EPS_server.Identity.DbContext
{
    public class EPSServerIdentityDbContext : IdentityDbContext<AppUser>
    {
        public EPSServerIdentityDbContext(
            DbContextOptions<EPSServerIdentityDbContext> options
        ) : base( options )
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(EPSServerIdentityDbContext).Assembly);
        }
    }
}
