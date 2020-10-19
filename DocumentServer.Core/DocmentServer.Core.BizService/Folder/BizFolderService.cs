using DocmentServer.Core.DomainService.FilesInfo;
using DocmentServer.Core.DomainService.Folder;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.Oupt;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DocumentServer.Core.Comm;
using DocumetCenter.Core.Enum;

namespace DocmentServer.Core.BizService.Folder
{
    public class BizFolderService : BaseService.BizBaseService, IBizFolderService
    {
        private IFolderDomainService service;
        private IDbConnection dbConnection;
        private IFilesDomainService fileDomainService;
        public BizFolderService(IFolderDomainService service, IDbConnection dbConnection, IHttpContextAccessor httpContext, IFilesDomainService _filesDomainService) : base(httpContext: httpContext)
        {
            this.service = service;
            this.dbConnection = dbConnection;
            this.service.SettingCurrentEmp(employee: CurrentUser);
            this.fileDomainService = _filesDomainService;
        }
        /// <summary>
        /// 添加账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public IResponseMessage Add(FileFloder model)
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
        /// 修改账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public IResponseMessage Update(FileFloder model)
        {
            model.modifier = CurrentUser.empid;
            return service.Update(model: model).ToResponse();
        }

        /// <summary>
        /// 删除账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public IResponseMessage Delete(object id)
        {
            return service.Delete(id: id).ToResponse();
        }

        /// <summary>
        /// 获取账户信息
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public IResponseMessage Get(object id)
        {
            return service.Get<FileFloder>(id: id).ToResponse();
        }
        /// <summary>
        /// 获取账户信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">账户实体</param>
        /// <returns></returns>
        public IResponseMessage List(object id)
        {
            return service.List(id: id).ToResponse();
        }
        /// <summary>
        /// 获取所有账户数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IResponseMessage All()
        {
            return service.All<FileFloder>().ToResponse();
        }

        /// <summary>
        /// 获取文件夹信息--多个-- 按组织ID
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        public IResponseMessage GetFoldersByOrgId(int orgId, int type)
        {
            return service.GetListOrgID(orgId: orgId, type: type).ToResponse();
        }
        /// <summary>
        /// 获取文件列表-按组织-按上级Id
        /// </summary>
        /// <param name="orgId"></param>
        /// <param name="type"></param>
        /// <param name="pid"></param>
        /// <returns></returns>
        public IResponseMessage GetFolders(int orgId, int type, int pid)
        {
            //return service.GetFolders(orgId: orgId, type: type,pid:pid).ToResponse();
            List<TreeTableModel> treeTables = new List<TreeTableModel>();
            List<FileFloder> fileFloders = new List<FileFloder>();
            List<Files> files = new List<Files>();
            if (pid == 0)
            {
                fileFloders = service.GetListOrgID(orgId: orgId, type: type);
            }
            else
            {
                fileFloders = service.GetFolders(pid: pid);
                files = fileDomainService.GetFiles(folderid: pid);
            }
            fileFloders.ForEach(o =>
            {
                treeTables.Add(new TreeTableModel() { cnname = o.cnname, enname = o.enname, currentVersion = "", dic_filetype = TextType.文件夹.ToString(), dic_orgtype = type.ConvertToOrgTypeString(), ext = "", filetype = (int)TextType.文件夹, id = o.autoid, orgtype = type, sequence = o.sequence, size = "",path=o.path,orgid=o.orgid });
            });
            files.ForEach(o =>
            {
                treeTables.Add(new TreeTableModel() { cnname = o.cnname, enname = o.enname, currentVersion = o.currentVersion, dic_filetype = o.ext.ConvertToExt(), dic_orgtype = type.ConvertToOrgTypeString(), ext = o.ext, filetype = o.ext.ConvertToExtInt(), id = o.autoid, orgtype = type, sequence = o.sequence, size = o.size.ToString() + " kb",path=o.path,orgid=orgId});
            });
            return treeTables.ToResponse();
        }
    }
}

