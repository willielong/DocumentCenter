using Dapper;
using Dapper.Contrib.Extensions;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.Business.FilesInfo
{
    public class FilesBusiness : Base.BaseBusiness, IFilesBusiness
    {
        public FilesBusiness(IDbConnection _dbConnection) : base(dbConnection: _dbConnection)
        {
        }
        /// <summary>
        /// 删除文件信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Execute(sql: "DELETE FROM  Files WHERE autoid=@autoid", param: new Files() { autoid = (int)id }, transaction: transaction) >= 0;
        }

        /// <summary>
        /// 获取文件信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">文件实体</param>
        /// <returns></returns>
        public List<Files> List(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Query<Files>(sql: "SELECT *  FROM  Files WHERE autoid=@autoid", param: new Files() { autoid = (int)id }, transaction: transaction).AsList();
        }
    }
}
