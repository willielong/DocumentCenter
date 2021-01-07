using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DocmentServer.Core.DomainService.BbTableInfo;
using DocmentServer.Core.DomainService.Employee;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using Microsoft.AspNetCore.Http;
using System.Linq;
using DocumentServer.Core.Model.Oupt;
using AutoMapper;

namespace DocmentServer.Core.BizService.BbTableInfo
{

    /// <summary>
    /// 描述：表结构信息操作类-实现
    /// </summary>
    public class BizBbTableInfoService : BaseService.BizBaseService, IBizBbTableInfoService
    {
        private IBbTableInfoDomainService domainService;
        private IDbConnection dbConnection;
        private IEmployeeDomainService employeeDomainService;
        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="httpContext"></param>
        /// <param name="_domainService">domain层</param>
        /// <param name="_dbConnection">数据库连接</param>
        public BizBbTableInfoService(IHttpContextAccessor httpContext, IBbTableInfoDomainService _domainService, IDbConnection _dbConnection, IEmployeeDomainService employeeDomainService, IMapper mapper) : base(httpContext: httpContext, _mapper: mapper)
        {
            this.domainService = _domainService;
            this.domainService.SettingCurrentEmp(employee: CurrentUser);///将用户的基本信息传入其他层
            this.dbConnection = _dbConnection;
            this.employeeDomainService = employeeDomainService;
        }
        /// <summary>
        /// 添加数据表信息
        /// </summary>
        /// </summary>
        /// <param name="model">数据表实体</param>
        /// <returns></returns>
        public IResponseMessage Add(Bb_TableInfo model)
        {
            //throw new NotImplementedException();
            model.creator = CurrentUser.empid;
            model.modifier = CurrentUser.empid;
            return domainService.Add(model: model).ToResponse();
        }
        /// <summary>
        /// 获取所有数据表数据
        /// </summary>
        /// <returns></returns>
        public IResponseMessage All()
        {
            List<Bb_TableInfo_OutPut> outPuts = new List<Bb_TableInfo_OutPut>();
            List<Bb_TableInfo> _TableInfos = this.domainService.All<Bb_TableInfo>().Where(o => o.isdel == false).ToList();
            List<DocumentServer.Core.Model.DbModel.Employee> employees = this.employeeDomainService.All<DocumentServer.Core.Model.DbModel.Employee>();
            outPuts = (from a1 in _TableInfos
                       join a2 in employees on a1.creator equals a2.empid
                       join a3 in employees on a1.modifier equals a3.empid
                       select new Bb_TableInfo_OutPut()
                       {
                           autoid = a1.autoid,
                           cnname = a1.cnname,
                           enname = a1.enname,
                           creatdate = a1.creatdate,
                           modifdate = a1.modifdate,
                           creator = a1.creator,
                           dic_creatdate = a1.creatdate.ToString("yyyy/MM/dd HH:mm"),
                           dic_creator = a2.cnname,
                           dic_modifier = a3.cnname,
                           dic_modifierdate = a1.modifdate.ToString("yyyy/MM/dd HH:mm"),
                           dic_enable = a1.enable ? "已启用" : "已禁用",
                           dic_is_system = a1.issystem ? "系统表" : "用户表",
                           tablecode = a1.tablecode,
                           enable = a1.enable,
                           isdel = a1.isdel,
                           issystem = a1.issystem,
                           modifier = a1.modifier,
                           sequence = a1.sequence
                       }).ToList();
            return outPuts.ToResponse();
        }
        /// <summary>
        /// 获取数据表信息
        /// </summary>
        /// </summary>
        /// <param name="model">数据表实体</param>
        /// <returns></returns>
        public IResponseMessage Get(object id)
        {
            Bb_TableInfo a1 = domainService.Get<Bb_TableInfo>(id: id);
            Bb_TableInfo_OutPut bb_TableInfo_OutPut = null;

            if (a1 != null)
            {
                bb_TableInfo_OutPut = new Bb_TableInfo_OutPut()
                {
                    autoid = a1.autoid,
                    cnname = a1.cnname,
                    enname = a1.enname,
                    creatdate = a1.creatdate,
                    modifdate = a1.modifdate,
                    creator = a1.creator,
                    dic_creatdate = a1.creatdate.ToString("yyyy/MM/dd HH:mm"),
                    dic_creator = this.domainService.Get<DocumentServer.Core.Model.DbModel.Employee>(a1.creator).cnname,
                    dic_modifier = this.domainService.Get<DocumentServer.Core.Model.DbModel.Employee>(a1.modifier).cnname,
                    dic_modifierdate = a1.modifdate.ToString("yyyy/MM/dd HH:mm"),
                    dic_enable = a1.enable ? "已启用" : "已禁用",
                    dic_is_system = a1.issystem ? "系统表" : "用户表",
                    tablecode = a1.tablecode,
                    enable = a1.enable,
                    isdel = a1.isdel,
                    issystem = a1.issystem,
                    modifier = a1.modifier,
                    sequence = a1.sequence
                };
            }
            return bb_TableInfo_OutPut.ToResponse();
        }
        /// <summary>
        /// 物理删除
        /// </summary>
        /// <param name="autoid"></param>
        /// <returns></returns>
        public IResponseMessage LogicDelete(object autoid)
        {
            return domainService.LogicDelete(autoid: autoid).ToResponse();
        }

        /// <summary>
        /// 启用/禁用
        /// </summary>
        /// <param name="autoid">主键</param>
        /// <param name="enable">启用/禁用</param>
        /// <returns></returns>
        public IResponseMessage OperationEnable(object autoid, bool enable)
        {
            return domainService.OperationEnable(autoid: autoid, enable: enable).ToResponse();
        }
        /// <summary>
        /// 修改数据表信息
        /// </summary>
        /// </summary>
        /// <param name="model">数据表实体</param>
        /// <returns></returns>
        public IResponseMessage Update(Bb_TableInfo model)
        {
            model.modifier = CurrentUser.empid;
            return domainService.Update(model: model).ToResponse();
        }
    }
}
