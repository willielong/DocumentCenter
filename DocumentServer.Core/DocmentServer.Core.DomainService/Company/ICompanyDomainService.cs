using DocmentServer.Core.DomainService.Base;
using DocumentServer.Core.Model.DbModel;
using System.Collections.Generic;
using System.Data;

namespace DocmentServer.Core.DomainService.Company
{
    public interface ICompanyDomainService : IBaseDomainService
    {

        /// <summary>
        /// 删除单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        bool Delete(object id, IDbTransaction transaction = null);


        /// <summary>
        /// 获取单位信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        List<UnitInfo> List(object id, IDbTransaction transaction = null);
        /// <summary>
        /// 获取单位信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        List<UnitInfo> GetListByCode(string code, IDbTransaction transaction = null);
        /// <summary>
        /// 获取单位信息--多个--根据上级ID
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        List<UnitInfo> GetListByParentId(int parentId, IDbTransaction transaction = null);
    }
}
