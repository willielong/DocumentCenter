using DocmentServer.Core.DomainService.FilesInfo;
using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.OnlyOfficeConfigModel;
using DocumentServer.Core.Model.Oupt;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;

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
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create(filePath.ApiUrl+files.fileuri);
                request.Method = "GET";
                using (WebResponse webRes = request.GetResponse())
                {
                    model = new DownloadModel();
                    int length = (int)webRes.ContentLength;
                    HttpWebResponse response = webRes as HttpWebResponse;
                    Stream stream = response.GetResponseStream();
                    model.fileName = files.cnname + "." + files.ext;
                    model.ContentType = "application/octet-stream";
                    //读取到内存
                    MemoryStream stmMemory = new MemoryStream();
                    byte[] buffer = new byte[length];
                    int i;
                    //将字节逐个放入到Byte中
                    while ((i = stream.Read(buffer, 0, buffer.Length)) > 0)
                    {
                        stmMemory.Write(buffer, 0, i);
                    }
                    stmMemory.Close();
                    model.Buff = buffer;
                }
            }
            return model;
        }
    }
}
