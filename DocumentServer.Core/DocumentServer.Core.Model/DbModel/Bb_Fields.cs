using Dapper.Contrib.Extensions;
using DocumetCenter.Core.Enum;

namespace DocumentServer.Core.Model.DbModel
{
    [Table("Bb_Fields")]
    public class Bb_Fields:EntityBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        [Key]
        public virtual int autoid { get; set; }
        /// <summary>
        /// 字段编码
        /// </summary>
        public virtual string fieldcode { get; set; }

        /// <summary>
        /// 字段名称
        /// </summary>
        public virtual string fieldname { get; set; }

        /// <summary>
        /// 字段名-英文
        /// </summary>
        public virtual string fieldenname { get; set; }


        /// <summary>
        /// 表编码
        /// </summary>
        public virtual string tablecode { get; set; }

        /// <summary>
        ///参数控件类型值来源
        /// </summary>
        public virtual string controlsouces { get; set; }

        /// <summary>
        /// 字段类型
        /// </summary>
        public virtual int fieldtype { get; set; }

        /// <summary>
        /// 控件类型
        /// </summary>
        public virtual ControlType controlstype { get; set; }

        /// <summary>
        /// 默认值
        /// </summary>
        public virtual string defaultvalue { get; set; }

        /// <summary>
        /// 字段长度
        /// </summary>
        public virtual int fieldlength { get; set; }

        /// <summary>
        /// 必填？
        /// </summary>
        public virtual bool isrequired { get; set; }

        /// <summary>
        /// 内置？
        /// </summary>
        public virtual bool isinlay { get; set; }

        /// <summary>
        /// 启用？
        /// </summary>
        public virtual bool enable { get; set; }

        /// <summary>
        /// 删除？
        /// </summary>
        public virtual bool isdel { get; set; }

        /// <summary>
        /// 顺序
        /// </summary>
        public virtual double sequence { get; set; }
    }
}
