using DocumentServer.Core.Model.DbModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DocumentServer.Core.Comm;
using MySql.Data.MySqlClient;
using AutoMapper;
using Consul;
using DocumentServer.Core.Model.OnlyOfficeConfigModel;
using Microsoft.Extensions.Configuration;

namespace DocumentServer.Core.Infrastrure
{
    public class ConnectionBase : IConnectionBase
    {
        public ConnectionBase(IDbConnection _dbConnection, IHttpContextAccessor httpContext, IMapper _mapper, IConfiguration configuration)
        {
            CurrentUser = new DocumentServer.Core.Model.DbModel.Employee();
            CurrentUser = httpContext != null ? (httpContext.HttpContext.User.ToUser<Employee>() ?? CurrentUser) : CurrentUser;
            if (null == dbConnection)
                dbConnection = _dbConnection;
            if (tenantConnection == null)
                tenantConnection = new MySqlConnection("Database=DocumentServerDb;Data Source=127.0.0.1;User Id=root;Password=123456Aa;CharSet=utf8;port=3306");
            httpContextAccessor = httpContext;
            mapper = _mapper;

            InitConsulClients(configuration.Get<ApiVersionsConfig>());
        }

        /// <summary>
        /// 调用服务组件
        /// </summary>
        private void InitConsulClients(ApiVersionsConfig config)
        {
            //var consulClient = new ConsulClient(c => c.Address = new Uri($"http://{config.Consul.Service.Address}:{config.Consul.Service.Port}"));
            //consulClents = new Dictionary<string, string>();
            //var queryResult = consulClient.Health.Service(config.Consul.Api.Name, string.Empty, true);
            //var result = new List<string>();
            //foreach (var serviceEntry in queryResult.Result.Response)
            //{
            //    result.Add(serviceEntry.Service.Address + ":" + serviceEntry.Service.Port);
            //}
        }

        /// <summary>
        /// 主库数据库链接
        /// </summary>
        public IDbConnection dbConnection { get; set; }
        /// <summary>
        /// 租户库数据库链接
        /// </summary>
        public IDbConnection tenantConnection { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public Employee CurrentUser { get; set; }
        /// <summary>
        /// 请求信息
        /// </summary>
        public IHttpContextAccessor httpContextAccessor { get; set; }
        /// <summary>
        /// 数据映射
        /// </summary>
        public IMapper mapper { get; set; }
        public Dictionary<string, string> consulClents { get; set; }
    }
}
