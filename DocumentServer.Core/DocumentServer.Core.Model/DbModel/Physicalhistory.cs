using System;
using System.Collections.Generic;
using System.Text;
using Dapper;
using Dapper.Contrib.Extensions;

namespace DocumentServer.Core.Model.DbModel
{
    public class Physicalhistory:EntityBase
    {
        /// <summary>
        /// 主键ID
        /// </summary>
        public int autoid { get; set; }

        /// <summary>
        /// 历史物理路径
        /// </summary>
        public string physicalfolder { get; set; }
        /// <summary>
        /// 启用？
        /// </summary>
        public bool enable { get; set; }
    }
}
