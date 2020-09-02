using DocmentServer.Core.Business.Folder;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.DomainService.Folder
{
    public class FolderDomainService : Base.BaseDomainService
    {
        private IFileFloderBusiness business;
        public FolderDomainService(IFileFloderBusiness business) : base(business)
        {
            this.business = business;
        }
        /// <summary>
        /// 添加文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        public long Add(FileFloder model, IDbTransaction transaction = null)
        {
            return business.Add(model: model, transaction: transaction);
        }
        /// <summary>
        /// 修改文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        public bool Update(FileFloder model, IDbTransaction transaction = null)
        {
            return business.Update(model: model, transaction: transaction);
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
        /// 获取文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        public FileFloder Get(object id, IDbTransaction transaction = null)
        {
            return business.Get(id: id, transaction: transaction);
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
        public List<FileFloder> GetListOrgID(int orgId, IDbTransaction transaction = null)
        {
            return business.GetListOrgID(orgId: orgId, transaction: transaction);
        }
        /// <summary>
        /// 获取所有文件夹数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<FileFloder> All(IDbTransaction transaction = null)
        {
            return business.All(transaction: transaction);
        }
    }
}
