using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper.Contrib.Extensions;
using Dapper;
/**
* 描述：组织信息操作类-实现* 
* */
namespace DocmentServer.Core.Business.Organization
{
    public class OrganizationBusiness : IOrganizationBusiness
    {
        private IDbConnection dbConnection;
        public OrganizationBusiness(IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
        }
        /// <summary>
        /// 添加组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public long Add(DocumentServer.Core.Model.DbModel.Organization model, IDbTransaction transaction = null)
        {
            return dbConnection.Insert<DocumentServer.Core.Model.DbModel.Organization>(entityToInsert: model, transaction: transaction);
        }
        /// <summary>
        /// 修改组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public bool Update(DocumentServer.Core.Model.DbModel.Organization model, IDbTransaction transaction = null)
        {
            return dbConnection.Update<DocumentServer.Core.Model.DbModel.Organization>(entityToUpdate: model, transaction: transaction);
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
        /// 获取组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public DocumentServer.Core.Model.DbModel.Organization Get(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Get<DocumentServer.Core.Model.DbModel.Organization>(id: id, transaction: transaction);
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
        /// <summary>
        /// 获取所有组织数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Organization> All(IDbTransaction transaction = null)
        {
            return dbConnection.GetAll<DocumentServer.Core.Model.DbModel.Organization>(transaction: transaction).AsList();
        }
    }
}
