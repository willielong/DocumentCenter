using System;
using System.Collections.Generic;
using System.Text;

namespace DocumetCenter.Core.Enum
{
    class Enum
    {
    }
    /// <summary>
    /// 文件夹归属于哪一类----单位/组织/个人
    /// </summary>
    public enum FolderType
    {
        /// <summary>
        /// 单位
        /// </summary>
        Unit = 0,
        /// <summary>
        /// 组织
        /// </summary>
        Organization = 1,
        /// <summary>
        /// 个人
        /// </summary>
        Personal = 2,
    }
    /// <summary>
    /// OnlyOffice 识别文档的类型
    /// </summary>
    public enum FileType
    {
        /// <summary>
        /// 文本文档类
        /// </summary>
        Text,
        /// <summary>
        /// 表格类
        /// </summary>
        Spreadsheet,
        /// <summary>
        /// 幻灯片类
        /// </summary>
        Presentation
    }

    public enum LanguageType { 
        /// <summary>
        /// 英文
        /// </summary>
        en=0,
        /// <summary>
        /// 中文
        /// </summary>
        zh=2
    }
}
