using DocmentServer.Core.Business.Company;
using DocmentServer.Core.DomainService.Base;
using DocumentServer.Core.Model.DbModel;
using System.Collections.Generic;
using System.Data;

namespace DocmentServer.Core.DomainService.Company
{
    public class CompanyDomainService : BaseDomainService, ICompanyDomainService
    {
        private ICompanyBusiness business;
        public CompanyDomainService(ICompanyBusiness business) : base(_business: business)
        {
            this.business = business;
        }


        /// <summary>
        /// 删除单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return business.Delete(id: id, transaction: transaction);
        }


        /// <summary>
        /// 获取单位信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public List<UnitInfo> List(object id, IDbTransaction transaction = null)
        {
            return business.List(id: id, transaction: transaction);
        }
        /// <summary>
        /// 获取单位信息--多个-按工号
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public List<UnitInfo> GetListByCode(string code, IDbTransaction transaction = null)
        {
            return business.GetListByCode(code: code, transaction: transaction);
        }

        /// <summary>
        /// 获取单位信息--多个--根据上级ID
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public List<UnitInfo> GetListByParentId(int parentId, IDbTransaction transaction = null)
        {
            return business.GetListByParentId(parentId: parentId, transaction: transaction);
        }
    }
}
