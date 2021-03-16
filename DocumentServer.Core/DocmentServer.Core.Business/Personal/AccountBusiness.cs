using Dapper;
using DocmentServer.Core.Business.Base;
using DocumentServer.Core.Infrastrure;
using DocumentServer.Core.Model.DbModel;
using System.Collections.Generic;
using System.Data;
/**
* 描述：组织信息操作类-实现* 
* */
namespace DocmentServer.Core.Business.Personal
{
    public class AccountBusiness : BaseBusiness, IAccountBusiness
    {
        public AccountBusiness(IConnectionBase _dbConnection) : base(dbConnection: _dbConnection)
        {
        }

        /// <summary>
        /// 删除账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Execute(sql: "DELETE FROM  AccoutInfo WHERE autoid=@autoid", param: new AccoutInfo() { autoid = (int)id }, transaction: transaction) >= 0;
        }
        /// <summary>
        /// 获取账户信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public List<AccoutInfo> List(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Query<AccoutInfo>(sql: "SELECT *  FROM  AccoutInfo WHERE autoid=@autoid", param: new AccoutInfo() { autoid = (int)id }, transaction: transaction).AsList();
        }
        /// <summary>
        /// 获取账户信息--多个-按工号
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public List<AccoutInfo> GetListByCode(string code, IDbTransaction transaction = null)
        {
            return dbConnection.Query<AccoutInfo>(sql: "SELECT *  FROM   AccoutInfo WHERE account=@account", param: new AccoutInfo() { account = code }, transaction: transaction).AsList();
        }
        /// <summary>
        /// 获取账号信息--根据EmpId
        /// </summary>
        /// </summary>
        /// <param name="empid">员工基本信息ID</param>
        /// <returns></returns>
        public AccoutInfo QueryByEmpId(int empid, IDbTransaction transaction)
        {
            return dbConnection.QueryFirstOrDefault<AccoutInfo>(sql: "SELECT *  FROM   AccoutInfo WHERE empid=@empid", param: new AccoutInfo() { empid = empid }, transaction: transaction);
        }
    }
}
