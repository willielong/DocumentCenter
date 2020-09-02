using DocmentServer.Core.DomainService.Company;
using DocmentServer.Core.DomainService.Organization;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.BizService.Organization
{
    public class BizOrganizationService : BaseService.BizBaseService, IBizOrganizationService
    {
        private IOrganizationDomainService service;
        private IDbConnection dbConnection;

        public BizOrganizationService(IOrganizationDomainService service, IDbConnection dbConnection, IHttpContextAccessor httpContext) : base(httpContext: httpContext)
        {
            this.service = service;
            this.dbConnection = dbConnection;
            this.service.SettingCurrentEmp(employee: employee);
        }
        /// <summary>
        /// 添加组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public IResponseMessage Add(DocumentServer.Core.Model.DbModel.Organization model)
        {
            dbConnection.Open();
            var transaction = dbConnection.BeginTransaction();
            long id = service.Add(model: model, transaction: transaction);
            transaction.Commit();
            return id.ToResponse();
        }
        /// <summary>
        /// 修改组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public IResponseMessage Update(DocumentServer.Core.Model.DbModel.Organization model)
        {
            return service.Update(model: model).ToResponse();
        }

        /// <summary>
        /// 删除组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public IResponseMessage Delete(object id)
        {
            return service.Delete(id: id).ToResponse();
        }

        /// <summary>
        /// 获取组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public IResponseMessage Get(object id)
        {
            return service.Get(id: id).ToResponse();
        }
        /// <summary>
        /// 获取组织信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public IResponseMessage List(object id)
        {
            return service.List(id: id).ToResponse();
        }
        /// <summary>
        /// 获取组织信息--多个-按工号
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public IResponseMessage GetListByCode(string code)
        {
            return service.GetListByCode(code: code).ToResponse();
        }
        /// <summary>
        /// 获取所有组织数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IResponseMessage All()
        {
            return service.All().ToResponse();
        }
    }
}
