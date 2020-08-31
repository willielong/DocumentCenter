using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using System.Threading.Tasks;
using Autofac;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Filter;
using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;

namespace DocumentServer.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddCors();
            ///添加json序列化         
            services.AddMvc(options => { options.Filters.Add(typeof(CustomExceptionFilter)); });
            AutoFacConfig.AddDBContext(services);
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
            ///配置jwt授权
            AutoFacConfig.AddJWTAuthorization(services);
            //注入授权Handler
            services.AddSingleton<IAuthorizationHandler, CustomAuthorize>();
            services.AddDistributedMemoryCache();
            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(50);
            });
            ////添加接口文档自动生成第三方键
            SwaggerConfig.AddSwagger(services);            ///注入Session服务
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            ///添加接口版本管理中间件
            ApiVersionConfig.AddApiVersioning(services);
            ///注入log4net
            var repository = LogManager.CreateRepository(ServiceLocator.log4netRepositoryName);
            XmlConfigurator.Configure(repository, new FileInfo("Config\\log4net.config"));
            services.AddScoped<IDbConnection, MySqlConnection>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(builder =>
            {
                builder.AllowAnyHeader();
                builder.AllowAnyMethod();
                //允许所有的来源地址跨域访问
                builder.AllowAnyOrigin();
            });
            app.UseAuthentication();//配置授权
            app.UseAuthorization();
            app.UseSwagger();
            app.UseStaticFiles();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "文档中心接口文档 v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "文档中心接口文档 v2");
                c.RoutePrefix = string.Empty;
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AutoFacConfig.GetAssmenBlys()).InstancePerLifetimeScope()
                .AsImplementedInterfaces();
            //注册仓储，所有IRepository接口到Repository的映射
            //builder.RegisterGeneric(typeof(Repository<>))
            //    //InstancePerDependency：默认模式，每次调用，都会重新实例化对象；每次请求都创建一个新的对象；
            //    .As(typeof(IRepository<>)).InstancePerDependency();
            //builder.RegisterModule(new AutoFacModule());
        }
    }
}
