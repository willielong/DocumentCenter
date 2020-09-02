using DocmentServer.Core.DomainService.FilesInfo;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.BizService.FilesInfo
{
    public class BizFilesService : BaseService.BizBaseService, IBizFilesService
    {
        private IFilesDomainService service;
        private IDbConnection dbConnection;

        public BizFilesService(IFilesDomainService service, IDbConnection dbConnection, IHttpContextAccessor httpContext) : base(httpContext: httpContext)
        {
            this.service = service;
            this.dbConnection = dbConnection;
            this.service.SettingCurrentEmp(employee: employee);
        }
        /// <summary>
        /// 添加账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public IResponseMessage Add(Files model)
        {
            dbConnection.Open();
            var transaction = dbConnection.BeginTransaction();
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
        public IResponseMessage Update(Files model)
        {
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
        /// <param name="model">文件信息实体</param>
        /// <returns></returns>
        public IResponseMessage Get(object id)
        {
            return service.Get<Files>(id: id).ToResponse();
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
            return service.All<Files>().ToResponse();
        }
    }
}
