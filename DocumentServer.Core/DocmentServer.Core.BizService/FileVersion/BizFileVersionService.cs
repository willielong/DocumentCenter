using AutoMapper;
using DocmentServer.Core.DomainService.Employee;
using DocmentServer.Core.DomainService.FilesInfo;
using DocmentServer.Core.DomainService.FileVersion;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.OnlyOfficeConfigModel;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Data;

namespace DocmentServer.Core.BizService.FileVersion
{
    class BizFileVersionService : BaseService.BizBaseService, IBizFileVersionService
    {
        public IFileVersionDomainService service { get; set; }
        public IEmployeeDomainService employeeDomainService { get; set; }
        private FilePath filePath;
        public IFilesDomainService filesDomainService { get; set; }
        private ExtBizFileVersionService extBizFileVersion;

        public BizFileVersionService(IConfiguration configuration, IMapper mapper) : base(_mapper: mapper)
        {
            ///获取配置文件中的数据
            filePath = configuration.Get<ApiVersionsConfig>().FilePath;
            extBizFileVersion = new ExtBizFileVersionService();
        }
        /// <summary>
        /// 添加版本信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本实体</param>
        /// <returns></returns>
        public IResponseMessage Add(FilesVersion model)
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
        /// 修改版本信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本实体</param>
        /// <returns></returns>
        public IResponseMessage Update(FilesVersion model)
        {
            model.modifier = CurrentUser.empid;
            return service.Update(model: model).ToResponse();
        }

        /// <summary>
        /// 删除版本信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本实体</param>
        /// <returns></returns>
        public IResponseMessage Delete(object id)
        {
            return service.Delete(id: id).ToResponse();
        }

        /// <summary>
        /// 获取版本信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本实体</param>
        /// <returns></returns>
        public IResponseMessage Get(object id)
        {
            return service.Get<FilesVersion>(id: id).ToResponse();
        }
        /// <summary>
        /// 获取版本信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">版本实体</param>
        /// <returns></returns>
        public IResponseMessage List(object id)
        {
            return service.List(id: id).ToResponse();
        }
        /// <summary>
        /// 获取所有版本数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public IResponseMessage All()
        {
            return service.All<FilesVersion>().ToResponse();
        }
        /// <summary>
        /// 获取所有的历史信息
        /// </summary>
        /// <param name="fileid"></param>
        /// <returns></returns>
        public IResponseMessage refreshHistory(int fileid)
        {
            ///获取该文件的所有版本
            List<FilesVersion> versions = service.GetVersionsByFileId(fileid: fileid);
            ///获取文件
            Files file = filesDomainService.Get<Files>(id: fileid);
            List<DocumentServer.Core.Model.DbModel.Employee> employees = employeeDomainService.All<DocumentServer.Core.Model.DbModel.Employee>();
            return extBizFileVersion.refreshHistory(file: file, versions: versions, employees: employees, filePath: filePath).ToResponse();
        }

        /// <summary>
        /// 设置历史
        /// </summary>
        /// <param name="fileid"></param>
        /// <param name="version"></param>
        /// <returns></returns>
        public IResponseMessage setHistoryData(int fileid, int version)
        {
            ///获取该文件的所有版本
            List<FilesVersion> versions = service.GetVersionsByFileId(fileid: fileid);
            ///获取文件
            Files file = filesDomainService.Get<Files>(id: fileid);
            List<DocumentServer.Core.Model.DbModel.Employee> employees = employeeDomainService.All<DocumentServer.Core.Model.DbModel.Employee>();
            return extBizFileVersion.setHistoryData(file: file, versions: versions, employees: employees, filePath: filePath, version: version).ToResponse();
        }
    }
}


