using Application.Interfaces;
using Asagram.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi;
using Microsoft.Extensions.DependencyInjection;
using Service;
using System.Text;
using Repository;
//using Microsoft.OpenApi.Models;




namespace Asagram.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureAuthService(this IServiceCollection services) =>
            services.AddScoped<IAuthenticationService, AuthenticationService>();

        public static void ConfigureUserService(this IServiceCollection services) =>
            services.AddScoped<IUserService, UserService>();

        public static void ConfigureRepositoryService(this IServiceCollection services) =>
            services.AddScoped<IRepositoryContext, RepositoryContext>();

        public static void ConfigureFileService(this IServiceCollection services) =>
            services.AddScoped<IfileService, FileService>();


        public static void ConfigureJWT(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSettings = configuration.GetSection("JWT");
            var secretKey = Encoding.UTF8.GetBytes(jwtSettings["Key"]);

            services.AddAuthentication(opt =>
            {
                opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,

                    ValidIssuer = jwtSettings["validIssuer"],
                    ValidAudience = jwtSettings["validAudience"],
                    IssuerSigningKey = new SymmetricSecurityKey(secretKey)
                };
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "ASAGram API",
                    Version = "v1"
                });


                s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Place to add JWT with Bearer",
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });
                //s.AddSecurityRequirement(new OpenApiSecurityRequirement()
                //{
                //    {
                //        new OpenApiSecurityScheme
                //        {
                //            Reference = new OpenApiReference
                //            {
                //                    Type = ReferenceType.SecurityScheme,
                //                    Id = "Bearer"

                //            },
                //            Name = "Bearer",
                //        },
                //        new List<string>()
                //    }
                //});


            });
        }
    }
}
