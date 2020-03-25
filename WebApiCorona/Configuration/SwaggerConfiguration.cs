using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.IO;

namespace WebApiCorona.Configuration
{
    public static class SwaggerConfiguration
    {
        private static string GetDocumentName(this IConfiguration configuration) => configuration["Swagger:Document:Name"];
        private static string GetDocumentTitle(this IConfiguration configuration) => configuration["Swagger:Document:Title"];
        private static string GetDocumentVersion(this IConfiguration configuration) => configuration["Swagger:Document:Version"];
        private static string GetEndpointUrl(this IConfiguration configuration) => configuration["Swagger:Endpoint:Url"];
        private static string GetEndpointName(this IConfiguration configuration) => configuration["Swagger:Endpoint:Name"];
        private static string GetSecurity(this IConfiguration configuration) => configuration["Swagger:Security"];

        /// <inheritdoc />
        public static IServiceCollection AddSwaggerConfiguration(this IServiceCollection services, IConfiguration config)
        {
            services
                .AddSwaggerGen(c =>
                {
                    var info =
                        new OpenApiInfo
                        {
                            Title = config.GetDocumentTitle(),
                            Version = config.GetDocumentVersion()
                        };

                    var documentName = config.GetDocumentName();

                    c.SwaggerDoc(documentName, info);
                    c.AddSecurity(config);

                    var filePath =
                        Path.Combine(
                            AppContext.BaseDirectory,
                            "WebApiCorona.xml");

                    c.IncludeXmlComments(filePath);
                });

            return services;
        }

        /// <inheritdoc />
        public static IApplicationBuilder UseSwaggerConfiguration(this IApplicationBuilder app, IConfiguration config)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                var endpointUrl = config.GetEndpointUrl();
                var endpointName = config.GetEndpointName();
                c.SwaggerEndpoint(endpointUrl, endpointName);
                c.RoutePrefix = string.Empty;
            });

            return app;
        }

        private static void AddSecurity(this SwaggerGenOptions options, IConfiguration config)
        {
            if (Equals(config.GetSecurity(), "JWT"))
            {
                options.AddJwtSecurity();
            }
            else
            {
                options.AddBasicSecurity();
            }
        }

        private static void AddJwtSecurity(this SwaggerGenOptions options)
        {
            const string authType = "Bearer";
            var securityScheme =
                new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"",
                    Name = "Authorization"
                };

            options.AddSecurityDefinition(authType, securityScheme);
            
            var openApiSecurityRequirement = new OpenApiSecurityRequirement();

            options.AddSecurityRequirement(openApiSecurityRequirement);
        }

        private static void AddBasicSecurity(this SwaggerGenOptions options)
        {
            const string authType = "basic";
            var securityScheme = new OpenApiSecurityScheme { Type = SecuritySchemeType.ApiKey };

            options.AddSecurityDefinition(authType, securityScheme);

            var openApiSecurityRequirement = new OpenApiSecurityRequirement();

            options.AddSecurityRequirement(openApiSecurityRequirement);
        }
    }
}