using Dapper;
using Dapper.Contrib.Extensions;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
/**
 * 描述：单位信息操作类-实现
 * 
 * 
 * */
namespace DocmentServer.Core.Business.Company
{
    public class CompanyBusiness : ICompanyBusiness
    {
        private IDbConnection dbConnection;
        public CompanyBusiness(IDbConnection _dbConnection)
        {
            dbConnection = _dbConnection;
        }
        /// <summary>
        /// 添加单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public long Add(UnitInfo model, IDbTransaction transaction = null)
        {
            return dbConnection.Insert<UnitInfo>(entityToInsert: model, transaction: transaction);
        }
        /// <summary>
        /// 修改单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public bool Update(UnitInfo model, IDbTransaction transaction = null)
        {
            return dbConnection.Update<UnitInfo>(entityToUpdate: model, transaction: transaction);
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
        /// 获取单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public UnitInfo Get(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Get<UnitInfo>(id: id, transaction: transaction);
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
        /// 获取所有单位数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<UnitInfo> All(IDbTransaction transaction = null)
        {
            return dbConnection.GetAll<UnitInfo>(transaction: transaction).AsList();
        }
    }
}
