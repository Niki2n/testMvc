using System.Configuration;
using TestMvc.Interfaces;
using TestMvc.Options;
using TestMvc.Services;

namespace TestMvc.Extentions
{
    public static class ConfigurationExtention
    {
        public static IServiceCollection AddClientConfiguration(this IServiceCollection services, ApiOptions options)
        {

            services.AddScoped<ICatalogService, CatalogService>();
            //services.AddScoped<IElementService, ElementService>();

            services.AddHttpClient(ApiOptions.ClientName, client =>
            {
                client.BaseAddress = new Uri(options.Host);
                client.Timeout = TimeSpan.FromSeconds(5);
            });
            return services;
        }
    }
}
