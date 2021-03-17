using DocmentServer.Core.Business.Folder;
using DocumentServer.Core.Model.DbModel;
using System.Collections.Generic;
using System.Data;

namespace DocmentServer.Core.DomainService.Folder
{
    public class FolderDomainService : Base.BaseDomainService, IFolderDomainService
    {
        public IFileFloderBusiness business { get; set; }
        public FolderDomainService()
        {
        }
        /// <summary>
        /// 删除文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return business.Delete(id: id, transaction: transaction);
        }


        /// <summary>
        /// 获取文件夹信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        public List<FileFloder> List(object id, IDbTransaction transaction = null)
        {
            return business.List(id: id, transaction: transaction);
        }
        /// <summary>
        /// 获取文件夹信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        public List<FileFloder> GetListOrgID(int orgId, int type, IDbTransaction transaction = null)
        {
            return business.GetListOrgID(orgId: orgId, type: type, transaction: transaction);
        }
        /// <summary>
        /// 获取文件列表-按组织-按上级Id
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="type"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public List<FileFloder> GetFolders(int pid, IDbTransaction transaction = null)
        {
            return business.GetFolders(pid: pid, transaction: transaction);
        }

    }
}
