using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NLPC_EPS_server.Application.Contracts.Email;
using NLPC_EPS_server.Application.Contracts.Logging;
using NLPC_EPS_server.Application.Models.Email;
using NLPC_EPS_server.Infrastructure.EmailService;
using NLPC_EPS_server.Infrastructure.Logging;

namespace NLPC_EPS_server.Infrastructure
{
    public static class InfrastrustureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.AddTransient<IEmailSender, EmailSender>();
            services.AddScoped(typeof(IAppLogger<>), typeof(LoggerAdapter<>));
            return services;
        }
    }
}
