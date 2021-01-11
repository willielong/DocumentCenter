using DocmentServer.Core.Business.BbTableInfo;
using System.Data;

namespace DocmentServer.Core.DomainService.BbTableInfo
{

    /// <summary>
    /// 描述：表结构信息操作类-实现
    /// </summary>
    public class BbTableInfoDomainService : Base.BaseDomainService, IBbTableInfoDomainService
    {

        private IBbTableInfoBusiness business;
        public BbTableInfoDomainService(IBbTableInfoBusiness _business) : base(_business)
        {
            this.business = _business;
        }

        /// <summary>
        /// 逻辑删除
        /// </summary>
        /// <param name="autoid"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool LogicDelete(object autoid, IDbTransaction transaction = null)
        {
            return business.LogicDelete(autoid: autoid, transaction: transaction);
        }

        /// <summary>
        /// 启用/禁用
        /// </summary>
        /// <param name="autoid"></param>
        /// <param name="enable"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public bool OperationEnable(object autoid, bool enable, IDbTransaction transaction = null)
        {
            return this.business.OperationEnable(autoid: autoid, enable: enable, transaction: transaction);
        }
    }
}
