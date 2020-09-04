using DocmentServer.Core.Business.Base;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.Business.FileVersion
{
    public interface IFilesVersionBusiness : IBaseBusiness
    {

        /// <summary>
        /// 删除版本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本信息实体</param>
        /// <returns></returns>
        bool Delete(object id, IDbTransaction transaction = null);


        /// <summary>
        /// 获取版本信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">版本信息实体</param>
        /// <returns></returns>
        List<FilesVersion> List(object id, IDbTransaction transaction = null);
    }
}
