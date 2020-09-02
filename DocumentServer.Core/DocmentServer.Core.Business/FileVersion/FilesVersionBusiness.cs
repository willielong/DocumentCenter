using Dapper;
using Dapper.Contrib.Extensions;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.Business.FileVersion
{
    public class FilesVersionBusiness:Base.BaseBusiness, IFilesVersionBusiness
    {
        private IDbConnection dbConnection;
        public FilesVersionBusiness(IDbConnection _dbConnection):base(dbConnection:_dbConnection)
        {
            dbConnection = _dbConnection;
        }
        /// <summary>
        /// 添加版本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本信息实体</param>
        /// <returns></returns>
        public long Add(FilesVersion model, IDbTransaction transaction = null)
        {
            model.creator = CurrentUser.empid;
            model.modifier = CurrentUser.empid;
            return dbConnection.Insert<FilesVersion>(entityToInsert: model, transaction: transaction);
        }
        /// <summary>
        /// 修改版本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本信息实体</param>
        /// <returns></returns>
        public bool Update(FilesVersion model, IDbTransaction transaction = null)
        {
            model.modifier = CurrentUser.empid;
            return dbConnection.Update<FilesVersion>(entityToUpdate: model, transaction: transaction);
        }

        /// <summary>
        /// 删除版本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本信息实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Execute(sql: "DELETE FROM  FilesVersion WHERE autoid=@autoid", param: new FilesVersion() { autoid = (int)id }, transaction: transaction) >= 0;
        }

        /// <summary>
        /// 获取版本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本信息实体</param>
        /// <returns></returns>
        public FilesVersion Get(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Get<FilesVersion>(id: id, transaction: transaction);
        }
        /// <summary>
        /// 获取版本信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">版本信息实体</param>
        /// <returns></returns>
        public List<FilesVersion> List(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Query<FilesVersion>(sql: "SELECT *  FROM  FilesVersion WHERE autoid=@autoid", param: new FilesVersion() { autoid = (int)id }, transaction: transaction).AsList();
        }
        /// <summary>
        /// 获取所有版本信息数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<FilesVersion> All(IDbTransaction transaction = null)
        {
            return dbConnection.GetAll<FilesVersion>(transaction: transaction).AsList();
        }
    }
}
