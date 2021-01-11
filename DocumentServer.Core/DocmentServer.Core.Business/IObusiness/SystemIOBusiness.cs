using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.OnlyOfficeConfigModel;
using Microsoft.Extensions.Configuration;
using ServiceStack.Text;
using System;
using System.IO;
using System.Net;

namespace DocmentServer.Core.Business.IObusiness
{
    public class SystemIOBusiness : ISystemIOBusiness
    {
        private IConfiguration Configuration;
        private FilePath filePath;

        public SystemIOBusiness(IConfiguration configuration)
        {
            ///获取配置文件
            Configuration = configuration;
            ///获取配置文件中的数据
            filePath = Configuration.Get<ApiVersionsConfig>().FilePath;
        }
        /// <summary>
        /// 判断最大的文件数
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsFileMaxFolder(DocumentServer.Core.Model.DbModel.Physicalhistory model)
        {
            bool isMax = true;
            if (null != model)
            {
                ///组装本地文件
                string physicalFolder = Path.Combine(filePath.PhysicalFilePath, model.physicalfolder);
                if (!Directory.Exists(physicalFolder))
                {
                    Directory.CreateDirectory(physicalFolder);
                }
                /// 获取文件目录下的文件夹个数
                int folderSum = Directory.GetDirectories(physicalFolder).Length;
                ///当文件数大于最大数量时新建文件夹
                if (folderSum <= filePath.MaxFile)
                {
                    isMax = false;
                }
            }
            return isMax;
        }

        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public Files MakeFile(Files files, DocumentServer.Core.Model.DbModel.Physicalhistory physicalhistory)
        {
            string templateName = Path.Combine(filePath.PhysicalFilePath, "AppData", string.Format("new.{0}", files.ext));
            string physicalhistoryPath = Path.Combine(filePath.PhysicalFilePath, physicalhistory.physicalfolder);
            files.folderpath = string.Concat("\\", physicalhistory.physicalfolder);
            ///创建文件夹
            if (!Directory.Exists(physicalhistoryPath))
            {
                Directory.CreateDirectory(physicalhistoryPath);
            }
            #region 文件目录
            string path = Guid.NewGuid().ToString().Replace("-", "").Trim();
            physicalhistoryPath = Path.Combine(physicalhistoryPath, path);
            files.folderpath = Path.Combine(files.folderpath, path);
            files.fileuri = string.Format("{0}/{1}/{2}/", filePath.ApiFilePath, physicalhistory.physicalfolder, path);
            if (!Directory.Exists(physicalhistoryPath))
            {
                Directory.CreateDirectory(physicalhistoryPath);
            }
            #endregion
            string newFileName = string.Format("{0}.{1}", Guid.NewGuid().ToString().Replace("-", "").Trim(), files.ext);
            files.fileuri = string.Format("{0}/{1}", files.fileuri, newFileName);
            files.path = string.Format("{0}/{1}", files.path, newFileName);
            string newPath = Path.Combine(physicalhistoryPath, newFileName);
            files.filepath = newPath;
            File.Copy(templateName, newPath);
            FileInfo info = new FileInfo(newPath);
            files.size = info.Length;
            return files;
        }
        /// <summary>
        /// 进行回调数据保存
        /// </summary>
        /// <param name="files"></param>
        /// <param name="fileData"></param>
        /// <returns></returns>
        public FilesVersion TrackFile(Files files, OutOfficeConfigModel fileData)
        {
            FilesVersion filesVersion = new FilesVersion();
            ///组装历史文件地址
            string histfolder = filePath.PhysicalFilePath + Path.Combine(files.folderpath, "hist");
            filesVersion.prevuri = string.Format("{0}/{1}/{2}/", filePath.ApiFilePath, files.folderpath.Replace(@"\", "/"), "hist");
            ///组装版本信息地址
            filesVersion.changesUrl = string.Format("{0}/{1}/{2}/", filePath.ApiFilePath, files.folderpath.Replace(@"\", "/"), "hist");
            ////创建历史记录文件夹
            if (!Directory.Exists(histfolder)) Directory.CreateDirectory(histfolder);
            //生成历史文件名
            string newFileName = string.Format("{0}.{1}", Guid.NewGuid().ToString().Replace("-", "").Trim(), files.ext);
            ///拷贝文件到数据
            File.Copy(files.filepath, Path.Combine(histfolder, newFileName));
            filesVersion.prevuri = string.Format("{0}/{1}", filesVersion.prevuri, newFileName);

            string diffFileName = string.Format("{0}.{1}", Guid.NewGuid().ToString().Replace("-", "").Trim(), "zip");

            filesVersion.changesUrl = string.Format("{0}/{1}", filesVersion.changesUrl, diffFileName);
            ///保存文件数据
            SavePhysicalhistoryFile(url: fileData.url, path: files.filepath);
            ///下载历史数据
            SavePhysicalhistoryFile(url: fileData.changesurl, path: Path.Combine(histfolder, diffFileName));
            ///组装数据
            filesVersion.fileid = files.autoid;
            filesVersion.serverVersion = filePath.ServerVersion;
            filesVersion.creatdate = DateTime.Now;
            filesVersion.modifdate = DateTime.Now;
            filesVersion.filekey =  fileData.key;//装key
            filesVersion.version = int.Parse(files.currentVersion.ToString());
            var hist = fileData.changeshistory;
            if (string.IsNullOrEmpty(hist) && fileData.history != null)
            {                
                hist = JsonSerializer.SerializeToString(fileData.history.changes);
            }
            if (!string.IsNullOrEmpty(hist))
            {
                filesVersion.changes = hist;
            }
            return filesVersion;
        }
        /// <summary>
        /// 下服务器文件到本地
        /// </summary>
        /// <param name="url"></param>
        /// <param name="path"></param>
        private void SavePhysicalhistoryFile(string url, string path)
        {
            if (string.IsNullOrEmpty(url)) throw new ArgumentException("url");
            if (string.IsNullOrEmpty(path)) throw new ArgumentException("path");

            var req = (HttpWebRequest)WebRequest.Create(url);
            using (var stream = req.GetResponse().GetResponseStream())
            {
                if (stream == null) throw new Exception("stream is null");
                const int bufferSize = 4096;

                using (var fs = File.Open(path, FileMode.Create))
                {
                    var buffer = new byte[bufferSize];
                    int readed;
                    while ((readed = stream.Read(buffer, 0, bufferSize)) != 0)
                    {
                        fs.Write(buffer, 0, readed);
                    }
                }
            }
        }
    }
}
