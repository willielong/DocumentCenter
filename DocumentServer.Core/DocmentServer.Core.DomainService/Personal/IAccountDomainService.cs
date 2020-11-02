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
        /// 删除账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        bool Delete(object id, IDbTransaction transaction = null);

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
        /// 获取账号信息--根据EmpId
        /// </summary>
        /// </summary>
        /// <param name="empid">员工基本信息ID</param>
        /// <returns></returns>
        AccoutInfo QueryByEmpId(int empid,IDbTransaction transaction=null);
    }
}
