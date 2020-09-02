using DocmentServer.Core.Business.Company;
using DocmentServer.Core.DomainService.Base;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

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
        /// 添加单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public long Add(UnitInfo model, IDbTransaction transaction = null)
        {
            return business.Add(model: model, transaction: transaction);
        }
        /// <summary>
        /// 修改单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public bool Update(UnitInfo model, IDbTransaction transaction = null)
        {
            return business.Update(model: model, transaction: transaction);
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
        /// 获取单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public UnitInfo Get(object id, IDbTransaction transaction = null)
        {
            return business.Get(id: id, transaction: transaction);
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
        /// 获取所有单位数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<UnitInfo> All(IDbTransaction transaction = null)
        {
            return business.All(transaction: transaction);
        }
    }
}
