using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.OnlyOfficeConfigModel
{
    public class ApiVersionsConfig
    {
        public List<ApiVersion> ApiVersions { get; set; }
        public FilePath FilePath { get; set; }
    }
    public class ApiVersion
    {
        public string url { get; set; }
        public string name { get; set; }
    }
    public class FilePath { 
        /// <summary>
        /// 物理路径
        /// </summary>
        public string PhysicalFilePath { get; set; }
        /// <summary>
        /// api文件地址
        /// </summary>
        public string ApiFilePath { get; set; }
    }
}
