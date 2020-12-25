using System;
using System.Reflection;
using System.Text;
using API_training.Common;
using API_training.Controllers;
using API_training.DAL.Bootstrap;
using API_training.Infrastructure;
using API_training.Repositories;
using API_training.Repositories.Bootstrap;
using API_training.Services;
using API_training.Services.Bootstrap;
using API_training.Services.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace API_training
{
    /// <summary>
    /// Конфигурация приложения
    /// </summary>
    public class Startup
    {
        
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
            services.ConfigureDb(Configuration);
            services.ConfigureRepositories();
            services.AddControllers();
            services.ConfigureServices();
            services.AddAutoMapper(
                typeof(BooksRepository).GetTypeInfo().Assembly, 
                typeof(BooksController).GetTypeInfo().Assembly
            );
           // services.ConfigureSwagger();
            var JwtToken = Configuration.GetSection("JwtToken").Get<JwtToken>();
            JwtToken.Secret = Configuration["secret"];
            services.AddSingleton(JwtToken);
            
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = JwtToken.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtToken.Secret)),
                    ValidAudience = JwtToken.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });
            services.AddSingleton<IJwtAuthManager, JwtAuthManager>();
            services.AddHostedService<JwtRefreshTokenCache>();
            services.AddScoped<IUserService, UserService>();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "API", Version = "v1" });

                var securityScheme = new OpenApiSecurityScheme
                {
                    Name = "JWT Authentication",
                    Description = "Enter JWT Bearer token",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer",
                    BearerFormat = "JWT",
                    Reference = new OpenApiReference
                    {
                        Id = JwtBearerDefaults.AuthenticationScheme,
                        Type = ReferenceType.SecurityScheme
                    }
                };
                c.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {securityScheme, new string[] { }}
                });
            });

            services.AddCors(options =>
            {
                options.AddPolicy("AllowJwt",
                    builder =>
                    {
                        // white list
                        builder.WithOrigins("http://localhost:4200");
                        // we have only 3 methods in app, add its.
                        builder.WithMethods("GET", "POST");
                        // in request head
                        builder.AllowAnyHeader();
                        // lifetime
                        builder.SetPreflightMaxAge(TimeSpan.FromSeconds(2520));
                    });
            });
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
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./swagger/v1/swagger.json", "API");
                c.DocumentTitle = "API";
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseCors("AllowJwt");
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}
