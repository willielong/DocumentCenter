using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.OnlyOfficeConfigModel
{
    public class ApiVersionsConfig
    {
        public List<ApiVersion> ApiVersions { get; set; }
    }
    public class ApiVersion
    {
        public string url { get; set; }
        public string name { get; set; }
    }
}
