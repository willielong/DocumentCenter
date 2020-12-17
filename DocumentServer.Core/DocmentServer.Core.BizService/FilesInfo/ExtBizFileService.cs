using DocmentServer.Core.DomainService.IO;
using DocmentServer.Core.DomainService.Physicalhistory;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.OnlyOfficeConfigModel;
using DocumetCenter.Core.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;

namespace DocmentServer.Core.BizService.FilesInfo
{
    public class ExtBizFileService
    {
        /// <summary>
        /// 物理路径数据库
        /// </summary>
        private IPhysicalhistoryDomainService physicalhistoryDomainService { get; set; }
        private ISystemIODomainService systemIODomainService { get; set; }
        /// <summary>
        /// 当前用户
        /// </summary>
        private DocumentServer.Core.Model.DbModel.Employee CurrentUser { get; set; }
        public ExtBizFileService(DocumentServer.Core.Model.DbModel.Employee _CurrentUser, IPhysicalhistoryDomainService _physicalhistoryDomainService, ISystemIODomainService _systemIODomainService)
        {
            CurrentUser = _CurrentUser;
            physicalhistoryDomainService = _physicalhistoryDomainService;
            systemIODomainService = _systemIODomainService;
        }
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public Files CreateFile(Files model, IDbTransaction transaction = null)
        {
            ///找到在启用的文件夹
            DocumentServer.Core.Model.DbModel.Physicalhistory physicalhistory = physicalhistoryDomainService.SingleByEnable(transaction: transaction);
            ///判断是否最大
            if (systemIODomainService.IsFileMaxFolder(model: physicalhistory))
            {
                if (physicalhistory == null)
                {
                    physicalhistory = new DocumentServer.Core.Model.DbModel.Physicalhistory();
                }
                //创建新的文件夹
                physicalhistory = SettingPhysicalHistory(physicalhistory: physicalhistory);
                ///将之前的文件夹都禁用
                physicalhistoryDomainService.Edit(transaction: transaction);
                ///重新加入文件
                physicalhistory.autoid = (int)physicalhistoryDomainService.Add<DocumentServer.Core.Model.DbModel.Physicalhistory>(model: physicalhistory, transaction: transaction);///重新加入文件
            }
            model = systemIODomainService.MakeFile(files: model, physicalhistory: physicalhistory);
            return model;
        }

        /// <summary>
        /// 创建新的文件夹
        /// </summary>
        /// <param name="physicalhistory"></param>
        /// <returns></returns>
        private DocumentServer.Core.Model.DbModel.Physicalhistory SettingPhysicalHistory(DocumentServer.Core.Model.DbModel.Physicalhistory physicalhistory)
        {
            physicalhistory.creator = CurrentUser.empid;
            physicalhistory.modifier = CurrentUser.empid;
            physicalhistory.creatdate = DateTime.Now;
            physicalhistory.modifdate = DateTime.Now;
            physicalhistory.autoid = 0;
            physicalhistory.physicalfolder = Guid.NewGuid().ToString().Replace("-", "").Trim();
            physicalhistory.enable = true;
            return physicalhistory;
        }
        /// <summary>
        /// 组装版本信息
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public FilesVersion SettingNewFilesVersion(Files files)
        {
            List<ChangesConfig> changes = new List<ChangesConfig>();
            changes.Add(new ChangesConfig { created = DateTime.Now.ToString(), user = (new User() { id = CurrentUser.empid.ToString(), name = CurrentUser.cnname }) });
            return new FilesVersion { fileid = files.autoid, creator = CurrentUser.empid, creatdate = DateTime.Now, modifdate = DateTime.Now, modifier = CurrentUser.empid, filekey = files.fileuri.GenerateRevisionId(), version = 0, serverVersion = "5.6.3", changes = changes.ToJsonString(), changesUrl = "", prevuri = "" };
        }
        /// <summary>
        /// 进行OnlyOffice数据回调结构
        /// </summary>
        /// <param name="fileid"></param>
        /// <returns></returns>
        public FilesVersion TrackFile(Files files, OutOfficeConfigModel fileData)
        {
            FilesVersion filesVersion = systemIODomainService.TrackFile(files: files, fileData: fileData);        
            return filesVersion;
        }
        /// <summary>
        /// 获取配置文件
        /// </summary>
        /// <param name="editType"></param>
        /// <param name="systemType"></param>
        /// <param name="fileid"></param>
        /// <returns></returns>
        public OfficeConfig Config(ConfigModel model)
        {
            OfficeConfig officeConfig = new OfficeConfig();
            officeConfig.type = model.systemType.ToString();
            officeConfig.documentType = FileUtility.GetFileType("." + model.files.ext).ToString().ToLower();
            officeConfig.width = "100%";
            officeConfig.height = "100%";
            officeConfig.token = model.httpContext.Request.Headers["Authorization"].ToString().Substring("Bearer ".Length);
            officeConfig.document = GetDocumentConfig(model: model);
            officeConfig.editorConfig = GetEditorConfig(model: model);
            return officeConfig;
        }
        /// <summary>
        /// 配置文档
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public DocumentConfig GetDocumentConfig(ConfigModel model)
        {
            DocumentConfig document = new DocumentConfig();
            document.title = string.Format("{0}.{1}", model.files.cnname, model.files.ext);
            document.url = string.Concat(model.filePath.ApiUrl, model.files.fileuri);
            document.fileType = model.files.ext;
            document.key = model.files.fileuri.GetHashCode().ToString().GenerateRevisionId();
            document.info = new Author() { author = model.employee.cnname, created = model.files.creatdate.ToString("yyyy/MM/dd HH:mm") };
            document.permissions = GetPermissionsInfo(model: model);
            return document;
        }
        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public PermissionsInfo GetPermissionsInfo(ConfigModel model)
        {
            PermissionsInfo permissions = new PermissionsInfo();
            permissions.comment = model.editType != EditType.view && model.editType != EditType.fillForms && model.editType != EditType.embedded && model.editType != EditType.blockcontent;
            permissions.download = true;
            permissions.edit = FileUtility.EditedExts.Contains(string.Concat(".", model.files.ext)) && (model.editType != EditType.edit || model.editType != EditType.filter || model.editType != EditType.blockcontent);
            permissions.fillForms = model.editType != EditType.fillForms;
            permissions.modifyFilter = model.editType != EditType.filter;
            permissions.modifyContentControl = model.editType != EditType.blockcontent;
            permissions.review = model.editType == EditType.edit || model.editType == EditType.review;
            permissions.changeHistory = true;
            return permissions;
        }
        /// <summary>
        /// 获取编辑配置
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public EditorConfig GetEditorConfig(ConfigModel model)
        {
            EditorConfig editor = new EditorConfig();
            editor.mode = FileUtility.EditedExts.Contains(string.Concat(".", model.files.ext)) && model.editType != EditType.view ? EditType.edit.ToString() : EditType.view.ToString();
            editor.lang = "zh";
            editor.callbackUrl = GetCallbackUrl(file: model.files, path: model.filePath,employee:model.employee);
            editor.user = new User() { id = model.employee.empid.ToString(), name = model.employee.cnname };
            editor.embedded = new Embedded() { embedUrl = string.Concat(model.filePath.ApiUrl, model.files.fileuri), saveUrl = string.Concat(model.filePath.ApiUrl, model.files.fileuri), shareUrl = string.Concat(model.filePath.ApiUrl, model.files.fileuri), toolbarDocked = "top" };
            editor.customization = GetCustomizationInfo(model: model);
            editor.logo = new LogoInfo() { image = "", imageEmbedded = "", url = model.filePath.WebUrl };
            return editor;
        }
        /// <summary>
        /// 回调地址
        /// </summary>
        /// <param name="file"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public string GetCallbackUrl(Files file, FilePath path,DocumentServer.Core.Model.DbModel.Employee employee)
        {
            byte[] b = Encoding.Default.GetBytes(string.Format("{0}@@{1}",employee.empcode,employee.empid));
            return string.Concat(path.ApiUrl, "/api/file/v1.0/track?fileid=", file.autoid,"&token=",Convert.ToBase64String(b));
        }
        /// <summary>
        /// 配置自定义信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public CustomizationInfo GetCustomizationInfo(ConfigModel model)
        {
            CustomizationInfo customizationInfo = new CustomizationInfo();
            customizationInfo.chat = true;
            customizationInfo.help = false;
            customizationInfo.about = true;
            customizationInfo.feedback = new FeedBackInfo() { url = "", visible = false };
            customizationInfo.goback = GetGoBackInfo(model: model);
            customizationInfo.customer = GetCustomerInfo(model: model);
            return customizationInfo;
        }
        /// <summary>
        /// 获取返回信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private GoBackInfo GetGoBackInfo(ConfigModel model)
        {
            GoBackInfo info = new GoBackInfo();
            info.requestClose = true;
            info.blank = true;
            info.url = string.Concat(model.filePath.WebUrl, "/Index");
            return info;
        }
        /// <summary>
        /// 获取自定义关于信息
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        private CustomerInfo GetCustomerInfo(ConfigModel model)
        {
            CustomerInfo info = new CustomerInfo();
            info.address = "四川-成都-青羊-府南新区";
            info.info = "文档管理中心";
            info.www = string.Concat(model.filePath.WebUrl, "/Index");
            info.mail = "";
            info.name = "willie";
            info.logo = "";
            return info;
        }
        /// <summary>
        /// 获取Body中的值
        /// </summary>
        /// <param name="context"></param>
        /// <returns></returns>
        public string GetBody(HttpContext context)
        {
            string body = "";
            try
            {
                using (var receiveStream = context.Request.Body)
                using (var readStream = new StreamReader(receiveStream))
                {
                    body = readStream.ReadToEndAsync().Result;
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return body;
        }
    }
}
