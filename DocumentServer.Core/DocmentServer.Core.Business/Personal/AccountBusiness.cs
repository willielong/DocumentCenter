﻿using Dapper;
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
        public AccountBusiness(IDbConnection _dbConnection) : base(dbConnection: _dbConnection)
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
    }
}
