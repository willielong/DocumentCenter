using DocmentServer.Core.Business.Base;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using Dapper;
using Dapper.Contrib.Extensions;

namespace DocmentServer.Core.Business.Physicalhistory
{
    public class PhysicalhistoryBusiness : BaseBusiness, IPhysicalhistoryBusiness
    {
        public PhysicalhistoryBusiness(IDbConnection _dbConnection) : base(dbConnection: _dbConnection)
        {
        }
        /// <summary>
        /// 添加前先关闭
        /// </summary>
        /// <param name="modele"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool Edit(DocumentServer.Core.Model.DbModel.Physicalhistory modele, IDbTransaction transaction = null)
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
            return dbConnection.QuerySingle<DocumentServer.Core.Model.DbModel.Physicalhistory>(sql: "SELECT * FROM Physicalhistory where `enable`=1", transaction: transaction);
        }
    }
}
