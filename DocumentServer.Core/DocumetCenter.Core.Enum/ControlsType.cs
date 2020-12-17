using System;
using System.Collections.Generic;
using System.Text;

/*
 * 描述：控件字段类型枚举 
 */
namespace DocumetCenter.Core.Enum
{
    /// <summary>
    /// 字段类型
    /// </summary>
    public static class ControlsType
    {
       
        /// <summary>
        /// 转换成中文显示名
        /// </summary>
        /// <param name="controlType"></param>
        /// <returns></returns>
        public static string ConvertToStringControlTypeRes(this ControlType controlType)
        {
            return ((ControlTypeRes)((int)controlType)).ToString();
        }
        /// <summary>
        /// 转换成中文枚举
        /// </summary>
        /// <param name="controlType"></param>
        /// <returns></returns>
        public static ControlTypeRes ConvertToControlTypeRes(this ControlType controlType)
        {
            return (ControlTypeRes)((int)controlType);
        }
    }
    /// <summary>
    /// 控件类型
    /// </summary>
    public enum ControlType
    {
        /// <summary>
        /// 单行文本
        /// </summary>
        text,
        /// <summary>
        /// 多行文本
        /// </summary>
        multilinetext,
        /// <summary>
        /// 日期时间
        /// </summary>
        datetime,
        /// <summary>
        /// 日期
        /// </summary>
        date,
        /// <summary>
        /// 年
        /// </summary>
        year,
        /// <summary>
        /// 月
        /// </summary>
        month,
        /// <summary>
        /// 日
        /// </summary>
        day,
        /// <summary>
        /// 时间
        /// </summary>
        time,
        /// <summary>
        /// LookUp
        /// </summary>
        lookup,
        /// <summary>
        /// 树形参数
        /// </summary>
        tree,
        /// <summary>
        /// 下拉参数
        /// </summary>
        parmters,

    }
    public enum ControlTypeRes
    {
        /// <summary>
        /// 单行文本
        /// </summary>
        单行文本,
        /// <summary>
        /// 多行文本
        /// </summary>
        多行文本,
        /// <summary>
        /// 日期时间
        /// </summary>
        日期时间,
        /// <summary>
        /// 年
        /// </summary>
        年,
        /// <summary>
        /// 月
        /// </summary>
        月,
        /// <summary>
        /// 日
        /// </summary>
        日,
        /// <summary>
        /// 时间
        /// </summary>
        时间,
        /// <summary>
        /// LookUp
        /// </summary>
        LookUp,
        /// <summary>
        /// 树形参数
        /// </summary>
        树形参数,
        /// <summary>
        /// 下拉参数
        /// </summary>
        下拉参数,
        /// <summary>
        /// 日期
        /// </summary>
        日期
    }
}
