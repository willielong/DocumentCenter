using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.OnlyOfficeConfigModel;
using ServiceStack.Text;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
namespace DocmentServer.Core.BizService.FileVersion
{
    public class ExtBizFileVersionService
    {
        /// <summary>
        /// 获取所有历史信息
        /// </summary>
        /// <param name="fileid"></param>
        /// <returns></returns>
        public HistoryHitConfig refreshHistory(Files file, List<FilesVersion> versions, List<DocumentServer.Core.Model.DbModel.Employee> employees, FilePath filePath)
        {
            HistoryHitConfig config = new HistoryHitConfig();
            config.currentVersion = int.Parse(file.currentVersion);
            config.history = new List<HistoryHit>();
            foreach (var item in versions)
            {
                HistoryHit history = new HistoryHit();
                history.key = item.version == int.Parse(file.currentVersion) ? file.fileuri.GetHashCode().ToString().GenerateRevisionId() : item.filekey;
                history.version = item.version;
                history.changes = JsonSerializer.DeserializeFromString<List<ChangesConfig>>(item.changes);
                history.serverVersion = item.serverVersion;
                history.created = history.changes.First().created;
                history.user = history.changes.First().user;
                if (item.version == 0) history.changes = new List<ChangesConfig>();
                config.history.Add(history);
            }
            return config;
        }
        /// <summary>
        /// 获取所有历史信息
        /// </summary>
        /// <param name="fileid"></param>
        /// <returns></returns>
        public HistoryCurrentVersion setHistoryData(Files file, List<FilesVersion> versions, List<DocumentServer.Core.Model.DbModel.Employee> employees, FilePath filePath, int version)
        {
            HistoryCurrentVersion config = new HistoryCurrentVersion();
            FilesVersion currentVersion = versions.FirstOrDefault(v => v.version == version);
            FilesVersion nextVersion = versions.FirstOrDefault(v => v.version == (version + 1));
            FilesVersion preVersion = versions.FirstOrDefault(v => v.version == (version - 1));
            if (currentVersion != null)
            {
                config.key = currentVersion.filekey;
                config.url = currentVersion.version == int.Parse(file.currentVersion) ? string.Concat(filePath.ApiUrl, file.fileuri) : string.Concat(filePath.ApiUrl, nextVersion.prevuri);
                config.version = currentVersion.version;
                if (currentVersion.version > 0)
                {
                    config.changesUrl = string.IsNullOrWhiteSpace(currentVersion.changesUrl) ? "" : string.Concat(filePath.ApiUrl, currentVersion.changesUrl);
                    config.previous = new PreviousInfo() { url = "", key = "" };
                    if (preVersion != null)
                    {
                        config.previous.key = preVersion.filekey;
                        config.previous.url = string.Concat(filePath.ApiUrl, preVersion.prevuri);
                    }
                }
            }
            return config;
        }
    }
}
