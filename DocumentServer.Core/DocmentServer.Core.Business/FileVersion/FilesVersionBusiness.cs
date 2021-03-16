﻿using Dapper;
using DocumentServer.Core.Infrastrure;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;

namespace DocmentServer.Core.Business.FileVersion
{
    public class FilesVersionBusiness : Base.BaseBusiness, IFilesVersionBusiness
    {
        public FilesVersionBusiness(IConnectionBase _dbConnection) : base(dbConnection: _dbConnection)
        {
        }
        /// <summary>
        /// 删除版本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">版本信息实体</param>
        /// <returns></returns>
        public bool Delete(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Execute(sql: "DELETE FROM  FilesVersion WHERE autoid=@autoid", param: new FilesVersion() { autoid = (int)id }, transaction: transaction) >= 0;
        }
        /// <summary>
        /// 获取版本信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">版本信息实体</param>
        /// <returns></returns>
        public List<FilesVersion> GetVersionsByFileId(int fileid, IDbTransaction transaction = null)
        {
            return dbConnection.Query<FilesVersion>(sql: "SELECT *  FROM  FilesVersion WHERE fileid=@fileid", param: new FilesVersion() { fileid = fileid }, transaction: transaction).AsList();
            throw new NotImplementedException();
        }

        /// <summary>
        /// 获取版本信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">版本信息实体</param>
        /// <returns></returns>
        public List<FilesVersion> List(object id, IDbTransaction transaction = null)
        {
            return dbConnection.Query<FilesVersion>(sql: "SELECT *  FROM  FilesVersion WHERE autoid=@autoid", param: new FilesVersion() { autoid = (int)id }, transaction: transaction).AsList();
        }
    }
}
