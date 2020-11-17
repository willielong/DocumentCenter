using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocumentServer.Core.Model.Oupt
{
    public class Bb_TableInfo_OutPut : Bb_TableInfo
    {
        /// <summary>
        /// 显示是否喂系统表
        /// </summary>
        public virtual string dic_is_system { get; set; }

        /// <summary>
        /// 显示禁用/启用
        /// </summary>
        public virtual string dic_enable { get; set; }

        /// <summary>
        /// 创建人显示名
        /// </summary>
        public string dic_creator { get; set; }

        /// <summary>
        /// 修改人显示名
        /// </summary>
        public string dic_modifier { get; set; }
        /// <summary>
        /// 创建日期格式化
        /// </summary>
        public string dic_creatdate { get; set; }

        /// <summary>
        /// 修改日期格式
        /// </summary>
        public string dic_modifierdate { get; set; }


    }
}
