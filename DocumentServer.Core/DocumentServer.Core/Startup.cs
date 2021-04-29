using Autofac;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.OnlyOfficeConfigModel;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DocumentServer.Core
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration; 
        }

        public IConfiguration Configuration { get; }
        public ILoggerFactory loggerFactory { get; set; }
        /// <summary>
        /// ЗўЮёзЂВс
        /// </summary>
        /// <param name="services"></param>
        public void ConfigureServices(IServiceCollection services)
        {
            AutoFacConfig.RegisterService(services: services, configuration: this.Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApplicationLifetime lifetime)
        { 
            AutoFacConfig.RegisterConfigure(app: app, env: env, configuration: Configuration,lifetime:lifetime);           
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new AutoFacModule());
        }
    }
}
