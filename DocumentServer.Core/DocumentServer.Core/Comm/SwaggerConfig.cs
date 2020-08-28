using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentServer.Core.Comm
{
    public class SwaggerConfig
    {
        /// <summary>
        /// 配置Swagger
        /// </summary>
        /// <param name="services"></param>
        public static void AddSwagger(IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v1",
                    Title = "Document Server Rest API v1",
                    Description = "文档中心v1",
                    TermsOfService = null,
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "willie li", Email = "", Url = new Uri("http://localhost:86/") },

                });
                c.SwaggerDoc("v2", new Microsoft.OpenApi.Models.OpenApiInfo
                {
                    Version = "v2",
                    Title = "Document Server Rest API v2",
                    Description = "文档中心v2",
                    TermsOfService = null,
                    Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "willie li", Email = "", Url = new Uri("http://localhost:86/") },

                });

                //Set the comments path for the swagger json and ui.
                var basePath = Path.GetDirectoryName(AppContext.BaseDirectory);
                var xmlPath = Path.Combine(basePath, "ApiCore.xml");
                c.IncludeXmlComments(xmlPath);
                AddSecurityDefinition(c);
                AddSecurityRequirement(c);
                DocInclusionPredicate(c);
                //c.OperationFilter<RemoveVersionParameterOperationFilter>();
                c.DocumentFilter<SetVersionInPathDocumentFilter>();
            });
        }
        /// <summary>
        /// 添加定义
        /// </summary>
        /// <param name="options"></param>
        private static void AddSecurityDefinition(SwaggerGenOptions options)
        {
            // Add security definitions
            options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
            {
                Description = "Please enter into field the word 'Bearer' followed by a space and the JWT value",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
            });
        }
        /// <summary>
        /// 添加认证
        /// </summary>
        /// <param name="options"></param>
        private static void AddSecurityRequirement(SwaggerGenOptions options)
        {
            options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    { new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference()
                            {
                                Id = "Bearer",
                                Type = ReferenceType.SecurityScheme
                            }
                        }, Array.Empty<string>()
                    }
                });
        }

        /// <summary>
        /// 加载多版本
        /// </summary>
        /// <param name="option"></param>
        private static void DocInclusionPredicate(SwaggerGenOptions option)
        {
            option.DocInclusionPredicate((docName, apiDesc) =>
               {
                   var versions = apiDesc.CustomAttributes()
                       .OfType<ApiVersionAttribute>()
                       .SelectMany(attr => attr.Versions);

                   return versions.Any(v => $"v{v.ToString()}" == docName);
               });
        }
    }
    public class SetVersionInPathDocumentFilter : IDocumentFilter
    {
        public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
        {
            var updatedPaths = new OpenApiPaths();

            foreach (var entry in swaggerDoc.Paths)
            {
                updatedPaths.Add(
                    entry.Key.Replace("v{version}", swaggerDoc.Info.Version),
                    entry.Value);
            }

            swaggerDoc.Paths = updatedPaths;
        }
    }

    public class RemoveVersionParameterOperationFilter : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            // Remove version parameter from all Operations
            var versionParameter = operation.Parameters.Single(p => p.Name == "version");
            operation.Parameters.Remove(versionParameter);
        }
    }
}
