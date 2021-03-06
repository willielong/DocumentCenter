﻿using DocumetCenter.Core.Enum;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
/*
* 目的添加onlyOffice文件配置
* 
*/
namespace DocumentServer.Core.Comm
{
    public static class FileUtility
    {
        /// <summary>
        /// 获取OnlyOffice文档类型
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public static FileType GetFileType(string ext)
        {
            if (ExtsDocument.Contains(ext)) return FileType.Text;
            if (ExtsSpreadsheet.Contains(ext)) return FileType.Spreadsheet;
            if (ExtsPresentation.Contains(ext)) return FileType.Presentation;

            return FileType.Text;
        }
        /// <summary>
        /// word 相关
        /// </summary>
        public static readonly List<string> ExtsDocument = new List<string>
            {
                ".doc", ".docx", ".docm",
                ".dot", ".dotx", ".dotm",
                ".odt", ".fodt", ".ott", ".rtf", ".txt",
                ".html", ".htm", ".mht",
                ".pdf", ".djvu", ".fb2", ".epub", ".xps"
            };
        /// <summary>
        /// Excel 相关
        /// </summary>
        public static readonly List<string> ExtsSpreadsheet = new List<string>
            {
                ".xls", ".xlsx", ".xlsm",
                ".xlt", ".xltx", ".xltm",
                ".ods", ".fods", ".ots", ".csv"
            };

        /// <summary>
        /// PPT相关
        /// </summary>
        public static readonly List<string> ExtsPresentation = new List<string>
            {
                ".pps", ".ppsx", ".ppsm",
                ".ppt", ".pptx", ".pptm",
                ".pot", ".potx", ".potm",
                ".odp", ".fodp", ".otp"
            };

        /// <summary>
        /// 文件后缀名
        /// </summary>
        public static List<string> FileExts
        {
            get { return ViewedExts.Concat(EditedExts).Concat(ConvertExts).ToList(); }
        }
        /// <summary>
        /// 查看文件时文件后缀名
        /// </summary>
        public static List<string> ViewedExts
        {
            get
            {
                OnlyOfficeConfig config = OnlyOfficeConfig.GetOnlyOfficeConfig();
                config.viewed = config.viewed ?? "";
                return config.viewed.Split(new char[] { '|', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }
        /// <summary>
        /// 编辑文件时文件后缀名
        /// </summary>
        public static List<string> EditedExts
        {
            get
            {
                OnlyOfficeConfig config = OnlyOfficeConfig.GetOnlyOfficeConfig();
                config.edited = config.edited ?? "";
                return config.edited.Split(new char[] { '|', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }
        /// <summary>
        /// 转换文件时文件后缀名
        /// </summary>
        public static List<string> ConvertExts
        {
            get
            {
                OnlyOfficeConfig config = OnlyOfficeConfig.GetOnlyOfficeConfig();
                config.convert = config.convert ?? "";
                return config.convert.Split(new char[] { '|', ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            }
        }
        /// <summary>
        /// Translation key to a supported form.
        /// </summary>
        /// <param name="expectedKey">Expected key</param>
        /// <returns>Supported key</returns>
        public static string GenerateRevisionId(this string expectedKey)
        {
            expectedKey = string.Concat(expectedKey, DateTime.Now.ToString());
            if (expectedKey.Length > 20) expectedKey = expectedKey.GetHashCode().ToString();
            var key = Regex.Replace(expectedKey, "[^0-9-.a-zA-Z_=]", "_");
            return key.Substring(key.Length - Math.Min(key.Length, 20));
        }
    }
    
}
