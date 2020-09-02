using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using DocumentServer.Core.Model.DbModel;
using Dapper;
using Dapper.Contrib.Extensions;

namespace DocmentServer.Core.Business.Base
{
    public class BaseBusiness : IBaseBusiness
    {
        /// <summary>
        /// 当前用户
        /// </summary>
        public DocumentServer.Core.Model.DbModel.Employee CurrentUser { get; set; }
        /// <summary>
        /// 数据库链接
        /// </summary>
        public IDbConnection dbConnection;

        public BaseBusiness(IDbConnection dbConnection)
        {
            this.dbConnection = dbConnection;
        }

        /// <summary>
        /// 设置当前用户信息
        /// </summary>
        /// <param name="employee"></param>
        public void SettingCurrentEmp(DocumentServer.Core.Model.DbModel.Employee CurrentUser)
        {
            this.CurrentUser = CurrentUser;
        }

        /// <summary>
        /// 添加信息
        /// </summary>
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public long Add<T>(T model, IDbTransaction transaction = null) where T : class, new()
        {
            return dbConnection.Insert<T>(entityToInsert: model, transaction: transaction);
        }
        /// <summary>
        /// 修改信息
        /// </summary>
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool Update<T>(T model, IDbTransaction transaction = null) where T : class, new()
        {
            return dbConnection.Update<T>(entityToUpdate: model, transaction: transaction);
        }

        /// <summary>
        /// 删除信息
        /// </summary>
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public bool Delete<T>(T model, IDbTransaction transaction = null) where T : class, new()
        {
            return dbConnection.Delete<T>(entityToDelete: model, transaction: transaction);
        }

        /// <summary>
        /// 获取信息
        /// </summary>
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns></returns>
        public T Get<T>(object id, IDbTransaction transaction = null) where T : class, new()
        {
            return dbConnection.Get<T>(id: id, transaction: transaction);
        }

        /// <summary>
        /// 获取所有数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        public List<T> All<T>(IDbTransaction transaction = null) where T : class, new()
        {
            return dbConnection.GetAll<T>(transaction: transaction).AsList();
        }
    }
}
