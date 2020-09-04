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
        public FileFloderBusiness(IDbConnection _dbConnection) : base(dbConnection: _dbConnection)
        {
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
        public List<FileFloder> GetListOrgID(int orgId, int type, IDbTransaction transaction = null)
        {
            return dbConnection.Query<FileFloder>(sql: "SELECT *  FROM   FileFloder WHERE orgid=@orgid and flodertype=@flodertype", param: new FileFloder() { orgid = orgId, flodertype = type }, transaction: transaction).AsList();
        }
    }
}