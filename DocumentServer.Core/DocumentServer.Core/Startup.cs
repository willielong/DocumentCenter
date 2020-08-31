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
            ///���json���л�         
            services.AddMvc(options => { options.Filters.Add(typeof(CustomExceptionFilter)); });
            AutoFacConfig.AddDBContext(services);
            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));
            ///����jwt��Ȩ
            AutoFacConfig.AddJWTAuthorization(services);
            //ע����ȨHandler
            services.AddSingleton<IAuthorizationHandler, CustomAuthorize>();
            services.AddDistributedMemoryCache();
            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(50);
            });
            ////��ӽӿ��ĵ��Զ����ɵ�������
            SwaggerConfig.AddSwagger(services);            ///ע��Session����
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            ///��ӽӿڰ汾�����м��
            ApiVersionConfig.AddApiVersioning(services);
            ///ע��log4net
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
                //�������е���Դ��ַ�������
                builder.AllowAnyOrigin();
            });
            app.UseAuthentication();//������Ȩ
            app.UseAuthorization();
            app.UseSwagger();
            app.UseStaticFiles();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "�ĵ����Ľӿ��ĵ� v1");
                c.SwaggerEndpoint("/swagger/v2/swagger.json", "�ĵ����Ľӿ��ĵ� v2");
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
            //ע��ִ�������IRepository�ӿڵ�Repository��ӳ��
            //builder.RegisterGeneric(typeof(Repository<>))
            //    //InstancePerDependency��Ĭ��ģʽ��ÿ�ε��ã���������ʵ��������ÿ�����󶼴���һ���µĶ���
            //    .As(typeof(IRepository<>)).InstancePerDependency();
            //builder.RegisterModule(new AutoFacModule());
        }
    }
}
