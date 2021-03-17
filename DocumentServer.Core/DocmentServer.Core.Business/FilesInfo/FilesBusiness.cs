using Dapper;
using DocumentServer.Core.Infrastrure;
using DocumentServer.Core.Model.DbModel;
using System.Collections.Generic;
using System.Data;

namespace DocmentServer.Core.Business.FilesInfo
{
    public class FilesBusiness : Base.BaseBusiness, IFilesBusiness
    {
        public FilesBusiness()
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

        public List<Files> GetFiles(int folderid, IDbTransaction transaction = null)
        {
            return dbConnection.Query<Files>(sql: "SELECT *  FROM  Files WHERE folderid=@folderid", param: new Files() { folderid = folderid }, transaction: transaction).AsList();
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
