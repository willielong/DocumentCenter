using AutoMapper;
using DocmentServer.Core.DomainService.Employee;
using DocmentServer.Core.DomainService.FilesInfo;
using DocmentServer.Core.DomainService.FileVersion;
using DocmentServer.Core.DomainService.Folder;
using DocmentServer.Core.DomainService.IO;
using DocmentServer.Core.DomainService.Physicalhistory;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.OnlyOfficeConfigModel;
using DocumetCenter.Core.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace DocmentServer.Core.BizService.FilesInfo
{
    public class BizFilesService : BaseService.BizBaseService, IBizFilesService
    {
        private IFilesDomainService service { get; set; }
        public IFolderDomainService folderDomainService { get; set; }
        private IDbConnection dbConnection;
        private ExtBizFileService extBizFileService;
        public IFileVersionDomainService fileVersionDomainService { get; set; }
        public IEmployeeDomainService employeeDomainService { get; set; }
        public FilePath filePath;

        public BizFilesService(IConfiguration configuration, IDbConnection dbConnection, IHttpContextAccessor httpContext, IPhysicalhistoryDomainService _physicalhistoryDomainService, ISystemIODomainService _systemIODomainService, IFilesDomainService _service, IMapper mapper) : base(httpContext: httpContext, _mapper: mapper)
        {
            this.service = _service;
            this.dbConnection = dbConnection;
            this.service.SettingCurrentEmp(employee: CurrentUser);
            extBizFileService = new ExtBizFileService(_CurrentUser: CurrentUser, _physicalhistoryDomainService: _physicalhistoryDomainService, _systemIODomainService: _systemIODomainService);
            ///获取配置文件中的数据
            filePath = configuration.Get<ApiVersionsConfig>().FilePath;
        }
        /// <summary>
        /// 添加文件信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件信息实体</param>
        /// <returns></returns>
        public IResponseMessage Add(Files model)
        {
            dbConnection.Open();
            long id = 0;
            IDbTransaction transaction = dbConnection.BeginTransaction();
            model.creator = CurrentUser.empid;
            model.modifier = CurrentUser.empid;
            var folder = folderDomainService.Get<DocumentServer.Core.Model.DbModel.FileFloder>(id: model.folderid, transaction: transaction);
            if (folder != null)
            {
                model.path = folder.path;
                model = extBizFileService.CreateFile(model: model, transaction: transaction);
                id = service.Add(model: model, transaction: transaction);
                model.autoid = (int)id;
                var version = extBizFileService.SettingNewFilesVersion(files: model);
                version.serverVersion = filePath.ServerVersion;
                ///添加版本信息
                fileVersionDomainService.Add<FilesVersion>(model: version, transaction: transaction);
            }
            transaction.Commit();
            return id.ToResponse();
        }
        /// <summary>
        /// 修改文件信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件信息实体</param>
        /// <returns></returns>
        public IResponseMessage Update(Files model)
        {
            model.modifier = CurrentUser.empid;
            return service.Update(model: model).ToResponse();
        }

        /// <summary>
        /// 删除文件信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件信息实体</param>
        /// <returns></returns>
        public IResponseMessage Delete(object id)
        {
            return service.Delete(id: id).ToResponse();
        }

        /// <summary>
        /// 获取文件信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件信息实体</param>
        /// <returns></returns>
        public IResponseMessage Get(object id)
        {
            return service.Get<Files>(id: id).ToResponse();
        }
        /// <summary>
        /// 获取文件信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">文件信息实体</param>
        /// <returns></returns>
        public IResponseMessage List(object id)
        {
            return service.List(id: id).ToResponse();
        }
        /// <summary>
        /// 获取所有文件信息数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IResponseMessage All()
        {
            return service.All<Files>().ToResponse();
        }
        /// <summary>
        /// 进行OnlyOffice数据回调结构
        /// </summary>
        /// <param name="fileid"></param>
        /// <returns></returns>
        public string TrackFile(int fileid, string token)
        {
            string message = "{\"error\":0}";
            string body = extBizFileService.GetBody(context: context);
            if (string.IsNullOrEmpty(body)) return "{\"error\":0}";
            OutOfficeConfigModel fileData = JsonSerializer.DeserializeFromString<OutOfficeConfigModel>(body);
            switch (fileData.status)
            {
                case TrackerStatus.MustSave:
                case TrackerStatus.Corrupted:
                    {
                        dbConnection.Open();
                        var tran = dbConnection.BeginTransaction();
                        Files files = service.Get<Files>(id: fileid, transaction: tran);
                        if (null != files)
                        {
                            var byt = Convert.FromBase64String(token);
                            string value = Encoding.Default.GetString(byt).Split(new string[] { "@@" }, StringSplitOptions.RemoveEmptyEntries)[1];
                            DocumentServer.Core.Model.DbModel.Employee employee = employeeDomainService.Get<DocumentServer.Core.Model.DbModel.Employee>(id: int.Parse(value), transaction: tran);
                            files.currentVersion = files.currentVersion + 1; 
                            files.modifier = employee.empid;
                            files.modifdate = DateTime.Now;
                            FilesVersion filesVersion = extBizFileService.TrackFile(files: files, fileData: fileData);
                            filesVersion.creator = employee.empid;
                            filesVersion.modifier = employee.empid;
                            service.Update<Files>(model: files, transaction: tran);
                            fileVersionDomainService.Add<FilesVersion>(filesVersion);
                            tran.Commit();
                        }
                    }
                    break;
                default: { } break;
            }
            return message;
        }
        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="editType"></param>
        /// <param name="systemType"></param>
        /// <param name="fileid"></param>
        /// <returns></returns>
        public IResponseMessage Config(int editType, int systemType, int fileid)
        {
            ///获取文件
            Files files = service.Get<Files>(id: fileid);
            ///获取编辑模式
            EditType eType = (EditType)editType;
            ///获取系统
            SystemType system = (SystemType)systemType;
            List<FilesVersion> versions = fileVersionDomainService.All<FilesVersion>();
            FilesVersion version = null;
            if (versions.Any())
            {
                version = versions.FirstOrDefault(o => o.version == 0);
            }
            return extBizFileService.Config(model: new ConfigModel() { editType = eType, systemType = system, filePath = filePath, files = files, httpContext = context, version = version, employee = employeeDomainService.Get<DocumentServer.Core.Model.DbModel.Employee>(id: files.creator) }).ToResponse();
        }

    }
}
