using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.BizService.Company
{
    public interface IBizCompanyService
    { /// <summary>
      /// 添加单位信息
      /// </summary>
      /// </summary>
      /// <param name="model">单位实体</param>
      /// <returns></returns>
        IResponseMessage Add(UnitInfo model);
        /// <summary>
        /// 修改单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        IResponseMessage Update(UnitInfo model);

        /// <summary>
        /// 删除单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        IResponseMessage Delete(object id);

        /// <summary>
        /// 获取单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        IResponseMessage Get(object id);

        /// <summary>
        /// 获取单位信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        IResponseMessage List(object id);
        /// <summary>
        /// 获取单位信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        IResponseMessage GetListByCode(string code);
        /// <summary>
        /// 获取所有单位数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        IResponseMessage All();

        /// <summary>
        /// 获取子级组织
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        IResponseMessage GetTableCompany(int pid);
    }
}
