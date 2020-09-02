using DocmentServer.Core.Business.Base;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.Business.FilesInfo
{
    public interface IFilesBusiness : IBaseBusiness
    {
        /// <summary>
        /// 删除文件信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件实体</param>
        /// <returns></returns>
        bool Delete(object id, IDbTransaction transaction = null);
        /// <summary>
        /// 获取文件信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">文件实体</param>
        /// <returns></returns>
        List<Files> List(object id, IDbTransaction transaction = null);

    }
}
