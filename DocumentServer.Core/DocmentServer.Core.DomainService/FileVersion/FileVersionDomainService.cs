using DocmentServer.Core.Business.FileVersion;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.DomainService.FileVersion
{
    public class FileVersionDomainService : Base.BaseDomainService
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
