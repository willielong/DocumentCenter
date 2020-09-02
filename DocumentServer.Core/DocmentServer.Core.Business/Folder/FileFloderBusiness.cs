using Dapper;
using Dapper.Contrib.Extensions;
using DocmentServer.Core.Business.Base;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.Business.Folder
{
    public class FileFloderBusiness : BaseBusiness, IFileFloderBusiness
    {
        private IDbConnection dbConnection;
        public FileFloderBusiness(IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
        }
        /// <summary>
        /// 添加文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        public long Add(FileFloder model, IDbTransaction transaction = null)
        {
            model.creator = CurrentUser.empid;
            model.modifier = CurrentUser.empid;
            return dbConnection.Insert<FileFloder>(entityToInsert: model, transaction: transaction);
        }
        /// <summary>
        /// 修改文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        public bool Update(FileFloder model, IDbTransaction transaction = null)
        {
            model.modifier = CurrentUser.empid;
            return dbConnection.Update<FileFloder>(entityToUpdate: model, transaction: transaction);
        }

        /// <summary>
        /// 删除文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Execute(sql: "DELETE FROM  FileFloder WHERE autoid=@autoid", param: new FileFloder() { autoid = (int)id }, transaction: transaction) >= 0;
        }

        /// <summary>
        /// 获取文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        public FileFloder Get(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Get<FileFloder>(id: id, transaction: transaction);
        }
        /// <summary>
        /// 获取文件夹信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        public List<FileFloder> List(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Query<FileFloder>(sql: "SELECT *  FROM  FileFloder WHERE autoid=@autoid", param: new FileFloder() { autoid = (int)id }, transaction: transaction).AsList();
        }
        /// <summary>
        /// 获取文件夹信息--多个-按工号
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        public List<FileFloder> GetListOrgID(int orgId, IDbTransaction transaction = null)
        {
            return dbConnection.Query<FileFloder>(sql: "SELECT *  FROM   FileFloder WHERE orgid=@orgid", param: new FileFloder() { orgid = orgId }, transaction: transaction).AsList();
        }
        /// <summary>
        /// 获取所有文件夹数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<FileFloder> All(IDbTransaction transaction = null)
        {
            return dbConnection.GetAll<FileFloder>(transaction: transaction).AsList();
        }
    }
}