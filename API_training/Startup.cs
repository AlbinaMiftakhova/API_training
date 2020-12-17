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
    /// ������������ ����������
    /// </summary>
    public class Startup
    {
        private string _connection = null;

        /// <summary>
        /// �������������� ����� ��������� ������ <see cref="Startup"/>.
        /// </summary>
        /// <param name="configuration">������������</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        /// <summary>
        /// ������������
        /// </summary>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// M���� ���������� ������ ����������. ������������ ��� ����������� �������� � IoC ����������
        /// </summary>
        /// <param name="services">��������� ��������</param>
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
        /// M���� ���������� ������ ����������. ������������ ��� ������������ ��������� ��� ��������� HTTP �������
        /// </summary>
        /// <param name="app">�������� ������������ ����������</param>
        /// <param name="env">���������� �� ���������, � ������� �������� ����������</param>
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
