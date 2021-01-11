using DocmentServer.Core.DomainService.Base;
using DocumentServer.Core.Model.DbModel;
using System.Collections.Generic;
using System.Data;

namespace DocmentServer.Core.DomainService.FileVersion
{
    public interface IFileVersionDomainService : IBaseDomainService
    {
        /// <summary>
        /// 删除版本信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本实体</param>
        /// <returns></returns>
        bool Delete(object id, IDbTransaction transaction = null);
        /// <summary>
        /// 获取版本信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">版本实体</param>
        /// <returns></returns>
        List<FilesVersion> List(object id, IDbTransaction transaction = null);
        /// <summary>
        /// 获取版本信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">版本信息实体</param>
        /// <returns></returns>
        List<FilesVersion> GetVersionsByFileId(int fileid, IDbTransaction transaction = null);
    }
}