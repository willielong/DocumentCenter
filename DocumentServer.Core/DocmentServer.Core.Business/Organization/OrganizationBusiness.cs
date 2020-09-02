﻿using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper.Contrib.Extensions;
using Dapper;
using DocmentServer.Core.Business.Base;
/**
* 描述：组织信息操作类-实现* 
* */
namespace DocmentServer.Core.Business.Organization
{
    public class OrganizationBusiness : BaseBusiness, IOrganizationBusiness
    {
        public OrganizationBusiness(IDbConnection _dbConnection) : base(dbConnection: _dbConnection)
        {
        }

        /// <summary>
        /// 删除组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Execute(sql: "DELETE FROM  organization WHERE orgid=@orgid", param: new DocumentServer.Core.Model.DbModel.Organization() { orgid = (int)id }, transaction: transaction) >= 0;
        }
        /// <summary>
        /// 获取组织信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Organization> List(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Query<DocumentServer.Core.Model.DbModel.Organization>(sql: "SELECT *  FROM  organization WHERE orgid=@orgid", param: new DocumentServer.Core.Model.DbModel.Organization() { orgid = (int)id }, transaction: transaction).AsList();
        }
        /// <summary>
        /// 获取组织信息--多个-按工号
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Organization> GetListByCode(string code, IDbTransaction transaction = null)
        {
            return dbConnection.Query<DocumentServer.Core.Model.DbModel.Organization>(sql: "SELECT *  FROM   organization WHERE orgcode=@orgcode", param: new DocumentServer.Core.Model.DbModel.Organization() { orgcode = code }, transaction: transaction).AsList();
        }

    }
}
