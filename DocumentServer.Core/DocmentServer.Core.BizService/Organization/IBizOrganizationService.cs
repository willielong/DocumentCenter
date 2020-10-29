using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.BizService.Organization
{
    public interface IBizOrganizationService
    { /// <summary>
      /// 添加组织信息
      /// </summary>
      /// </summary>
      /// <param name="model">组织实体</param>
      /// <returns></returns>
        IResponseMessage Add(DocumentServer.Core.Model.DbModel.Organization model);
        /// <summary>
        /// 修改组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        IResponseMessage Update(DocumentServer.Core.Model.DbModel.Organization model);

        /// <summary>
        /// 删除组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        IResponseMessage Delete(object id);

        /// <summary>
        /// 获取组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        IResponseMessage Get(object id);

        /// <summary>
        /// 获取组织信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        IResponseMessage List(object id);
        /// <summary>
        /// 获取组织信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        IResponseMessage GetListByCode(string code);
        /// <summary>
        /// 获取所有组织数据
        /// </summary>
        /// <returns></returns>
        IResponseMessage All();
        /// <summary>
        /// 获取子级部门
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        IResponseMessage GetTableOrganization(int pid);
    }
}
