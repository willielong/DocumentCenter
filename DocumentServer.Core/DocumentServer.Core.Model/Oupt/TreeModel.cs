﻿namespace DocumentServer.Core.Model.Oupt
{
    public class TreeModel
    {
        /// <summary>
        /// 树形结构名称
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// 类型
        /// </summary>
        public int type { get; set; }

        /// <summary>
        /// ID
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// 父级ID
        /// </summary>
        public int pid { get; set; }

        /// <summary>
        /// 图标
        /// </summary>
        public string icon { get; set; }

        /// <summary>
        /// 主题
        /// </summary>
        public string item { get; set; }
        /// <summary>
        /// 单位ID
        /// </summary>
        public int unitid { get; set; }
        public double seq { get; set; }
    }
}
