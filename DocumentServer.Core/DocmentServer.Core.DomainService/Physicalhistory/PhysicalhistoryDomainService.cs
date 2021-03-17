using DocmentServer.Core.Business.Physicalhistory;
using System.Data;

namespace DocmentServer.Core.DomainService.Physicalhistory
{
    public class PhysicalhistoryDomainService : Base.BaseDomainService, IPhysicalhistoryDomainService
    {
        public IPhysicalhistoryBusiness business { get; set; }
        public PhysicalhistoryDomainService()
        {
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
