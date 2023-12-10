using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using CenterAuth.Repositories;
using CenterAuth.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using StackExchange.Redis;
using System.Text;
using CenterAuth.Repositories.Users;
using CenterAuth.Repositories.Authorization;
using CenterAuth.Constants;
//using CenterAuth.Helpers;
using AuthOrchestrator;
using AuthOrchestrator.Jwt;
using AuthOrchestrator.Redis;
using Microsoft.Extensions.DependencyInjection;

namespace CenterAuth
{
    public static class ServiceExtensions
    {
        public static void ConfigureDatabase(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<IAuthDbContext, AuthDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("CenterAuthConnection")));
        }

        public static void ConfigureDependencies(this IServiceCollection services)
        {
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IAuthorizationManagementService, AuthorizationManagementService>();
            services.AddScoped<IJwtService, JwtService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CenterAuth API", Version = "v1" });

                // Enable Authorization in swagger
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme (Example: 'Bearer 1234abcdef')",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header
                        },
                        new List<string>()
                    }
                });
            });
        }

        public static void ConfigureJwtAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["Key"]);

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    //ValidIssuer = jwtSettings["Issuer"],
                    ValidateAudience = false,
                    //ValidAudience = jwtSettings["Audience"]
                };
            });

            services.AddScoped<IJwtService, JwtService>();
        }

        public static void ConfigurePolicies(this IServiceCollection services)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("AdminOrSiteAdmin", policy => policy.RequireRole(UserTypes.Admin.HierarchyNode, UserTypes.Staff.Management.SiteAdmin.HierarchyNode));
            });
        }

        public static void AddRedisServices(this IServiceCollection services, IConfiguration configuration)
        {
            //var redisConfig = configuration["Redis:Configuration"];
            //services.AddSingleton<IRedisHelper, RedisHelper>(sp => new RedisHelper(redisConfig));
            //services.AddTransient<IRedisService, RedisService>();

            // Configure Redis
            var redisSettings = new RedisSettings();
            configuration.GetSection("Redis").Bind(redisSettings);

            services.AddSingleton(redisSettings);
            //services.AddSingleton<IConnectionMultiplexer>(sp =>
            //    ConnectionMultiplexer.Connect(redisSettings.Configuration));

            //services.AddSingleton<IRedisHelper, RedisHelper>();
            services.AddSingleton<IRedisHelper, RedisHelper>(sp => new RedisHelper(redisSettings.Configuration));
            services.AddTransient<IRedisService, RedisService>();
        }
    }
}
