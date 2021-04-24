using AutoMapper;
using DocmentServer.Core.DomainService.Company;
using DocmentServer.Core.DomainService.Employee;
using DocmentServer.Core.DomainService.Organization;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Infrastrure;
using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.OnlyOfficeConfigModel;
using DocumentServer.Core.Model.Oupt;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using StackExchange.Redis;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text.Json;

namespace DocmentServer.Core.BizService.Company
{
    public class BizCompanyService : BaseService.BizBaseService, IBizCompanyService
    {
        public ICompanyDomainService service { get; set; }
        public IOrganizationDomainService organizationDomainService { get; set; }
        public IEmployeeDomainService employeeDomainService { get; set; }
        private ApiVersionsConfig config;


        public BizCompanyService(IConfiguration configuration) : base()
        {
            config = configuration.Get<ApiVersionsConfig>();
        }
        /// <summary>
        /// 添加单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        public IResponseMessage Add(UnitInfo model)
        {
            this.dbConnection.Open();
            var transaction = this.dbConnection.BeginTransaction();
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
            List<string> empIds = new List<string>();
            ///获取单位
            List<DocumentServer.Core.Model.DbModel.Organization> organizations = this.organizationDomainService.GetListByCompanyId(pid);
            organizations.ForEach(o => { empIds.Add(o.creator.ToString()); empIds.Add(o.head.ToString()); empIds.Add(o.c_head.ToString()); });
            ////获取组织
            List<DocumentServer.Core.Model.DbModel.UnitInfo> unitInfos = this.service.GetListByParentId(pid);
            unitInfos.ForEach(o => { empIds.Add(o.creator.ToString()); empIds.Add(o.head.ToString()); empIds.Add(o.c_head.ToString()); });
            ///获取所有人员
            Dictionary<int, string> employees = this.employeeDomainService.GetListByEmpIds(empIds);
            var redis = ConnectionMultiplexer.Connect($"{config.RedisAdress}:{config.RedisPort}");

            var Dd = redis.GetDatabase();
            Dd.StringSet("emp", employees.ToJsonString());
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
            ToViewModels<DocumentServer.Core.Model.DbModel.UnitInfo, TableOrgational>(unitInfos, out org);
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
            tables = tables.OrderBy(o => o.sequence).ToList();
            return tables.ToResponse();
        }
    }
}
