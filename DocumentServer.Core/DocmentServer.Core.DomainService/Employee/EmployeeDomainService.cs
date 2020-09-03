using DocmentServer.Core.Business.Employee;
using DocmentServer.Core.DomainService.Base;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.DomainService.Employee
{
    public class EmployeeDomainService : BaseDomainService, IEmployeeDomainService
    {
        private IEmployeeBusiness business;
        public EmployeeDomainService(IEmployeeBusiness business) : base(business)
        {
            this.business = business;
        }

       
        /// <summary>
        /// 删除人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return business.Delete(id: id, transaction: transaction);
        }

       
        /// <summary>
        /// 获取人员基本信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Employee> List(object id, IDbTransaction transaction = null)
        {
            return business.List(id: id, transaction: transaction);
        }
        /// <summary>
        /// 获取人员基本信息信息--多个-按工号
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Employee> GetListByCode(string code, IDbTransaction transaction = null)
        {
            return business.GetListByCode(code: code, transaction: transaction);
        }
        /// <summary>
        /// 获取人员基本信息信息--多个-按组织ID
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Employee> GetListByOrgId(int orgId, IDbTransaction transaction = null)
        {
            return business.GetListByOrgId(orgId: orgId, transaction: transaction);
        }
    }
}
