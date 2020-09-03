using DocmentServer.Core.Business.Base;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
/**
 * 描述：组织信息操作类-接口 
 * */
namespace DocmentServer.Core.Business.Organization
{
    public interface IOrganizationBusiness : IBaseBusiness
    {

        /// <summary>
        /// 删除组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        bool Delete(object id, IDbTransaction transaction = null);
        /// <summary>
        /// 获取组织信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        List<DocumentServer.Core.Model.DbModel.Organization> List(object id, IDbTransaction transaction = null);
        /// <summary>
        /// 获取组织信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        List<DocumentServer.Core.Model.DbModel.Organization> GetListByCode(string code, IDbTransaction transaction = null);

        /// <summary>
        /// 获取组织信息--多个--按单位
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        List<DocumentServer.Core.Model.DbModel.Organization> GetListByCompanyId(int companyId, IDbTransaction transaction = null);
        /// <summary>
        /// 获取组织信息--多个--按上级组织
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        List<DocumentServer.Core.Model.DbModel.Organization> GetListByParentId(int  parentId, IDbTransaction transaction = null);
    }
}
