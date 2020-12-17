using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocmentServer.Core.BizService.FileVersion
{
    public interface IBizFileVersionService
    {
        /// <summary>
        /// 添加文件版本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件版本信息实体</param>
        /// <returns></returns>
        IResponseMessage Add(FilesVersion model);
        /// <summary>
        /// 修改文件版本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件版本信息实体</param>
        /// <returns></returns>
        IResponseMessage Update(FilesVersion model);

        /// <summary>
        /// 删除文件版本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件版本信息实体</param>
        /// <returns></returns>
        IResponseMessage Delete(object id);

        /// <summary>
        /// 获取文件版本信息信息
        /// </summary>
        /// </summary>
        /// <param name="model">文件版本信息实体</param>
        /// <returns></returns>
        IResponseMessage Get(object id);

        /// <summary>
        /// 获取文件版本信息信息--多个
        /// </summary>
        /// </summary>
        /// <param name="model">文件版本信息实体</param>
        /// <returns></returns>
        IResponseMessage List(object id);
        /// <summary>
        /// 获取所有文件版本信息数据
        /// </summary>
        /// <returns></returns>
        IResponseMessage All();
        /// <summary>
        /// 获取所有历史的信息
        /// </summary>
        /// <param name="fileid"></param>
        /// <returns></returns>
        IResponseMessage refreshHistory(int fileid);
        /// <summary>
        /// 设置历史
        /// </summary>
        /// <param name="fileid"></param>
        /// <returns></returns>
        IResponseMessage setHistoryData(int fileid,int version);
    }
}
