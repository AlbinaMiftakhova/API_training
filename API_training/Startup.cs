using System.Data.SqlClient;
using System.Reflection;
using API_training.Common;
using API_training.Controllers;
using API_training.DAL.Bootstrap;
using API_training.Repositories;
using API_training.Repositories.Bootstrap;
using API_training.Services.Bootstrap;
using API_training.Services.Services;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace API_training
{
    /// <summary>
    /// Конфигурация приложения
    /// </summary>
    public class Startup
    {
        private string _connection = null;

        /// <summary>
        /// Инициализирует новый экземпляр класса <see cref="Startup"/>.
        /// </summary>
        /// <param name="configuration">Конфигурация</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// Конфигурация
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Mетод вызывается средой исполнения. Используется для регистрации сервисов в IoC контейнере
        /// </summary>
        /// <param name="services">Коллекция сервисов</param>
        public void ConfigureServices(IServiceCollection services)
        {
           var builder = new SqlConnectionStringBuilder(Configuration.GetConnectionString("ApiTrainingContext"));
            builder.Password = Configuration["Password"];
            _connection = builder.ConnectionString;
            services.ConfigureDb(Configuration, _connection);
            services.ConfigureRepositories();
            services.AddControllers();
            services.ConfigureServices();
            services.AddAutoMapper(
                typeof(BooksRepository).GetTypeInfo().Assembly, 
                typeof(BooksController).GetTypeInfo().Assembly
            );
            services.ConfigureSwagger();
            
        }

        /// <summary>
        /// Mетод вызывается средой исполнения. Используется для конфигурации окружения для обработки HTTP запроса
        /// </summary>
        /// <param name="app">Средство конфигурации приложения</param>
        /// <param name="env">Информация об окружении, в котором работает приложение</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseCors();
            app.UseOpenApi();
            app.UseSwaggerUi3(); 
        }
    }
}
