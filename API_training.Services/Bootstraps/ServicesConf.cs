using API_training.Services.Interfaces;
using API_training.Services.Services;
using Microsoft.Extensions.DependencyInjection;


namespace API_training.Services.Bootstraps
{
    public static class ServicesConf
    {
        public static void ConfigureServices(this IServiceCollection services)
        {
            services.AddTransient<IBooksInterface, BooksService>();
        }
    }
}
