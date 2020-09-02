using DocmentServer.Core.Business.Personal;
using DocmentServer.Core.DomainService.Base;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.DomainService.Personal
{
    public class AccountDomainService : BaseDomainService, IAccountDomainService
    {
        private IAccountBusiness business;
        public AccountDomainService(IAccountBusiness business) : base(_business: business)
        {
            this.business = business;
        }

        /// <summary>
        /// 添加账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public long Add(AccoutInfo model, IDbTransaction transaction = null)
        {
            return business.Add(model: model, transaction: transaction);
        }
        /// <summary>
        /// 修改账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public bool Update(AccoutInfo model, IDbTransaction transaction = null)
        {
            return business.Update(model: model, transaction: transaction);
        }

        /// <summary>
        /// 删除账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return business.Delete(id: id, transaction: transaction);
        }

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public AccoutInfo Get(object id, IDbTransaction transaction = null)
        {
            return business.Get(id: id, transaction: transaction);
        }
        /// <summary>
        /// 获取账户信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public List<AccoutInfo> List(object id, IDbTransaction transaction = null)
        {
            return business.List(id: id, transaction: transaction);
        }
        /// <summary>
        /// 获取账户信息--多个-按工号
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public List<AccoutInfo> GetListByCode(string code, IDbTransaction transaction = null)
        {
            return business.GetListByCode(code: code, transaction: transaction);
        }
        /// <summary>
        /// 获取所有账户数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<AccoutInfo> All(IDbTransaction transaction = null)
        {
            return business.All(transaction: transaction);
        }
    }
}
