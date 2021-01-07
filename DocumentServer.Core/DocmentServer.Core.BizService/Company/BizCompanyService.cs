using DocmentServer.Core.DomainService.Company;
using DocmentServer.Core.DomainService.Employee;
using DocmentServer.Core.DomainService.Organization;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.Oupt;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Linq;
using AutoMapper;

namespace DocmentServer.Core.BizService.Company
{
    public class BizCompanyService : BaseService.BizBaseService, IBizCompanyService
    {
        private ICompanyDomainService service;
        private IDbConnection dbConnection;
        private IOrganizationDomainService organizationDomainService;
        private IEmployeeDomainService employeeDomainService;

        public BizCompanyService(ICompanyDomainService service, IOrganizationDomainService _organizationDomainService, IEmployeeDomainService _employeeDomainService, IDbConnection dbConnection, IHttpContextAccessor httpContext, IMapper mapper) : base(httpContext: httpContext, _mapper: mapper)
        {
            this.service = service;
            this.organizationDomainService = _organizationDomainService;
            this.dbConnection = dbConnection;
            this.employeeDomainService = _employeeDomainService;
            this.service.SettingCurrentEmp(employee: CurrentUser);
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
            model.creator = CurrentUser.empid;
            model.modifier = CurrentUser.empid;
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
            model.modifier = CurrentUser.empid;
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
        /// <summary>
        /// 获取子级组织
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public IResponseMessage GetTableCompany(int pid)
        {
            List<TableOrgational> tables = new List<TableOrgational>();
            ///获取单位
            List<DocumentServer.Core.Model.DbModel.Organization> organizations = this.organizationDomainService.GetListByCompanyId(pid);
            ////获取组织
            List<DocumentServer.Core.Model.DbModel.UnitInfo> unitInfos = this.service.GetListByParentId(pid);
            ///获取所有人员
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
                                             dic_orgtype= DocumetCenter.Core.Enum.OrgationalType.Organization.ConvertToDicOrgTypeString(),
                                             unitid=a1.untid
                                         }).ToList();
            tables.AddRange(org);
            List<TableOrgational> unitInfo = (from a1 in unitInfos
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
                                                  id = a1.unitid,
                                                  orgcode = a1.unitcode,
                                                  orgtype = DocumetCenter.Core.Enum.OrgationalType.Unit,
                                                  parentid = a1.parentId,
                                                  sequence = a1.sequence,
                                                  dic_orgtype= DocumetCenter.Core.Enum.OrgationalType.Unit.ConvertToDicOrgTypeString(),
                                                  unitid=a1.unitid
                                              }).ToList();
            tables.AddRange(unitInfo);
            tables = tables.OrderBy(o => o.sequence).ToList();
            return tables.ToResponse();
        }
    }
}
