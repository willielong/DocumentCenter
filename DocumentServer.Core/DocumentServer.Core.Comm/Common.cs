using DocumetCenter.Core.Enum;
using System;

namespace DocumentServer.Core.Comm
{
    public static class Common
    {
        /// <summary>
        /// 转换单位
        /// </summary>
        /// <param name="orgType"></param>
        /// <returns></returns>
        public static string ConvertToOrgTypeString(this int orgType)
        {
            FolderType type = (FolderType)orgType;
            switch (type)
            {
                case FolderType.Unit: return "单位";
                case FolderType.Organization: return "部门";
                case FolderType.Personal: return "个人";
                default: return "";
            }
        }
        /// <summary>
        /// 转换文件类型
        /// </summary>
        /// <param name="orgType"></param>
        /// <returns></returns>
        public static string ConvertToExtString(this TextType textType)
        {
            switch (textType)
            {
                case TextType.Word: return TextType.Word.ToString();
                case TextType.Excel: return TextType.Excel.ToString();
                case TextType.PPT: return TextType.PPT.ToString();
                case TextType.文件夹: return TextType.文件夹.ToString();
                default: return "";
            }
        }
        /// <summary>
        /// 转换文件类型
        /// </summary>
        /// <param name="orgType"></param>
        /// <returns></returns>
        public static string ConvertToExt(this string textType)
        {
            if (textType.Contains("doc"))
                return TextType.Word.ToString();
            else if (textType.Contains("xls"))
                return TextType.Excel.ToString();
            else if (textType.Contains("ppt"))
                return TextType.PPT.ToString();
            else return TextType.文件夹.ToString();
        }
        /// <summary>
        /// 转换文件类型-int
        /// </summary>
        /// <param name="orgType"></param>
        /// <returns></returns>
        public static int ConvertToExtInt(this string textType)
        {
            if (textType.Contains("doc"))
                return (int)TextType.Word;
            else if (textType.Contains("xls"))
                return (int)TextType.Excel;
            else if (textType.Contains("ppt"))
                return (int)TextType.PPT;
            else return (int)TextType.文件夹;
        }
        public static string CovertToGb(this double  b)
        {
            const int GB = 1024 * 1024 * 1024;
            const int MB = 1024 * 1024;
            const int KB = 1024;

            if (b / GB >= 1)
            {
                return Math.Round(b / (float)GB, 2) + "GB";
            }
            if (b / MB >= 1)
            {
                return Math.Round(b / (float)MB, 2) + "MB";
            }
            if (b / KB >= 1)
            {
                return Math.Round(b / (float)KB, 2) + "KB";
            }
            return b + "B";
        }
        /// <summary>
        /// 转换单位
        /// </summary>
        /// <param name="orgType"></param>
        /// <returns></returns>
        public static string ConvertToDicOrgTypeString(this OrgationalType orgType)
        {
            switch (orgType)
            {
                case OrgationalType.Unit: return "单位";
                case OrgationalType.Organization: return "部门";
                case OrgationalType.Personal: return "个人";
                default: return "";
            }
        }
    }
}
