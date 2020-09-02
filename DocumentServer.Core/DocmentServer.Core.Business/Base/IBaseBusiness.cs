using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.Business.Base
{
    public interface IBaseBusiness
    {
        DocumentServer.Core.Model.DbModel.Employee CurrentUser { get; set; }
        /// <summary>
        /// 设置当前账号
        /// </summary>
        /// <param name="employee"></param>
        void SettingCurrentEmp(DocumentServer.Core.Model.DbModel.Employee employee);

        /// <summary>
        /// 添加信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        long Add<T>(T model, IDbTransaction transaction = null) where T : class, new();
        /// <summary>
        /// 修改单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        bool Update<T>(T model, IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 删除单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        bool Delete<T>(T model, IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 获取单位信息
        /// </summary>
        /// </summary>
        /// <param name="model">单位实体</param>
        /// <returns></returns>
        T Get<T>(object id, IDbTransaction transaction = null) where T : class, new();

        /// <summary>
        /// 获取所有单位数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        List<T> All<T>(IDbTransaction transaction = null) where T : class, new();
    }
}
