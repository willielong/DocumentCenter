using DocmentServer.Core.Business.Employee;
using DocmentServer.Core.DomainService.Base;
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
        /// 添加人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public long Add(DocumentServer.Core.Model.DbModel.Employee model, IDbTransaction transaction = null)
        {
            return business.Add(model: model, transaction: transaction);
        }
        /// <summary>
        /// 修改人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public bool Update(DocumentServer.Core.Model.DbModel.Employee model, IDbTransaction transaction = null)
        {
            return business.Update(model: model, transaction: transaction);
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
        /// 获取人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public DocumentServer.Core.Model.DbModel.Employee Get(object id, IDbTransaction transaction = null)
        {
            return business.Get(id: id, transaction: transaction);
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
        /// 获取所有人员基本信息数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Employee> All(IDbTransaction transaction = null)
        {
            return business.All(transaction: transaction);
        }
    }
}
