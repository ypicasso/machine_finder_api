﻿using MachineFinder.Application.Models.Identity;
using MachineFinder.Domain.DTO.Common;
using MachineFinder.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace MachineFinder.Infrastructure
{
    public static class IdentityServiceRegistration
    {
        public static IServiceCollection AddInfrastructureServices(
            this IServiceCollection services,
            IConfiguration configuration
            )
        {
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));
            services.Configure<EmailSettings>(configuration.GetSection("EmailSettings"));
            services.Configure<StringSecurity>(configuration.GetSection("StringSecurity"));

            services
                .AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(c =>
                {
                    c.RequireHttpsMetadata = false;
                    c.SaveToken = true;
                    c.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(configuration["JwtSettings:Key"]!)),

                        ClockSkew = TimeSpan.FromDays(1),
                    };
                });

            //var securitySettings = configuration.GetSection("StringSecurity").Get<StringSecurity>();

            //Constants.CRYPTO_KEY = securitySettings.Key;
            //Constants.CRYPTO_VECTOR = securitySettings.Vector;

            services.AddSingleton<EncryptionService>();
            services.AddSingleton<FileProcessor>();
            services.AddSingleton<BaseEmailer>();
            services.AddSingleton<LicenciaService>();

            return services;
        }
    }
}
