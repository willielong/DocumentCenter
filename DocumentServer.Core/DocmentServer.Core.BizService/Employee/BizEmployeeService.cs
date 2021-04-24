using AutoMapper;
using DocmentServer.Core.DomainService.Employee;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.Oupt;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Data;
using System.Linq;

namespace DocmentServer.Core.BizService.Employee
{
    public class BizEmployeeService : BaseService.BizBaseService, IBizEmployeeService
    {
        public IEmployeeDomainService service { get; set; }

        public BizEmployeeService() : base()
        {
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
        /// <summary>
        /// 根据部门ID获取人员信息
        /// </summary>
        /// <param name="pid"></param>
        /// <returns></returns>
        public IResponseMessage TablePersonal(int pid)
        {

            List<TableEmployee> tableEmployees = service.TablePersonal(pid: pid);
            List<string> empids = new List<string>();
            var emps = service.GetAll();
            tableEmployees.ForEach(a =>
            {
                if (emps.Any(p => p.Key.ToString() == a.dic_creator))
                    a.dic_creator = emps[int.Parse(a.dic_creator)];
            });
            tableEmployees = tableEmployees.OrderBy(o => o.sequence).ToList();
            return tableEmployees.ToResponse();
        }
    }
}
