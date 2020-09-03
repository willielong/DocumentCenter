using DocmentServer.Core.DomainService.Folder;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.BizService.Folder
{
    public class BizFolderService : BaseService.BizBaseService, IBizFolderService
    {
        private IFolderDomainService service;
        private IDbConnection dbConnection;

        public BizFolderService(IFolderDomainService service, IDbConnection dbConnection, IHttpContextAccessor httpContext) : base(httpContext: httpContext)
        {
            this.service = service;
            this.dbConnection = dbConnection;
            this.service.SettingCurrentEmp(employee: CurrentUser);
        }
        /// <summary>
        /// 添加账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public IResponseMessage Add(FileFloder model)
        {
            dbConnection.Open();
            var transaction = dbConnection.BeginTransaction();
            model.creator = CurrentUser.empid;
            model.modifier = CurrentUser.empid;
            long id = service.Add(model: model, transaction: transaction);
            transaction.Commit();
            return id.ToResponse();
        }
        /// <summary>
        /// 修改账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public IResponseMessage Update(FileFloder model)
        {
            model.modifier = CurrentUser.empid;
            return service.Update(model: model).ToResponse();
        }

        /// <summary>
        /// 删除账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public IResponseMessage Delete(object id)
        {
            return service.Delete(id: id).ToResponse();
        }

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public IResponseMessage Get(object id)
        {
            return service.Get<FileFloder>(id: id).ToResponse();
        }
        /// <summary>
        /// 获取账户信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public IResponseMessage List(object id)
        {
            return service.List(id: id).ToResponse();
        }
        /// <summary>
        /// 获取所有账户数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IResponseMessage All()
        {
            return service.All<FileFloder>().ToResponse();
        }

        /// <summary>
        /// 获取文件夹信息--多个-- 按组织ID
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        public IResponseMessage GetFoldersByOrgId(int orgId, int type)
        {
            return service.GetListOrgID(orgId: orgId,type:type).ToResponse();
        }
    }
}

