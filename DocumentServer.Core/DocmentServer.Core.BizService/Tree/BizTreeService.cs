﻿using AutoMapper;
using DocmentServer.Core.DomainService.Company;
using DocmentServer.Core.DomainService.Employee;
using DocmentServer.Core.DomainService.Organization;
using DocumentServer.Core.Comm;
using Microsoft.AspNetCore.Http;
using System.Data;

/// <summary>
/// 进行树形构造
/// </summary>
namespace DocmentServer.Core.BizService.Tree
{
    public class BizTreeService : BaseService.BizBaseService, IBizTreeService
    {
        public IEmployeeDomainService employeeDomainService { get; set; }
        public IOrganizationDomainService organizationDomainService { get; set; }
        public ICompanyDomainService companyDomainService { get; set; }
        private TreeServiceExt ext;
        public BizTreeService(IHttpContextAccessor httpContext, IDbConnection dbConnection, IMapper mapper) : base(httpContext: httpContext, _mapper: mapper)
        {
           
        }

        /// <summary>
        /// 树形结构组装
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IResponseMessage Trees(int type, int pid)
        {
            ext = new TreeServiceExt(_employeeDomainService: employeeDomainService, _organizationDomainService: organizationDomainService, _companyDomainService: companyDomainService);
            return this.ext.JudgeTreeType(type: type, pId: pid).ToResponse();
        }
        /// <summary>
        /// 获取树形结构--组织结构
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IResponseMessage TreesOrg(int type, int pid)
        {
            ext = new TreeServiceExt(_employeeDomainService: employeeDomainService, _organizationDomainService: organizationDomainService, _companyDomainService: companyDomainService);
            return this.ext.JudgeOrgTreeType(type: type, pId: pid).ToResponse();
        }
    }
}
