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
    /// 组织类型
    /// </summary>
    public enum OrgationalType
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
        Presentation,
        /// <summary>
        /// 文件夹
        /// </summary>
        Folder,

    }
    public enum TextType
    {
        /// <summary>
        /// 文本文档类
        /// </summary>
        Word,
        /// <summary>
        /// 表格类
        /// </summary>
        Excel,
        /// <summary>
        /// 幻灯片类
        /// </summary>
        PPT,
        /// <summary>
        /// 文件夹
        /// </summary>
        文件夹,

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
    public enum TrackerStatus
    {
        NotFound = 0,
        Editing = 1,
        MustSave = 2,
        Corrupted = 3,
        Closed = 4,
    }

    public enum SystemType
    {
        /// <summary>
        /// 桌面系统
        /// </summary>
        desktop,
        /// <summary>
        /// 移动端系统
        /// </summary>
        mobile,
        embedded,
    }
    public enum EditType
    {
        /// <summary>
        /// 编辑模式
        /// </summary>
        edit=0,
        /// <summary>
        /// 预览模式
        /// </summary>
        review=1,
        view=2,
        /// <summary>
        /// 全屏模式
        /// </summary>
        fillForms=3,
        /// <summary>
        /// 消息模式
        /// </summary>
        comment=4,
        /// <summary>
        /// 锁定内容模式
        /// </summary>
        blockcontent=5,
        /// <summary>
        /// 无边框预览模式
        /// </summary>
        embedded=6,
        /// <summary>
        /// 条件模式
        /// </summary>
        filter=7
    }
}
