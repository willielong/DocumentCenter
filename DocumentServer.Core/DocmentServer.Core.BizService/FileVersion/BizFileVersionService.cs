using DocmentServer.Core.DomainService.FileVersion;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.BizService.FileVersion
{
    class BizFileVersionService : BaseService.BizBaseService, IBizFileVersionService
    {
        private IFileVersionDomainService service;
        private IDbConnection dbConnection;

        public BizFileVersionService(IFileVersionDomainService service, IDbConnection dbConnection, IHttpContextAccessor httpContext) : base(httpContext: httpContext)
        {
            this.service = service;
            this.dbConnection = dbConnection;
            this.service.SettingCurrentEmp(employee: CurrentUser);
        }
        /// <summary>
        /// 添加版本信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本实体</param>
        /// <returns></returns>
        public IResponseMessage Add(FilesVersion model)
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
        /// 修改版本信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本实体</param>
        /// <returns></returns>
        public IResponseMessage Update(FilesVersion model)
        {
            model.modifier = CurrentUser.empid;
            return service.Update(model: model).ToResponse();
        }

        /// <summary>
        /// 删除版本信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本实体</param>
        /// <returns></returns>
        public IResponseMessage Delete(object id)
        {
            return service.Delete(id: id).ToResponse();
        }

        /// <summary>
        /// 获取版本信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本实体</param>
        /// <returns></returns>
        public IResponseMessage Get(object id)
        {
            return service.Get<FilesVersion>(id: id).ToResponse();
        }
        /// <summary>
        /// 获取版本信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">版本实体</param>
        /// <returns></returns>
        public IResponseMessage List(object id)
        {
            return service.List(id: id).ToResponse();
        }
        /// <summary>
        /// 获取所有版本数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IResponseMessage All()
        {
            return service.All<FilesVersion>().ToResponse();
        }
    }
}


