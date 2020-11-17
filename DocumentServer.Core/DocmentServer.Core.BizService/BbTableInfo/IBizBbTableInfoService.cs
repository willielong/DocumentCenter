using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocmentServer.Core.BizService.BbTableInfo
{
    /// <summary>
    /// 描述：表结构信息操作类-接口
    /// </summary>
    public interface IBizBbTableInfoService
    {
        /// <summary>
        /// 添加数据表信息
        /// </summary>
        /// </summary>
        /// <param name="model">数据表实体</param>
        /// <returns></returns>
        IResponseMessage Add(Bb_TableInfo model);
        /// <summary>
        /// 修改数据表信息
        /// </summary>
        /// </summary>
        /// <param name="model">数据表实体</param>
        /// <returns></returns>
        IResponseMessage Update(Bb_TableInfo model);

        /// <summary>
        /// 获取数据表信息
        /// </summary>
        /// </summary>
        /// <param name="model">数据表实体</param>
        /// <returns></returns>
        IResponseMessage Get(object id);

        /// <summary>
        /// 获取所有数据表数据
        /// </summary>
        /// <returns></returns>
        IResponseMessage All();
        /// <summary>
        /// 禁用启用
        /// </summary>
        /// <param name="autoid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        IResponseMessage OperationEnable(object autoid, bool enable);
        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="autoid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        IResponseMessage LogicDelete(object autoid);
    }
}
