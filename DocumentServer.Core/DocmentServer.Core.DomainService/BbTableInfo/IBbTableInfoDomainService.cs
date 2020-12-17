using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.DomainService.BbTableInfo
{
    /// <summary>
    /// 描述：表结构信息操作类-接口
    /// </summary>
    public interface IBbTableInfoDomainService : Base.IBaseDomainService
    {
        /// <summary>
        /// 禁用启用
        /// </summary>
        /// <param name="autoid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        bool OperationEnable(object autoid, bool enable, IDbTransaction transaction = null);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="autoid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        bool LogicDelete(object autoid, IDbTransaction transaction = null);
    }
}
