using DocmentServer.Core.Business.Base;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
/**
 * 描述：单位信息操作类-接口
 * 
 * 
 * */
namespace DocmentServer.Core.Business.Company
{
    public interface ICompanyBusiness : IBaseBusiness
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
    }
}
