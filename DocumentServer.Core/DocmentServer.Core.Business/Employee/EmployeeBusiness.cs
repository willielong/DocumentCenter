using Dapper;
using DocmentServer.Core.Business.Base;
using System.Collections.Generic;
using System.Data;
using System.Linq;
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
        /// <summary>
        /// 获取人员基本信息信息--多个-按组织ID
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Employee> GetListByOrgId(int orgId, IDbTransaction transaction = null)
        {
            return dbConnection.Query<DocumentServer.Core.Model.DbModel.Employee>(sql: "SELECT *  FROM   Employee WHERE orgid=@orgid", param: new DocumentServer.Core.Model.DbModel.Employee() { orgid = orgId }, transaction: transaction).AsList();
        }
        /// <summary>
        /// 根据部门ID获取人员信息
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.Oupt.TableEmployee> TablePersonal(int pid, IDbTransaction transaction = null)
        {
            string sql = @"SELECT e1.*,e1.orgId,og.* FROM Employee e1 
                            LEFT JOIN organization og ON og.orgid=e1.orgId where e1.orgid=@orgid";
            return dbConnection.Query<DocumentServer.Core.Model.DbModel.Employee, DocumentServer.Core.Model.DbModel.Organization, DocumentServer.Core.Model.Oupt.TableEmployee>(sql, (emp1, org) =>
              {
                  DocumentServer.Core.Model.Oupt.TableEmployee result = new DocumentServer.Core.Model.Oupt.TableEmployee() { empid = emp1.empid, cnname = emp1.cnname, dic_createdate = emp1.creatdate.ToString("yyyy-MM-dd HH:mm"), dic_OrgName = org.cnname, dic_creator = emp1.creator.ToString(), email = emp1.email, empcode = emp1.empcode, enname = emp1.enname, orgid = emp1.orgid, phone = emp1.phone, sequence = emp1.sequence };
                  return result;

              }, new { @orgid = pid }, splitOn: "creator,orgId").OrderBy(o => o.sequence).ToList();
        }

        /// <summary>
        /// 获取人员基本信息信息--根据empids集合
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public Dictionary<int, string> GetListByEmpIds(List<string> empids, IDbTransaction transaction = null)
        {
            Dictionary<int, string> dics = new Dictionary<int, string>();
            if (empids.Any())
            {
                string empid = string.Join(",", empids);
                var List = dbConnection.Query<DocumentServer.Core.Model.DbModel.Employee>(sql: string.Format("SELECT *  FROM   Employee WHERE empid in({0})", empid), transaction: transaction).AsList();
                List.ForEach(o =>
                {
                    if (!dics.Any(p => p.Key == o.empid))
                    {
                        dics.Add(o.empid, o.cnname);
                    }
                });
            }
            return dics;
        }
        /// <summary>
        /// 获取人员基本信息信息--获取所有集合
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public Dictionary<int, string> GetAll(IDbTransaction transaction = null)
        {
            Dictionary<int, string> dics = new Dictionary<int, string>();
            var List = base.All<DocumentServer.Core.Model.DbModel.Employee>();
            List.ForEach(o =>
            {
                if (!dics.Any(p => p.Key == o.empid))
                {
                    dics.Add(o.empid, o.cnname);
                }
            });
            return dics;
        }
    }
}
