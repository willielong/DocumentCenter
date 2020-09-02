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
        /// 添加人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        long Add(DocumentServer.Core.Model.DbModel.Employee model, IDbTransaction transaction = null);
        /// <summary>
        /// 修改人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        bool Update(DocumentServer.Core.Model.DbModel.Employee model, IDbTransaction transaction = null);

        /// <summary>
        /// 删除人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        bool Delete(object id, IDbTransaction transaction = null);

        /// <summary>
        /// 获取人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        DocumentServer.Core.Model.DbModel.Employee Get(object id, IDbTransaction transaction = null);

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
        /// 获取所有人员基本信息数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        List<DocumentServer.Core.Model.DbModel.Employee> All(IDbTransaction transaction = null);
    }
}
