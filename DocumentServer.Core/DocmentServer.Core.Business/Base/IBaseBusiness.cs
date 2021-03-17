﻿using DocumentServer.Core.Infrastrure;
using System.Collections.Generic;
using System.Data;

namespace DocmentServer.Core.Business.Base
{
    public interface IBaseBusiness
    {
        IConnectionBase connectionBase { get; set; }
        /// <summary>
        /// 当前用户
        /// </summary>
        DocumentServer.Core.Model.DbModel.Employee CurrentUser { get; }
        /// <summary>
        /// 设置当前账号
        /// </summary>
        /// <param name="employee"></param>
        void SettingCurrentEmp(DocumentServer.Core.Model.DbModel.Employee employee);

        /// <summary>
        /// 添加信息
        /// </summary>
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        long Add<T>(T model, IDbTransaction transaction = null) where T : class, new();
        /// <summary>
        /// 修改信息
        /// </summary>
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        bool Update<T>(T model, IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 删除信息
        /// </summary>
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        bool Delete<T>(T model, IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 获取信息
        /// </summary>
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        T Get<T>(object id, IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        List<T> All<T>(IDbTransaction transaction = null) where T : class, new();
    }
}
