using Consul;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using zipkin4net;
using zipkin4net.Middleware;
using zipkin4net.Tracers.Zipkin;
using zipkin4net.Transport.Http;

namespace DocumentServer.Core.Comm
{
    /// <summary>
    /// 进行Consul扩展
    /// </summary>
    public static class ConsulModule
    {
        /// <summary>
        /// 进行注册
        /// </summary>
        /// <param name="app"></param>
        /// <param name="lifetime"></param>
        /// <param name="consul"></param>
        /// <returns></returns>
        public static IApplicationBuilder RegisterConsul(this IApplicationBuilder app, IApplicationLifetime lifetime, Consul  consul)
        {
            var consulClient = new ConsulClient(x => x.Address = new Uri($"http://{consul.Service.Address}:{consul.Service.Port}"));//请求注册的 Consul 地址
            var httpCheck = new AgentServiceCheck()
            {
                DeregisterCriticalServiceAfter = TimeSpan.FromSeconds(5),//服务启动多久后注册
                Interval = TimeSpan.FromSeconds(10),//健康检查时间间隔，或者称为心跳间隔
                HTTP = $"http://{consul.Api.Address}:{consul.Api.Port}/api/health/get",//健康检查地址
                Timeout = TimeSpan.FromSeconds(5)
            };

            // Register service with consul
            var registration = new AgentServiceRegistration()
            {
                Checks = new[] { httpCheck },
                ID = Guid.NewGuid().ToString(),
                Name =consul.Api.Name,
                Address = consul.Api.Address,
                Port = consul.Api.Port,
                Tags = new[] { $"urlprefix-/{consul.Api.Name}" }//添加 urlprefix-/servicename 格式的 tag 标签，以便 Fabio 识别
            };

            consulClient.Agent.ServiceRegister(registration).Wait();//服务启动时注册，内部实现其实就是使用 Consul API 进行注册（HttpClient发起）
            lifetime.ApplicationStopping.Register(() =>
            {
                consulClient.Agent.ServiceDeregister(registration.ID).Wait();//服务停止时取消注册
            });

            return app;
        }

        public static void RegisterZipKinTrace(this IApplicationBuilder app, ILoggerFactory loggerFactory, IApplicationLifetime lifetime)
        {

            lifetime.ApplicationStarted.Register(() => {
                TraceManager.SamplingRate = 1.0f;
                var httpSender = new HttpZipkinSender("http://10.55.165.222:9411/","application/json");
                var logger = new TracingLogger(loggerFactory, "zipkin4net");
                var tracer = new ZipkinTracer(httpSender, new JSONSpanSerializer(), new Statistics());
                var conloseTracer = new zipkin4net.Tracers.ConsoleTracer();
                TraceManager.RegisterTracer(tracer);
                TraceManager.RegisterTracer(conloseTracer);
                TraceManager.Start(logger);
            });
            lifetime.ApplicationStopped.Register(() => TraceManager.Stop());
            app.UseTracing("de1");
        }
    }
}
