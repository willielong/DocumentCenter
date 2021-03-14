
/****************************************************************************
* 类名：AutoFacConfig
* 描述：将第三方的组件接管到程序
* 创建人：Author
* 创建时间：2019.10.08 10:00
* 修改人;Author
* 修改时间：2019.10.08 10:00
* 修改描述：1、添加反射及读写分离的数据库操作
*           2、添加身份认证-jwt授权
*           3、添加AUTOFAC属性依赖注入
*           4、将Bootstrpper中复杂的代码拆到方法中
* **************************************************************************
*/

using Autofac;
using AutoMapper;
using DocumentServer.Core.Filter;
using DocumentServer.Core.Model.OnlyOfficeConfigModel;
//using log4net;
//using log4net.Config;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.FileProviders;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;

namespace DocumentServer.Core.Comm
{

    public class AutoFacConfig
    {

        /// <summary>
        /// 配置JWT授权
        /// </summary>
        /// <param name="services"></param>
        public static void AddJWTAuthorization(IServiceCollection services)
        {
            ServiceLocator.tokenHelper = GetTokenHelper();

            var skey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(ServiceLocator.tokenHelper.TokenSecreKey));
            var signingCredentials = new SigningCredentials(skey, SecurityAlgorithms.HmacSha256);

            services.AddAuthorization(opt =>
            {
                var permissionRequirement = new CustomAauthorizeRequirement(ClaimTypes.Role, signingCredentials);
                opt.AddPolicy("CustomAuthorize", policy => policy.Requirements.Add(permissionRequirement));
            }).AddAuthentication(option =>
            {
                option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;

            }).AddJwtBearer((jwtOptions) =>
            {
                jwtOptions.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = skey,
                    ValidateIssuer = true,
                    ValidIssuer = ServiceLocator.tokenHelper.Issuer,
                    ValidateAudience = true,
                    ValidAudience = ServiceLocator.tokenHelper.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }

        /// <summary>
        /// 添加数据库链接全局服务
        /// </summary>
        /// <param name="services"></param>
        public static void AddDBContext(IServiceCollection services)
        {
            ///获取数据连接
            var dbConnection = GetDbBaseConnection();
            services.AddSingleton(dbConnection.my_write_connection);
        }



        /// <summary>
        /// 返回需要依赖注入的接口
        /// </summary>
        /// <returns></returns>
        public static Assembly[] GetAssmenBlys()
        {
            IConfigFile con = new GeneralConfFileOperator();
            Assemblys assembly = new Assemblys();
            string path = Directory.GetCurrentDirectory() + "\\Config\\Assemblys.xml";
            assembly = con.ReadConfFile<Assemblys>(path, false);
            List<Assembly> assemblys = new List<Assembly>();
            if (assembly.childs.Count > 0)
            {
                foreach (var item in assembly.childs)
                {
                    assemblys.Add(Assembly.Load(item));
                }

            }
            return assemblys.ToArray();
        }

        /// <summary>
        /// 读取配置文件
        /// </summary>
        /// <returns></returns>
        public static DBHelper GetDbBaseConnection()
        {
            DBHelper dbConnection = new DBHelper();
            IConfigFile con = new GeneralConfFileOperator();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Config", "DBHelper.xml");
            dbConnection = con.ReadConfFile<DBHelper>(path, false);
            return dbConnection;
        }
        /// <summary>
        /// 获取生成Token的配置
        /// </summary>
        /// <returns></returns>
        public static TokenHelper GetTokenHelper()
        {
            TokenHelper tokenHelper = new TokenHelper();
            IConfigFile con = new GeneralConfFileOperator();
            string path = Path.Combine(Directory.GetCurrentDirectory(), "Config", "TokenHelper.xml");
            tokenHelper = con.ReadConfFile<TokenHelper>(path, false);
            return tokenHelper;
        }

        /// <summary>
        /// 进行控制器依赖注入
        /// </summary>
        /// <param name="builder"></param>
        /// <param name="services"></param>
        public static void RegisterAutoFacController(ContainerBuilder builder)
        {
            var manager = new ApplicationPartManager();
            manager.ApplicationParts.Add(new AssemblyPart(Assembly.Load("DocumentServer.Core")));
            manager.FeatureProviders.Add(new ControllerFeatureProvider());
            var feature = new ControllerFeature();
            manager.PopulateFeature(feature);
            builder.RegisterTypes(feature.Controllers.Select(ti => ti.AsType()).ToArray()).PropertiesAutowired();
        }

        /// <summary>
        /// 特殊注入
        /// </summary>
        /// <param name="builder"></param>
        public static void RegisterSpecial(ContainerBuilder builder)
        {
            //           builder.RegisterGeneric(typeof(WriteRepository<>)).As(typeof(IWriteRepository<>))//单个注入
            //  .InstancePerDependency().PropertiesAutowired(PropertyWiringOptions.AllowCircularDependencies).SingleInstance();///属性注入
            //           builder.RegisterGeneric(typeof(ReadRepository<>)).As(typeof(IReadRepository<>))//单个注入
            //.InstancePerDependency().PropertiesAutowired().PropertiesAutowired();///属性注入
        }
        /// <summary>
        /// 进行服务注册
        /// </summary>
        public static void RegisterService(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddJsonOptions(o => { o.JsonSerializerOptions.Encoder = JavaScriptEncoder.Create(UnicodeRanges.All); });

            services.AddCors();
            services.AddAutoMapper(Assembly.Load("DocumentServer.Core.Mapper"));
            ///添加json序列化         
            services.AddMvc(options => { options.Filters.Add(typeof(CustomExceptionFilter)); });

            ///注册数据库链接Configure
            AddDBContext(services);

            services.AddSingleton(HtmlEncoder.Create(UnicodeRanges.All));

            ///配置jwt授权
            AddJWTAuthorization(services);

            //注入授权Handler
            services.AddSingleton<IAuthorizationHandler, CustomAuthorize>();
            services.AddDistributedMemoryCache();

            services.AddSession(opt =>
            {
                opt.IdleTimeout = TimeSpan.FromMinutes(50);
            });
            ////添加接口文档自动生成第三方键
            SwaggerConfig.AddSwagger(services, configuration);

            ///注入Session服务
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            ///添加接口版本管理中间件
            ApiVersionConfig.AddApiVersioning(services);

            /////注入log4net
            //var repository = LogManager.CreateRepository(ServiceLocator.log4netRepositoryName);
            //XmlConfigurator.Configure(repository, new FileInfo("Config\\log4net.config"));

            ///注册数据库服务
            services.AddScoped<IDbConnection, MySqlConnection>();
            services.AddScoped<ICustomDbConnection, CustomDbConnection>();

            ///返回数据验证器数据
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.InvalidModelStateResponseFactory = actionContext =>
                {
                    //获取验证失败的模型字段 
                    var errors = actionContext.ModelState
                        .Where(e => e.Value.Errors.Count > 0)
                        .Select(e => new { field = e.Key, err = e.Value.Errors.Select(o => o.ErrorMessage) })
                        .ToList();
                    //设置返回内容
                    DTO_ResponseMessage result = new DTO_ResponseMessage
                    {
                        Status = false,
                        Message = "未通过数据验证",
                        Body = errors
                    };
                    return new BadRequestObjectResult(result);
                };
            });
        }

        public static void RegisterConfigure(IApplicationBuilder app, IHostEnvironment env, IConfiguration configuration)
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

            var ApiConfig = configuration.Get<ApiVersionsConfig>();
            FilePath path = ApiConfig.FilePath;

            ///使用静态文件目录
            app.UseStaticFiles(new StaticFileOptions()
            {
                FileProvider = new PhysicalFileProvider(path.PhysicalFilePath),
                RequestPath = path.ApiFilePath
            });

            ///使用swagger UI
            app.UseSwaggerUI(c =>
            {
                ApiConfig.ApiVersions.ForEach(a =>
                {
                    c.SwaggerEndpoint(string.Format("/swagger/v{0}/swagger.json", a.version), string.Format("Document center interface document v{0}", a.version));
                });
                c.RoutePrefix = string.Empty;
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
