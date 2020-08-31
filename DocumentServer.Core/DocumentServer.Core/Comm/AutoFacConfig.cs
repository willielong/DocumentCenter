
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

using log4net;
using log4net.Config;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ApplicationParts;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Unicode;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Builder;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Filter;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.Extensions.PlatformAbstractions;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc.Versioning;

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
    }
}
