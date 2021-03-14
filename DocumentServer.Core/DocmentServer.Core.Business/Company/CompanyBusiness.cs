using Dapper;
using DocmentServer.Core.Business.Base;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using System.Collections.Generic;
using System.Data;
/**
 * 描述：单位信息操作类-实现
 * 
 * 
 * */
namespace DocmentServer.Core.Business.Company
{
    public class CompanyBusiness : BaseBusiness, ICompanyBusiness
    {
        public CompanyBusiness(ICustomDbConnection _dbConnection) : base(dbConnection: _dbConnection.dbConnection)
        {
        }
        /// <summary>
        /// 删除单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Execute(sql: "DELETE FROM  UnitInfo WHERE unitID=@unitid", param: new UnitInfo() { unitid = (int)id }, transaction: transaction) >= 0;
        }
        /// <summary>
        /// 获取单位信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public List<UnitInfo> List(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Query<UnitInfo>(sql: "SELECT *  FROM  UnitInfo WHERE unitID=@unitid", param: new UnitInfo() { unitid = (int)id }, transaction: transaction).AsList();
        }
        /// <summary>
        /// 获取单位信息--多个-按工号
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public List<UnitInfo> GetListByCode(string code, IDbTransaction transaction = null)
        {
            return dbConnection.Query<UnitInfo>(sql: "SELECT *  FROM  UnitInfo WHERE unitcode=@unitcode", param: new UnitInfo() { unitcode = code }, transaction: transaction).AsList();
        }
        /// <summary>
        /// 获取单位信息--多个--根据上级ID
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public List<UnitInfo> GetListByParentId(int parentId, IDbTransaction transaction = null)
        {
            return dbConnection.Query<UnitInfo>(sql: "SELECT *  FROM  UnitInfo WHERE parentId=@parentId", param: new UnitInfo() { parentId = parentId }, transaction: transaction).AsList();
        }
    }
}
