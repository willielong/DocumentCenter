using System.Collections.Generic;

namespace DocumentServer.Core.Model.OnlyOfficeConfigModel
{
    public class HistoryHitConfig
    {
        /// <summary>
        /// 当前版本
        /// </summary>
        public int currentVersion { get; set; }
        /// <summary>
        /// 版本
        /// </summary>
        public List<HistoryHit> history { get; set; }
    }
    public class HistoryConfig
    {
        /// <summary>
        /// 历史记录
        /// </summary>
        public HistoryHitConfig hit { get; set; }
        /// <summary>
        /// 当前版本信息
        /// </summary>
        public HistoryCurrentVersion curVersion { get; set; }
    }
    /// <summary>
    /// 当前版本呢信息
    /// </summary>
    public class HistoryCurrentVersion
    {
        /// <summary>
        /// 历史包的路径
        /// </summary>
        public string changesUrl { get; set; }
        /// <summary>
        ///文件的标识值
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string url { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public int version { get; set; }
        /// <summary>
        /// 历史版本信息
        /// </summary>
        public PreviousInfo previous { get; set; }
    }
    /// <summary>
    /// 历史版本信息
    /// </summary>
    public class PreviousInfo
    {
        /// <summary>
        ///文件的标识值
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 文件路径
        /// </summary>
        public string url { get; set; }
    }
    public class HistoryHit
    {
        /// <summary>
        /// 创建日期
        /// </summary>
        public string created { get; set; }
        /// <summary>
        ///文件的标识值
        /// </summary>
        public string key { get; set; }
        /// <summary>
        /// 工具版本
        /// </summary>
        public string serverVersion { get; set; }
        /// <summary>
        /// 文档版本
        /// </summary>
        public int version { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public User user { get; set; }
        public List<ChangesConfig> changes { get; set; }
    }

    public class ChangesConfig
    {
        /// <summary>
        /// 创建日期
        /// </summary>
        public string created { get; set; }
        /// <summary>
        /// 用户信息
        /// </summary>
        public User user { get; set; }
    }

    public class ChangesModel {
        /// <summary>
        /// 工具版本
        /// </summary>
        public string serverVersion { get; set; }
        public List<ChangesConfig> changes { get; set; }
    }

}
