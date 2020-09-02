using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocmentServer.Core.BizService.Folder
{
    public interface IBizFolderService
    {/// <summary>
     /// 添加账户信息
     /// </summary>
     /// </summary>
     /// <param name="model">账户实体</param>
     /// <returns></returns>
        IResponseMessage Add(FileFloder model);
        /// <summary>
        /// 修改账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        IResponseMessage Update(FileFloder model);

        /// <summary>
        /// 删除账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        IResponseMessage Delete(object id);

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        IResponseMessage Get(object id);

        /// <summary>
        /// 获取账户信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        IResponseMessage List(object id);
        /// <summary>
        /// 获取所有账户数据
        /// </summary>
        /// <returns></returns>
        IResponseMessage All();
    }
}
