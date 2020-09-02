using DocmentServer.Core.DomainService.Base;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.DomainService.Personal
{
    public interface IAccountDomainService: IBaseDomainService
    {
        /// <summary>
        /// 添加账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        long Add(AccoutInfo model, IDbTransaction transaction = null);
        /// <summary>
        /// 修改账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        bool Update(AccoutInfo model, IDbTransaction transaction = null);

        /// <summary>
        /// 删除账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        bool Delete(object id, IDbTransaction transaction = null);

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        AccoutInfo Get(object id, IDbTransaction transaction = null);

        /// <summary>
        /// 获取账户信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        List<AccoutInfo> List(object id, IDbTransaction transaction = null);
        /// <summary>
        /// 获取账户信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        List<AccoutInfo> GetListByCode(string code, IDbTransaction transaction = null);
        /// <summary>
        /// 获取所有账户数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        List<AccoutInfo> All(IDbTransaction transaction = null);
    }
}
