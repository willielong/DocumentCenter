using AutoMapper;
using DocumentServer.Core.Model.DbModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocumentServer.Core.Infrastrure
{
    public interface IConnectionBase
    {
        /// <summary>
        /// 主库数据库链接
        /// </summary>
        IDbConnection dbConnection { get; set; }
        /// <summary>
        /// 租户库数据库链接
        /// </summary>
        IDbConnection tenantConnection { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        Employee CurrentUser { get; set; }
        IHttpContextAccessor httpContextAccessor { get; set; }
        IMapper mapper { get; set; }
        /// <summary>
        /// 调用服务器组件
        /// </summary>
        Dictionary<string,string> consulClents { get; set; }
    }
}
