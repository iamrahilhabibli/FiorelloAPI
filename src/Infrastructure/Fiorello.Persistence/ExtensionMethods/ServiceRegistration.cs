using Fiorello.Application.Abstraction.Repository;
using Fiorello.Persistence.Contexts;
using Fiorello.Persistence.Implementations.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Fiorello.Persistence.ExtensionMethods
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {
            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseSqlServer(services.BuildServiceProvider().GetService<IConfiguration>().GetConnectionString("Default"));
            });
            services.AddScoped(typeof(IReadRepository<>), typeof(ReadRepository<>));
            services.AddScoped(typeof(IWriteRepository<>), typeof(WriteRepository<>));
        }
    }
}
