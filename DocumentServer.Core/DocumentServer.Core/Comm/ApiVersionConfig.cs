
/****************************************************************************
* 类名：ApiVersionConfig
* 描述：API版本管理配置
* 创建人：Author
* 创建时间：2019.10.08 10:00
* 修改人;Author
* 修改时间：2019.10.08 10:00
* 修改描述
* **************************************************************************
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.DependencyInjection;

namespace DocumentServer.Core.Comm
{
    public class ApiVersionConfig
    { /// <summary>
      /// 配置api的版本
      /// </summary>
      /// <param name="services"></param>
        public static void AddApiVersioning(IServiceCollection services)
        {

            services.AddApiVersioning(opt =>
            {
                opt.ReportApiVersions = true;
                opt.AssumeDefaultVersionWhenUnspecified = true;
                opt.DefaultApiVersion = ApiVersion.Default;
                //opt.ApiVersionReader = new HeaderApiVersionReader("x-api-version");
                opt.ApiVersionReader = ApiVersionReader.Combine(new QueryStringApiVersionReader(), new HeaderApiVersionReader() { HeaderNames = { "api-version" } });
            });
        }
    }
}
