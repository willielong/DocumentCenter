using Dapper;
using Dapper.Contrib.Extensions;
using DocmentServer.Core.Business.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
/**
* 描述：人员基本信息信息操作类-实现* 
* */
namespace DocmentServer.Core.Business.Employee
{
    public class EmployeeBusiness : BaseBusiness, IEmployeeBusiness
    {
        public EmployeeBusiness(IDbConnection _dbConnection) : base(dbConnection: _dbConnection)
        {
        }

        /// <summary>
        /// 删除人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Execute(sql: "DELETE FROM  Employee WHERE empid=@empid", param: new DocumentServer.Core.Model.DbModel.Employee() { empid = (int)id }, transaction: transaction) >= 0;
        }
        /// <summary>
        /// 获取人员基本信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Employee> List(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Query<DocumentServer.Core.Model.DbModel.Employee>(sql: "SELECT *  FROM  Employee WHERE empid=@empid", param: new DocumentServer.Core.Model.DbModel.Employee() { empid = (int)id }, transaction: transaction).AsList();
        }
        /// <summary>
        /// 获取人员基本信息信息--多个-按工号
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Employee> GetListByCode(string code, IDbTransaction transaction = null)
        {
            return dbConnection.Query<DocumentServer.Core.Model.DbModel.Employee>(sql: "SELECT *  FROM   Employee WHERE empcode=@empcode", param: new DocumentServer.Core.Model.DbModel.Employee() { empcode = code }, transaction: transaction).AsList();
        }
    }
}
