using DocmentServer.Core.DomainService.FilesInfo;
using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.OnlyOfficeConfigModel;
using DocumentServer.Core.Model.Oupt;
using Microsoft.AspNetCore.StaticFiles;
using Microsoft.Extensions.Configuration;

namespace DocmentServer.Core.BizService.FilesInfo
{
    public class DownloadBizservice :   IDownloadBizservice
    {
        private IFilesDomainService service { get; set; }
        public FilePath filePath;
        public DownloadBizservice(IFilesDomainService _service, IConfiguration configuration) 
        {
            ///获取配置文件中的数据
            filePath = configuration.Get<ApiVersionsConfig>().FilePath;
            service = _service;
        }

        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="fileid"></param>
        /// <returns></returns>
        public DownloadModel DownloadFile(int fileid)
        {
            DownloadModel model   =null;
            Files files = service.Get<Files>(fileid);
            if (files != null)
            {
                model = new DownloadModel();
                model.Buff = System.IO.File.OpenRead(files.filepath);
                model.fileName = files.cnname + "." + files.ext;
                model.ContentType = new FileExtensionContentTypeProvider().Mappings["."+files.ext];
            }
            return model;
        }
    }
}
