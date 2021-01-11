﻿using DocmentServer.Core.Business.Base;
using DocumentServer.Core.Model.DbModel;
using System.Collections.Generic;
using System.Data;

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
        /// <summary>
        /// 根据文件夹获取文件
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="transaction"></param>
        /// <returns></returns>
        List<Files> GetFiles(int folderid, IDbTransaction transaction = null);

    }
}
