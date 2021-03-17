using DocmentServer.Core.Business.FilesInfo;
using DocumentServer.Core.Model.DbModel;
using System.Collections.Generic;
using System.Data;

namespace DocmentServer.Core.DomainService.FilesInfo
{
    public class FilesDomainService : Base.BaseDomainService, IFilesDomainService
    {
        public IFilesBusiness business { get; set; }
        public FilesDomainService()
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
        public List<Files> List(object id, IDbTransaction transaction = null)
        {
            return business.List(id: id, transaction: transaction);
        }
        public List<Files> GetFiles(int folderid, IDbTransaction transaction = null)
        {
            return business.GetFiles(folderid: folderid, transaction: transaction);
        }

    }
}

