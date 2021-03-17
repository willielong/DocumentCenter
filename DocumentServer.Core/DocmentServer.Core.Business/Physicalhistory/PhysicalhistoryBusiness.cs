using Dapper;
using DocmentServer.Core.Business.Base;
using DocumentServer.Core.Infrastrure;
using System.Data;
using System.Linq;

namespace DocmentServer.Core.Business.Physicalhistory
{
    public class PhysicalhistoryBusiness : BaseBusiness, IPhysicalhistoryBusiness
    {
        public PhysicalhistoryBusiness()
        {
        }
        /// <summary>
        /// 添加前先关闭
        /// </summary>
        /// <param name="modele"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Edit(IDbTransaction transaction = null)
        {
            return dbConnection.Execute(sql: "UPDATE Physicalhistory  SET `enable`=0 WHERE `enable`=1", transaction: transaction) >= 0;
        }
        /// <summary>
        /// 获取最新的文件夹
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public DocumentServer.Core.Model.DbModel.Physicalhistory SingleByEnable(IDbTransaction transaction = null)
        {
            var List = dbConnection.Query<DocumentServer.Core.Model.DbModel.Physicalhistory>(sql: "SELECT * FROM Physicalhistory where `enable`=1", transaction: transaction).AsList();
            if (List.Any())
            {
                return List.FirstOrDefault();
            }
            else
            {
                return null;
            }
        }
    }
}
