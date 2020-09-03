﻿using DocmentServer.Core.Business.Organization;
using DocmentServer.Core.DomainService.Base;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.DomainService.Organization
{
    public class OrganizationDomainService : BaseDomainService, IOrganizationDomainService
    {
        private IOrganizationBusiness business;
        public OrganizationDomainService(IOrganizationBusiness business) : base(business)
        {
            this.business = business;
        }
        /// <summary>
        /// 删除组织信息
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return business.Delete(id: id, transaction: transaction);
        }
        /// <summary>
        /// 获取组织信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Organization> List(object id, IDbTransaction transaction = null)
        {
            return business.List(id: id, transaction: transaction);
        }
        /// <summary>
        /// 获取组织信息--多个-按工号
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Organization> GetListByCode(string code, IDbTransaction transaction = null)
        {
            return business.GetListByCode(code: code, transaction: transaction);
        }

        /// <summary>
        /// 获取组织信息--多个--按单位
        /// </summary>
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Organization> GetListByCompanyId(int companyId, IDbTransaction transaction = null)
        {
            return business.GetListByCompanyId(companyId: companyId, transaction: transaction);
        }
        /// <summary>
        /// 获取组织信息--多个--按上级组织
        /// </summary>
        /// <param name="model">组织实体</param>
        /// <returns></returns>
        public List<DocumentServer.Core.Model.DbModel.Organization> GetListByParentId(int parentId, IDbTransaction transaction = null)
        {
            return business.GetListByParentId(parentId: parentId, transaction: transaction);
        }
    }
}
