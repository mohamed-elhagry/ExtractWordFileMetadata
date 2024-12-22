using ExtractWordFileMetadata.Application.UseCases;
using Microsoft.Extensions.DependencyInjection;


namespace ExtractWordFileMetadata.Application
{
    public static class DependncyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IProcessFileUseCase, ProcessFileUseCase>();

            return services;
        }
    }
}
