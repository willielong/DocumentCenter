using System.Collections.Generic;

namespace DocumentServer.Core.Model.OnlyOfficeConfigModel
{
    public class ApiVersionsConfig
    {
        public List<ApiVersion> ApiVersions { get; set; }
        public FilePath FilePath { get; set; }
    }
    public class ApiVersion
    {
        public string version { get; set; }
    }
    public class FilePath
    {
        /// <summary>
        /// 物理路径
        /// </summary>
        public string PhysicalFilePath { get; set; }
        /// <summary>
        /// api文件地址
        /// </summary>
        public string ApiFilePath { get; set; }

        /// <summary>
        /// 文件的最大值
        /// </summary>
        public int MaxFile { get; set; }
        /// <summary>
        /// OnlyOffice版本
        /// </summary>
        public string ServerVersion { get; set; }
        /// <summary>
        /// 接口地址
        /// </summary>
        public string ApiUrl { get; set; }
        /// <summary>
        /// 网站地址
        /// </summary>
        public string WebUrl { get; set; }
    }
}
