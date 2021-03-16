using DocumentServer.Core.Model.DbModel;
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
    }
}
