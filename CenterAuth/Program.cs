using AutoMapper;
using CenterAuth.Repositories;
using Microsoft.EntityFrameworkCore;

namespace CenterAuth
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var configuration = builder.Configuration;
            // Configure services in my ServiceExtension class
            builder.Services.ConfigureDatabase(configuration);
            builder.Services.ConfigureDependencies();
            builder.Services.ConfigureSwagger();
            builder.Services.ConfigureJwtAuthentication(configuration);

            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddAutoMapper(typeof(StartupBase));
            builder.Services.AddEndpointsApiExplorer();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CenterAuth API v1"));
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}