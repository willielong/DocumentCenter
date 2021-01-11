using DocmentServer.Core.Business.Base;
using DocumentServer.Core.Model.DbModel;
using System.Collections.Generic;
using System.Data;
/**
 * 描述：账户信息操作类-接口 
 * */
namespace DocmentServer.Core.Business.Personal
{
    public interface IAccountBusiness : IBaseBusiness
    {
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
        AccoutInfo QueryByEmpId(int empid, IDbTransaction transaction);
    }
}
