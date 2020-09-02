using DocmentServer.Core.Business.Base;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
/**
 * 描述：文件夹信息操作类-接口 
 * */
namespace DocmentServer.Core.Business.Folder
{
    public interface IFileFloderBusiness : IBaseBusiness
    {
        /// <summary>
        /// 添加文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        long Add(FileFloder model, IDbTransaction transaction = null);
        /// <summary>
        /// 修改文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        bool Update(FileFloder model, IDbTransaction transaction = null);

        /// <summary>
        /// 删除文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        bool Delete(object id, IDbTransaction transaction = null);

        /// <summary>
        /// 获取文件夹信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        FileFloder Get(object id, IDbTransaction transaction = null);

        /// <summary>
        /// 获取文件夹信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        List<FileFloder> List(object id, IDbTransaction transaction = null);
        /// <summary>
        /// 获取文件夹信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">文件夹实体</param>
        /// <returns></returns>
        List<FileFloder> GetListOrgID(int orgId, IDbTransaction transaction = null);

        /// <summary>
        /// 获取所有文件夹数据
        /// </summary>
        /// <param name="transaction"></param>
        /// <returns></returns>
        List<FileFloder> All(IDbTransaction transaction = null);
    }
}
