using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DocmentServer.Core.Business.Physicalhistory;
using DocumentServer.Core.Model.DbModel;

namespace DocmentServer.Core.DomainService.Physicalhistory
{
    public class PhysicalhistoryDomainService : Base.BaseDomainService, IPhysicalhistoryDomainService
    {
        private IPhysicalhistoryBusiness business;
        public PhysicalhistoryDomainService(IPhysicalhistoryBusiness business) : base(_business: business)
        {
            this.business = business;
        }
        public bool Edit(DocumentServer.Core.Model.DbModel.Physicalhistory modele, IDbTransaction transaction = null)
        {
            return this.business.Edit(modele: modele, transaction: transaction);
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
