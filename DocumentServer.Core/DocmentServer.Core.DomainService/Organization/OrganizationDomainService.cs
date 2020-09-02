using DocmentServer.Core.Business.Organization;
using DocmentServer.Core.DomainService.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.DomainService.Organization
{
    public class OrganizationDomainService : BaseDomainService, IOrganizationDomainService
    {
        private IOrganizationBusiness business;
        public OrganizationDomainService(IOrganizationBusiness business) : base(business)
        {
            this.business = business;
        }

        /// <summary>
        /// 添加组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public long Add(DocumentServer.Core.Model.DbModel.Organization model, IDbTransaction transaction = null)
        {
            return business.Add(model: model, transaction: transaction);
        }
        /// <summary>
        /// 修改组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public bool Update(DocumentServer.Core.Model.DbModel.Organization model, IDbTransaction transaction = null)
        {
            return business.Update(model: model, transaction: transaction);
        }

        /// <summary>
        /// 删除组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return business.Delete(id: id, transaction: transaction);
        }

        /// <summary>
        /// 获取组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public DocumentServer.Core.Model.DbModel.Organization Get(object id, IDbTransaction transaction = null)
        {
            return business.Get(id: id, transaction: transaction);
        }
        /// <summary>
        /// 获取组织信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Organization> List(object id, IDbTransaction transaction = null)
        {
            return business.List(id: id, transaction: transaction);
        }
        /// <summary>
        /// 获取组织信息--多个-按工号
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Organization> GetListByCode(string code, IDbTransaction transaction = null)
        {
            return business.GetListByCode(code: code, transaction: transaction);
        }
        /// <summary>
        /// 获取所有组织数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Organization> All(IDbTransaction transaction = null)
        {
            return business.All(transaction: transaction);
        }
    }
}
