using DocmentServer.Core.Business.Organization;
using DocmentServer.Core.DomainService.Base;
using System.Collections.Generic;
using System.Data;

namespace DocmentServer.Core.DomainService.Organization
{
    public class OrganizationDomainService : BaseDomainService, IOrganizationDomainService
    {
        public IOrganizationBusiness business { get; set; }
        public OrganizationDomainService()
        {
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
        /// 获取组织信息--多个--按单位
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Organization> GetListByCompanyId(int companyId, IDbTransaction transaction = null)
        {
            return business.GetListByCompanyId(companyId: companyId, transaction: transaction);
        }
        /// <summary>
        /// 获取组织信息--多个--按上级组织
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Organization> GetListByParentId(int parentId, IDbTransaction transaction = null)
        {
            return business.GetListByParentId(parentId: parentId, transaction: transaction);
        }
    }
}
