using DocmentServer.Core.Business.FilesInfo;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.DomainService.FilesInfo
{
    public class FilesDomainService : Base.BaseDomainService, IFilesDomainService
    {
        private IFilesBusiness business;
        public FilesDomainService(IFilesBusiness business) : base(business)
        {
            this.business = business;
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
        public List<Files> List(object id, IDbTransaction transaction = null)
        {
            return business.List(id: id, transaction: transaction);
        }

    }
}

