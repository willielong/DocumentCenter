using Dapper;
using Dapper.Contrib.Extensions;
using DocmentServer.Core.Business.Base;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
/**
* 描述：组织信息操作类-实现* 
* */
namespace DocmentServer.Core.Business.Personal
{
    public class AccountBusiness : BaseBusiness, IAccountBusiness
    {
        private IDbConnection dbConnection;
        public AccountBusiness(IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
        }
        /// <summary>
        /// 添加账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public long Add(AccoutInfo model, IDbTransaction transaction = null)
        {
            model.creator = CurrentUser.empid;
            model.modifier = CurrentUser.empid;
            return dbConnection.Insert<AccoutInfo>(entityToInsert: model, transaction: transaction);
        }
        /// <summary>
        /// 修改账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public bool Update(AccoutInfo model, IDbTransaction transaction = null)
        {
            model.modifier = CurrentUser.empid;
            return dbConnection.Update<AccoutInfo>(entityToUpdate: model, transaction: transaction);
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
        /// 获取账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public AccoutInfo Get(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Get<AccoutInfo>(id: id, transaction: transaction);
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
        /// 获取所有账户数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<AccoutInfo> All(IDbTransaction transaction = null)
        {
            var e = this.CurrentUser;
            return dbConnection.GetAll<AccoutInfo>(transaction: transaction).AsList();
        }
    }
}
