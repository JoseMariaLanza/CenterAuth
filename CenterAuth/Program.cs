using AutoMapper;
using CenterAuth.Middlewares;
using CenterAuth.Repositories;
using CenterAuth.Services.Mapping;
using Microsoft.EntityFrameworkCore;
using AuthOrchestrator;

namespace CenterAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;

            // Now use the built configuration
            builder.Services.ConfigureJwtAuthentication(configuration);

            // Configure services in ServiceExtension class
            builder.Services.ConfigureDatabase(configuration);
            builder.Services.ConfigureDependencies();
            builder.Services.ConfigureSwagger();
            //builder.Services.ConfigureJwtAuthentication(configuration);
            builder.Services.ConfigurePolicies();
            builder.Services.AddRedisServices(configuration);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(StartupBase), typeof(UserProfile));
            builder.Services.AddEndpointsApiExplorer();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CenterAuth API v1"));
            }

            app.UseMiddleware<ExceptionHandlerMiddleware>();

            app.UseHttpsRedirection();

            // Jwt
            app.UseAuthentication();
            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}