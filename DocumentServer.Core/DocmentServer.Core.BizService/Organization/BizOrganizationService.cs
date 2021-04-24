using AutoMapper;
using DocmentServer.Core.DomainService.Employee;
using DocmentServer.Core.DomainService.Organization;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.Oupt;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DocmentServer.Core.BizService.Organization
{
    public class BizOrganizationService : BaseService.BizBaseService, IBizOrganizationService
    {
        public IOrganizationDomainService service { get; set; }
        public IEmployeeDomainService employeeDomainService { get; set; }

        public BizOrganizationService() : base()
        {
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
            model.creator = CurrentUser.empid;
            model.modifier = CurrentUser.empid;
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
            model.modifier = CurrentUser.empid;
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
            return service.Get<DocumentServer.Core.Model.DbModel.Organization>(id: id).ToResponse();
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
            return service.All<DocumentServer.Core.Model.DbModel.Organization>().ToResponse();
        }
        /// <summary>
        /// 获取子级部门
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public IResponseMessage GetTableOrganization(int pid)
        {
            List<TableOrgational> tables = new List<TableOrgational>();
            ///获取单位
            List<DocumentServer.Core.Model.DbModel.Organization> organizations = this.service.GetListByParentId(pid);
            ///获取所有人员
            Dictionary<int, string> employees = this.employeeDomainService.GetAll();
            List<TableOrgational> org = new List<TableOrgational>();
            ToViewModels<DocumentServer.Core.Model.DbModel.Organization, TableOrgational>(organizations, out org);
            org.ForEach(o =>
            {
                if (employees.Any(l => l.Key == o.creator))
                {
                    o.dic_creator = employees[o.creator];
                }
                if (employees.Any(l => l.Key == o.head))
                {
                    o.dic_head = employees[o.head];
                }
                if (employees.Any(l => l.Key.ToString() == o.c_head))
                {
                    o.dic_c_head = employees[int.Parse(o.c_head)];
                }
            });
            tables.AddRange(org);
            tables = tables.OrderBy(o => o.seq).ToList();
            return tables.ToResponse();
        }
    }
}
