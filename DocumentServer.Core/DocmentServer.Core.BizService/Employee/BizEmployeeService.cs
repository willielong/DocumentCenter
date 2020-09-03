using DocmentServer.Core.DomainService.Employee;
using DocumentServer.Core.Comm;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.BizService.Employee
{
    public class BizEmployeeService : BaseService.BizBaseService, IBizEmployeeService
    {
        private IEmployeeDomainService service;
        private IDbConnection dbConnection;

        public BizEmployeeService(IEmployeeDomainService service, IDbConnection dbConnection, IHttpContextAccessor httpContext) : base(httpContext: httpContext)
        {
            this.service = service;
            this.dbConnection = dbConnection;
            this.service.SettingCurrentEmp(employee: CurrentUser);
        }
        /// <summary>
        /// 添加人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public IResponseMessage Add(DocumentServer.Core.Model.DbModel.Employee model)
        {
            dbConnection.Open();
            model.creator = CurrentUser.empid;
            model.modifier = CurrentUser.empid;
            var transaction = dbConnection.BeginTransaction();
            long id = service.Add(model: model, transaction: transaction);
            transaction.Commit();
            return id.ToResponse();
        }
        /// <summary>
        /// 修改人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public IResponseMessage Update(DocumentServer.Core.Model.DbModel.Employee model)
        {
            model.modifier = CurrentUser.empid;
            return service.Update(model: model).ToResponse();
        }

        /// <summary>
        /// 删除人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public IResponseMessage Delete(object id)
        {
            return service.Delete(id: id).ToResponse();
        }

        /// <summary>
        /// 获取人员基本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public IResponseMessage Get(object id)
        {
            return service.Get<DocumentServer.Core.Model.DbModel.Employee>(id: id).ToResponse();
        }
        /// <summary>
        /// 获取人员基本信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public IResponseMessage List(object id)
        {
            return service.List(id: id).ToResponse();
        }
        /// <summary>
        /// 获取人员基本信息信息--多个-按工号
        /// </summary>
        /// </summary>
        /// <param name="model">人员基本信息实体</param>
        /// <returns></returns>
        public IResponseMessage GetListByCode(string code)
        {
            return service.GetListByCode(code: code).ToResponse();
        }
        /// <summary>
        /// 获取所有人员基本信息数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IResponseMessage All()
        {
            return service.All<DocumentServer.Core.Model.DbModel.Employee>().ToResponse();
        }
    }
}
