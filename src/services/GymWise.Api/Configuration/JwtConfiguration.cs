﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GymWise.Api.Configuration
{
    public static class JwtConfiguration
    {
        public static IServiceCollection AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            TokenConfiguration appSettings = GetAppSettings(services, configuration);

            var key = Encoding.ASCII.GetBytes(appSettings.Secret);

            services.Configure<IdentityOptions>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.SignIn.RequireConfirmedEmail = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 6;
            });

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = TokenValidationParametersConfiguration(services, configuration);
            });

            return services;
        }

        public static TokenValidationParameters TokenValidationParametersConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection(TokenConfiguration.SectionName);
            var appSettings = appSettingsSection.Get<TokenConfiguration>();

            ArgumentException.ThrowIfNullOrEmpty(nameof(appSettingsSection));
            ArgumentException.ThrowIfNullOrEmpty(nameof(appSettings));

            var key = Encoding.ASCII.GetBytes(appSettings!.Secret);
            return new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidAudience = appSettings.ValidIn,
                ValidIssuer = appSettings.Issuer,
                RequireExpirationTime = true,
            };
        }

        public static TokenConfiguration GetAppSettings(IServiceCollection services, IConfiguration configuration)
        {
            var appSettingsSection = configuration.GetSection(TokenConfiguration.SectionName);
            ArgumentNullException.ThrowIfNull(nameof(appSettingsSection));
            services.Configure<TokenConfiguration>(appSettingsSection);
            var appSettings = appSettingsSection.Get<TokenConfiguration>();

            return appSettings!;
        }
    }
}
