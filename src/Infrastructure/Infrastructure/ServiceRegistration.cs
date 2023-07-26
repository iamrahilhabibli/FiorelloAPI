using Fiorello.Application.Abstraction.Services;
using Fiorello.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;

namespace Fiorello.Infrastructure;

public static class ServiceRegistration
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddScoped<IUploadFile, UploadFile>();
    }
}
