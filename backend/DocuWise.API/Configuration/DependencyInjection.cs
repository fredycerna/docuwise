using DocuWise.API.Application.Interfaces;
using DocuWise.API.Application.Services;

namespace DocuWise.API.Configuration;

public static class DependencyInjection
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IDocumentService, DocumentService>();
        services.AddScoped<IStorageService, FakeStorageService>();
        return services;
    }
}