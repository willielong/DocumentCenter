using DocmentServer.Core.DomainService.Company;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.BizService.Company
{
    public class BizCompanyService : BaseService.BizBaseService, IBizCompanyService
    {
        private ICompanyDomainService service;
        private IDbConnection dbConnection;

        public BizCompanyService(ICompanyDomainService service, IDbConnection dbConnection, IHttpContextAccessor httpContext) : base(httpContext: httpContext)
        {
            this.service = service;
            this.dbConnection = dbConnection;
            this.service.SettingCurrentEmp(employee: employee);
        }
        /// <summary>
        /// 添加单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public IResponseMessage Add(UnitInfo model)
        {
            dbConnection.Open();
            var transaction = dbConnection.BeginTransaction();
            long id = service.Add(model: model, transaction: transaction);
            transaction.Commit();
            return id.ToResponse();
        }
        /// <summary>
        /// 修改单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public IResponseMessage Update(UnitInfo model)
        {
            return service.Update(model: model).ToResponse();
        }

        /// <summary>
        /// 删除单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public IResponseMessage Delete(object id)
        {
            return service.Delete(id: id).ToResponse();
        }

        /// <summary>
        /// 获取单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public IResponseMessage Get(object id)
        {
            return service.Get<DocumentServer.Core.Model.DbModel.UnitInfo>(id: id).ToResponse();
        }
        /// <summary>
        /// 获取单位信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public IResponseMessage List(object id)
        {
            return service.List(id: id).ToResponse();
        }
        /// <summary>
        /// 获取单位信息--多个-按工号
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public IResponseMessage GetListByCode(string code)
        {
            return service.GetListByCode(code: code).ToResponse();
        }
        /// <summary>
        /// 获取所有单位数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IResponseMessage All()
        {
            return service.All<DocumentServer.Core.Model.DbModel.UnitInfo>().ToResponse();
        }
    }
}
