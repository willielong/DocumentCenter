using DocumetCenter.Core.Enum;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.OnlyOfficeConfigModel
{
    public class ConfigModel
    {
        /// <summary>
        /// 文件
        /// </summary>
        public DbModel.Files files { get; set; }
        /// <summary>
        /// 文件版本
        /// </summary>
        public DbModel.FilesVersion version { get; set; }
        /// <summary>
        /// 配置类型
        /// </summary>
        public FilePath filePath { get; set; }

        /// <summary>
        ///编辑模式
        /// </summary>
        public EditType editType { get; set; }
        /// <summary>
        /// 系统模式
        /// </summary>
        public SystemType systemType { get; set; }
        public HttpContext httpContext { get;set; }
        public DocumentServer.Core.Model.DbModel.Employee employee { get; set; }
    }
}
