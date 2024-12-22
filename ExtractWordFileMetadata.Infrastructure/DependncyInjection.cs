
using ExtractWordFileMetadata.Application.Interfaces;
using ExtractWordFileMetadata.Infrastructure.Services;
using Microsoft.Extensions.DependencyInjection;


namespace ExtractWordFileMetadata.Infrastructure
{
    public static class DependncyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IReportGenerator, ReportGenerator>();
            services.AddScoped<IFileMetadataExtractor, FileMetadataExtractor>();
            return services;
        }
    }
}
