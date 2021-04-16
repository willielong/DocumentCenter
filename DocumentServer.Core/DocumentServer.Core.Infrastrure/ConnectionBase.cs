using DocumentServer.Core.Model.DbModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DocumentServer.Core.Comm;
using MySql.Data.MySqlClient;
using AutoMapper;

namespace DocumentServer.Core.Infrastrure
{
    public class ConnectionBase : IConnectionBase
    {
        public ConnectionBase(IDbConnection _dbConnection, IHttpContextAccessor httpContext,IMapper _mapper)
        {
            CurrentUser = new DocumentServer.Core.Model.DbModel.Employee();
            CurrentUser = httpContext != null ? (httpContext.HttpContext.User.ToUser<Employee>() ?? CurrentUser) : CurrentUser;
            if (null == dbConnection)
                dbConnection = _dbConnection;
            if (tenantConnection == null)
                tenantConnection = new MySqlConnection("Database=DocumentServerDb;Data Source=127.0.0.1;User Id=root;Password=123456Aa;CharSet=utf8;port=3306");
            httpContextAccessor = httpContext;
            mapper = _mapper;
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
    }
}
