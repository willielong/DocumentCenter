using AutoMapper;
using DocmentServer.Core.DomainService.Company;
using DocmentServer.Core.DomainService.Employee;
using DocmentServer.Core.DomainService.Organization;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.Oupt;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;

/// <summary>
/// 进行树形构造
/// </summary>
namespace DocmentServer.Core.BizService.Tree
{
    public partial class BizTreeService : BaseService.BizBaseService, IBizTreeService
    {

        public IEmployeeDomainService employeeDomainService { get; set; }
        public IOrganizationDomainService organizationDomainService { get; set; }
        public ICompanyDomainService companyDomainService { get; set; }
        public BizTreeService(IMapper mapper) : base(_mapper: mapper)
        {
            dicTreeActions = new Dictionary<int, Func<int, int, List<TreeModel>>>();
            dicTreeOrgActions = new Dictionary<int, Func<int, int, List<TreeModel>>>();
            dicTreeActions.Add(0, TreesCompany);
            dicTreeActions.Add(1, TreesOrganization);
            dicTreeActions.Add(2, TreesPerson);
            dicTreeActions.Add(-1, TreesPerson);
            dicTreeOrgActions.Add(0, TreesCompany);
            dicTreeOrgActions.Add(1, TreesOrganizationUnPerson);
        }
        /// <summary>
        /// 树形结构组装
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IResponseMessage Trees(int type, int pid)
        {
            return JudgeTreeType(type: type, pId: pid).ToResponse();
        }
        /// <summary>
        /// 获取树形结构--组织结构
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public IResponseMessage TreesOrg(int type, int pid)
        {
            return JudgeOrgTreeType(type: type, pId: pid).ToResponse();
        }
    }
}
