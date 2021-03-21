using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;

namespace MessagingService.API.Infrastructure
{
    public static class SwaggerServiceExtensions
    {
        public static IServiceCollection AddSwaggerDocumentation(this IServiceCollection services)
        {
            services.AddSwaggerGen(swg =>
           {
               var securityScheme = new OpenApiSecurityScheme
               {
                   Name = "JWT Authentication",
                   Description = "Enter the JWT Bearer token ",
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
               swg.AddSecurityDefinition(securityScheme.Reference.Id, securityScheme);

               swg.AddSecurityRequirement(new OpenApiSecurityRequirement
               {
                   {securityScheme, new string[] {} }
               });
           });

            
            return services;
            
        }

        public static IApplicationBuilder UseSwaggerDocumentation(this IApplicationBuilder app)
        {
            app.UseSwagger();
            app.UseSwaggerUI();

            return app;
        }
    }
}
