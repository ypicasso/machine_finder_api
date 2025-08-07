using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MachineFinder.Application.Contracts.Persistence;
using MachineFinder.Infrastructure.Persistence.Data;
using MachineFinder.Infrastructure.Repositories;

namespace MachineFinder.Infrastructure
{
    public static class InfrastructureServiceRegistration
    {
        public static IServiceCollection AddInfrastructureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("AppDBContext")!)
            );

            // services.AddScoped<IUnitOfWork, UnitOfWork>();
            // services.AddScoped(typeof(IAsyncRepository<>), typeof(RepositoryBase<>));

            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped<IBuilderRepository, BuilderRepository>();
            services.AddScoped<ICuentaRepository, CuentaRepository>();
            services.AddScoped<IDocumentoRepository, DocumentoRepository>();
            services.AddScoped<ILicenciaRepository, LicenciaRepository>();
            services.AddScoped<IRegisterRepository, RegisterRepository>();
            services.AddScoped<ITipoMaquinariaRepository, TipoMaquinariaRepository>();

            return services;
        }
    }
}
