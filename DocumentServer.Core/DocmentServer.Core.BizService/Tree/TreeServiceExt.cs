using DocmentServer.Core.DomainService.Company;
using DocmentServer.Core.DomainService.Employee;
using DocmentServer.Core.DomainService.Organization;
using DocumentServer.Core.Model.Oupt;
using DocumetCenter.Core.Enum;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DocmentServer.Core.BizService.Tree
{
    public partial class BizTreeService
    {
        Dictionary<int, Func<int, int, List<TreeModel>>> dicTreeActions;
        Dictionary<int, Func<int, int, List<TreeModel>>> dicTreeOrgActions;
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
                treeModels.Add(new TreeModel() { name = c.cnname, id = c.unitid, pid = pId, type = type, icon = "el-icon-s-home", item = "primary", unitid = c.unitid, seq = c.sequence });
            });
            ///组装组织
            treeModels.AddRange(TreesOrganizationByCompayId(type: (int)FolderType.Organization, pId: pId));
            treeModels = treeModels.OrderBy(o => o.seq).ToList();
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
                treeModels.Add(new TreeModel() { name = c.cnname, id = c.orgid, pid = pId, type = type, icon = "el-icon-school", item = "success", unitid = pId, seq = c.sequence });
            });
            ///组装人员
            //treeModels.AddRange(TreesPerson(type: (int)FolderType.Personal, pId: pId));
            treeModels = treeModels.OrderBy(o => o.seq).ToList();
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
                treeModels.Add(new TreeModel() { name = c.cnname, id = c.orgid, pid = pId, type = type, icon = "el-icon-school", item = "success", unitid = c.untid, seq = c.sequence });
            });
            ///组装人员
            treeModels.AddRange(TreesPerson(type: (int)FolderType.Personal, pId: pId));
            treeModels = treeModels.OrderBy(o => o.seq).ToList();
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
                treeModels.Add(new TreeModel() { name = c.cnname, id = c.orgid, pid = pId, type = type, icon = "el-icon-school", item = "success", unitid = c.untid, seq = c.sequence });
            });
            treeModels = treeModels.OrderBy(o => o.seq).ToList();
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
                    treeModels.Add(new TreeModel() { name = o.cnname, id = o.empid, pid = -1, type = -1, icon = "el-icon-user", item = "warning", seq = o.sequence });
                });
            }
            treeModels = treeModels.OrderBy(o => o.seq).ToList();
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
