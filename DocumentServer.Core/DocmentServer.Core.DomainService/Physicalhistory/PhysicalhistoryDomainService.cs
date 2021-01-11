using DocmentServer.Core.Business.Physicalhistory;
using System.Data;

namespace DocmentServer.Core.DomainService.Physicalhistory
{
    public class PhysicalhistoryDomainService : Base.BaseDomainService, IPhysicalhistoryDomainService
    {
        private IPhysicalhistoryBusiness business;
        public PhysicalhistoryDomainService(IPhysicalhistoryBusiness business) : base(_business: business)
        {
            this.business = business;
        }
        public bool Edit(IDbTransaction transaction = null)
        {
            return this.business.Edit(transaction: transaction);
        }

        /// <summary>
        /// 获取开启的网站路径
        /// </summary>
        /// <returns></returns>
        public DocumentServer.Core.Model.DbModel.Physicalhistory SingleByEnable(IDbTransaction transaction = null)
        {
            return this.business.SingleByEnable(transaction: transaction);
        }
    }
}
