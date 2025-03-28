using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLPC_EPS_server.Application.Contracts.Persistence;
using NLPC_EPS_server.Persistence.DataAccess;
using NLPC_EPS_server.Persistence.Repositories;
using NLPC_EPS_server.Persistence.Repository;

namespace NLPC_EPS_server.Persistence
{
    public static class PersistenceServiceRegistration
    {
        public static IServiceCollection AddPersistenceServices(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<EPSDatabaseContext>(options => {
                options.UseSqlServer(configuration.GetConnectionString("EPSDatabaseConnectionString"));
            });

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IBenefitProcessRepository, BenefitProcessRepository>();
            services.AddScoped<IBenefitRequestRepository, BenefitRequestRepository>();
            services.AddScoped<IContributionTypeRepository, ContributionTypeRepository>();
            services.AddScoped<IMemberContributionRepository, MemberContributionRepository>();
            services.AddScoped<IMemberProfileRepository, MemberProfileRepository>();

            return services;
        }
    }
}
