using DocmentServer.Core.DomainService.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.DomainService.Employee
{
    public interface IEmployeeDomainService : IBaseDomainService
    {

        /// <summary>
        /// 删除人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        bool Delete(object id, IDbTransaction transaction = null);

        /// <summary>
        /// 获取人员基本信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        List<DocumentServer.Core.Model.DbModel.Employee> List(object id, IDbTransaction transaction = null);
        /// <summary>
        /// 获取人员基本信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        List<DocumentServer.Core.Model.DbModel.Employee> GetListByCode(string code, IDbTransaction transaction = null);

        /// <summary>
        /// 获取人员基本信息信息--根据组织ID
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        List<DocumentServer.Core.Model.DbModel.Employee> GetListByOrgId(int orgId, IDbTransaction transaction = null);
        /// <summary>
        /// 根据部门ID获取人员信息
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        List<DocumentServer.Core.Model.Oupt.TableEmployee> TablePersonal(int pid, IDbTransaction transaction = null);

        /// <summary>
        /// 获取人员基本信息信息--根据empids集合
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        Dictionary<int, string> GetListByEmpIds(List<string> empids, IDbTransaction transaction = null);
        /// <summary>
        /// 获取人员基本信息信息--获取所有集合
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        Dictionary<int, string> GetAll(IDbTransaction transaction = null);
    }
}
