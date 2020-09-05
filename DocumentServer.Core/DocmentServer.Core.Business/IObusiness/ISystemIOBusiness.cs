using DocumentServer.Core.Model.DbModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace DocmentServer.Core.Business.IObusiness
{
    public interface ISystemIOBusiness
    {
        /// <summary>
        /// 判断文件是否达到最大
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        bool IsFileMaxFolder(DocumentServer.Core.Model.DbModel.Physicalhistory model);
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        Files MakeFile(Files files, DocumentServer.Core.Model.DbModel.Physicalhistory physicalhistory);
        /// <summary>
        /// 进行OnlyOffice数据回调结构
        /// </summary>
        /// <param name="fileid"></param>
        /// <returns
        FilesVersion TrackFile(Files files, Dictionary<string, object> fileData);
    }
}
