using System.Data;

namespace DocmentServer.Core.Business.Physicalhistory
{
    public interface IPhysicalhistoryBusiness : Base.IBaseBusiness
    {
        bool Edit(IDbTransaction transaction = null);
        /// <summary>
        /// 获取开启的网站路径
        /// </summary>
        /// <returns></returns>
        DocumentServer.Core.Model.DbModel.Physicalhistory SingleByEnable(IDbTransaction transaction = null);
    }
}
