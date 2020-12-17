using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.Oupt;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.DomainService.Folder
{
    public interface IFolderDomainService : Base.IBaseDomainService
    {

        /// <summary>
        /// 删除文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        bool Delete(object id, IDbTransaction transaction = null);
        /// <summary>
        /// 获取文件夹信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        List<FileFloder> List(object id, IDbTransaction transaction = null);
        /// <summary>
        /// 获取文件夹信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        List<FileFloder> GetListOrgID(int orgId, int type, IDbTransaction transaction = null);
        /// <summary>
        /// 获取文件列表-按组织-按上级Id
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="type"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        List<FileFloder> GetFolders(int pid, IDbTransaction transaction = null);
    }
}
