﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.DomainService.Physicalhistory
{
    public interface IPhysicalhistoryDomainService : Base.IBaseDomainService
    {
        bool Edit(IDbTransaction transaction = null);
        /// <summary>
        /// 获取开启的网站路径
        /// </summary>
        /// <returns></returns>
        DocumentServer.Core.Model.DbModel.Physicalhistory SingleByEnable(IDbTransaction transaction = null);
    }
}
