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
        private IOrganizationDomainService service;
        private IDbConnection dbConnection;
        private IEmployeeDomainService employeeDomainService;

        public BizOrganizationService(IOrganizationDomainService service, IEmployeeDomainService _employeeDomainService, IDbConnection dbConnection, IHttpContextAccessor httpContext, IMapper mapper) : base(httpContext: httpContext, _mapper: mapper)
        {
            this.service = service;
            this.dbConnection = dbConnection;
            this.employeeDomainService = _employeeDomainService;
            this.service.SettingCurrentEmp(employee: CurrentUser);
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
            List<DocumentServer.Core.Model.DbModel.Employee> employees = this.employeeDomainService.All<DocumentServer.Core.Model.DbModel.Employee>();
            List<TableOrgational> org = (from a1 in organizations
                                         join a2 in employees on a1.head equals a2.empid
                                         join a3 in employees on a1.c_head equals a3.empid.ToString()
                                         join a4 in employees on a1.creator equals a4.empid
                                         select new TableOrgational()
                                         {
                                             cnname = a1.cnname,
                                             dic_createdate = a1.creatdate.ToString("yyyy-MM-dd HH:mm"),
                                             dic_creator = a4.cnname,
                                             dic_c_head = a3.cnname,
                                             dic_head = a2.cnname,
                                             enname = a1.enname,
                                             id = a1.orgid,
                                             orgcode = a1.orgcode,
                                             orgtype = DocumetCenter.Core.Enum.OrgationalType.Organization,
                                             parentid = a1.parentId,
                                             sequence = a1.sequence,
                                             dic_orgtype = DocumetCenter.Core.Enum.OrgationalType.Organization.ConvertToDicOrgTypeString(),
                                             unitid=a1.untid,
                                             seq=a1.sequence
                                         }).ToList();
            tables.AddRange(org);
            tables = tables.OrderBy(o => o.seq).ToList();
            return tables.ToResponse();
        }
    }
}
