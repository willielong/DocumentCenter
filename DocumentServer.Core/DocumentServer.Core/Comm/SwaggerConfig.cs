
using DocumentServer.Core.Model.OnlyOfficeConfigModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
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
        public static void AddSwagger(IServiceCollection services, IConfiguration configuration)
        {
            ApiVersionsConfig ApiConfig = configuration.Get<ApiVersionsConfig>();
            services.AddSwaggerGen(c =>
            {
                foreach (var item in ApiConfig.ApiVersions)
                {
                    string ver = string.Format("v{0}", item.version);
                    c.SwaggerDoc(ver, new Microsoft.OpenApi.Models.OpenApiInfo
                    {
                        Version = ver,
                        Title = "Document Server Rest API " + ver,
                        Description = "文档中心" + ver,
                        TermsOfService = null,
                        Contact = new Microsoft.OpenApi.Models.OpenApiContact { Name = "willie li", Email = "", Url = new Uri("http://localhost:86/") },

                    });
                }
                //Set the comments path for the swagger json and ui.
                var basePath = Path.GetDirectoryName(AppContext.BaseDirectory);
                var xmlPath = Path.Combine(basePath, "ApiCore.xml");
                c.IncludeXmlComments(xmlPath);
                AddSecurityDefinition(c);
                AddSecurityRequirement(c);
                DocInclusionPredicate(c);
                c.OperationFilter<HttpHeaderOperation>();
                //c.DocumentFilter<SetVersionInPathDocumentFilter>();
            });
            ;
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
                Description = "请输入身份验证码",
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
    /// <summary>
    /// 替换路由中的版本
    /// </summary>
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
            //var versionParameter = operation.Parameters.Single(p => p.Name == "version");
            ///operation.Parameters.Remove(versionParameter);
        }
    }
    /// <summary>
    /// 接口添加版本号
    /// </summary>
    public class HttpHeaderOperation : IOperationFilter
    {
        public void Apply(OpenApiOperation operation, OperationFilterContext context)
        {
            operation.Parameters.Add(new OpenApiParameter()
            {
                Name = "x-api-version",  //添加Authorization头部参数
                In = ParameterLocation.Header,
                Required = true,
                Description = "请输入接口版本号"
            });
        }
    }
}
