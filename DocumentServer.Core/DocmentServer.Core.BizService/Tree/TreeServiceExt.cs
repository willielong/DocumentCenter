using DocmentServer.Core.DomainService.Company;
using DocmentServer.Core.DomainService.Employee;
using DocmentServer.Core.DomainService.Organization;
using DocumentServer.Core.Model.Oupt;
using DocumetCenter.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DocmentServer.Core.BizService.Tree
{
    public class TreeServiceExt
    {
        Dictionary<int, Func<int, int, List<TreeModel>>> dicTreeActions;
        Dictionary<int, Func<int, int, List<TreeModel>>> dicTreeOrgActions;
        private IEmployeeDomainService employeeDomainService;
        private IOrganizationDomainService organizationDomainService;
        private ICompanyDomainService companyDomainService;
        public TreeServiceExt(IEmployeeDomainService _employeeDomainService, IOrganizationDomainService _organizationDomainService, ICompanyDomainService _companyDomainService)
        {
            dicTreeActions = new Dictionary<int, Func<int, int, List<TreeModel>>>();
            dicTreeOrgActions = new Dictionary<int, Func<int, int, List<TreeModel>>>();
            dicTreeActions.Add(0, TreesCompany);
            dicTreeActions.Add(1, TreesOrganization);
            dicTreeActions.Add(2, TreesPerson); 
            dicTreeActions.Add(-1, TreesPerson);
            dicTreeOrgActions.Add(0, TreesCompany);
            dicTreeOrgActions.Add(1, TreesOrganizationUnPerson);
            this.employeeDomainService = _employeeDomainService;
            this.organizationDomainService = _organizationDomainService;
            this.companyDomainService = _companyDomainService;
        }
        /// <summary>
        /// 获取单位
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pId"></param>
        /// <returns></returns>
        private List<TreeModel> TreesCompany(int type, int pId)
        {
            ///组装单位
            List<TreeModel> treeModels = new List<TreeModel>();
            var companys = this.companyDomainService.GetListByParentId(parentId: pId);
            companys.ForEach(c =>
            {
                treeModels.Add(new TreeModel() { name = c.cnname, id = c.unitid, pid = pId, type = type, icon = "el-icon-s-home", item = "primary" });
            });
            ///组装组织
            treeModels.AddRange(TreesOrganizationByCompayId(type: (int)FolderType.Organization, pId: pId));

            return treeModels;
        }
        /// <summary>
        /// 获取组织
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pId"></param>
        /// <returns></returns>
        private List<TreeModel> TreesOrganizationByCompayId(int type, int pId)
        {
            ///组装组织
            List<TreeModel> treeModels = new List<TreeModel>();
            List<DocumentServer.Core.Model.DbModel.Organization> organizations;
            organizations = this.organizationDomainService.GetListByCompanyId(companyId: pId);
            organizations.ForEach(c =>
            {
                treeModels.Add(new TreeModel() { name = c.cnname, id = c.orgid, pid = pId, type = type, icon = "el-icon-school", item = "success", unitid = pId, });
            });
            ///组装人员
            //treeModels.AddRange(TreesPerson(type: (int)FolderType.Personal, pId: pId));
            return treeModels;
        }

        /// <summary>
        /// 获取组织
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pId"></param>
        /// <returns></returns>
        private List<TreeModel> TreesOrganization(int type, int pId)
        {
            ///组装组织
            List<TreeModel> treeModels = new List<TreeModel>();
            List<DocumentServer.Core.Model.DbModel.Organization> organizations;
            organizations = this.organizationDomainService.GetListByParentId(parentId: pId);
            organizations.ForEach(c =>
            {
                treeModels.Add(new TreeModel() { name = c.cnname, id = c.orgid, pid = pId, type = type, icon = "el-icon-school", item = "success", unitid = c.untid });
            });
            ///组装人员
            treeModels.AddRange(TreesPerson(type: (int)FolderType.Personal, pId: pId));
            return treeModels;
        }
        /// <summary>
        /// 获取组织--不包含人员
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pId"></param>
        /// <returns></returns>
        private List<TreeModel> TreesOrganizationUnPerson(int type, int pId)
        {
            ///组装组织
            List<TreeModel> treeModels = new List<TreeModel>();
            List<DocumentServer.Core.Model.DbModel.Organization> organizations;
            organizations = this.organizationDomainService.GetListByParentId(parentId: pId);
            organizations.ForEach(c =>
            {
                treeModels.Add(new TreeModel() { name = c.cnname, id = c.orgid, pid = pId, type = type, icon = "el-icon-school", item = "success", unitid = c.untid });
            });
            return treeModels;
        }
        /// <summary>
        /// 获取人员
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pId"></param>
        /// <returns></returns>
        private List<TreeModel> TreesPerson(int type, int pId)
        {
            List<TreeModel> treeModels = new List<TreeModel>();
            if (type != -1)
            {
                var emps = this.employeeDomainService.GetListByOrgId(orgId: pId);
                emps.ForEach(o =>
                {
                    treeModels.Add(new TreeModel() { name = o.cnname, id = o.empid, pid = -1, type = -1, icon = "el-icon-user", item = "warning" });
                });
            }
            return treeModels;
        }
        /// <summary>
        /// 判断是那种类型
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pId"></param>
        /// <returns></returns>
        public List<TreeModel> JudgeTreeType(int type, int pId)
        {
            return this.dicTreeActions[type].Invoke(type, pId);
        }
        /// <summary>
        /// 判断是那种类型
        /// </summary>
        /// <param name="type"></param>
        /// <param name="pId"></param>
        /// <returns></returns>
        public List<TreeModel> JudgeOrgTreeType(int type, int pId)
        {
            return this.dicTreeOrgActions[type].Invoke(type, pId);
        }
    }
}
