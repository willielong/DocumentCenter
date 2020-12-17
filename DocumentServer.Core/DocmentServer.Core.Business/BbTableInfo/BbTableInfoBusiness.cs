using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
/**
 * 描述：表结构信息操作类-实现
 * 
 * 
 * */
namespace DocmentServer.Core.Business.BbTableInfo
{
    public class BbTableInfoBusiness : Base.BaseBusiness, IBbTableInfoBusiness
    {
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="_dbConnection"></param>
        public BbTableInfoBusiness(IDbConnection _dbConnection) : base(_dbConnection)
        {

        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="autoid"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool LogicDelete(object autoid, IDbTransaction transaction = null)
        {
            return dbConnection.Execute(sql: "UPDATE Bb_TableInfo SET isdel=@isdel WHERE auotid=@autoid", param: new DocumentServer.Core.Model.DbModel.Bb_TableInfo() { autoid = (int)autoid, isdel = true }, transaction: transaction) >= 0;
        }

        /// <summary>
        /// 禁用启用
        /// </summary>
        /// <param name="autoid"></param>
        /// <param name="enable"></param>
        /// <returns></returns>
        public bool OperationEnable(object autoid, bool enable, IDbTransaction transaction = null)
        {
            return dbConnection.Execute(sql: "UPDATE Bb_TableInfo SET enable=@enable WHERE auotid=@autoid", param: new DocumentServer.Core.Model.DbModel.Bb_TableInfo() { autoid = (int)autoid, enable = enable }, transaction: transaction) >= 0;
        }
    }
}
