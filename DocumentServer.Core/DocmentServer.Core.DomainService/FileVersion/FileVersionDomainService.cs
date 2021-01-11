using DocmentServer.Core.Business.FileVersion;
using DocumentServer.Core.Model.DbModel;
using System.Collections.Generic;
using System.Data;

namespace DocmentServer.Core.DomainService.FileVersion
{
    public class FileVersionDomainService : Base.BaseDomainService, IFileVersionDomainService
    {
        private IFilesVersionBusiness business;
        public FileVersionDomainService(IFilesVersionBusiness business) : base(business)
        {
            this.business = business;
        }
        /// <summary>
        /// 删除版本信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return business.Delete(id: id, transaction: transaction);
        }
        /// <summary>
        /// 获取版本信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">版本信息实体</param>
        /// <returns></returns>
        public List<FilesVersion> GetVersionsByFileId(int fileid, IDbTransaction transaction = null)
        {
            return business.GetVersionsByFileId(fileid: fileid, transaction: transaction);
        }

        /// <summary>
        /// 获取版本信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">版本实体</param>
        /// <returns></returns>
        public List<FilesVersion> List(object id, IDbTransaction transaction = null)
        {
            return business.List(id: id, transaction: transaction);
        }

    }
}
