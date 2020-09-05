using System;
using System.Collections.Generic;
using System.Text;
using DocmentServer.Core.Business.IObusiness;
using DocumentServer.Core.Model.DbModel;

namespace DocmentServer.Core.DomainService.IO
{
    public class SystemIODomainService : ISystemIODomainService
    {
        public ISystemIOBusiness systemIOBusiness { get; set; }
        public SystemIODomainService()
        {
        }
        /// <summary>
        /// 判断文件是否达到最大
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public bool IsFileMaxFolder(DocumentServer.Core.Model.DbModel.Physicalhistory model)
        {
            return systemIOBusiness.IsFileMaxFolder(model: model);
        }
        /// <summary>
        /// 创建文件
        /// </summary>
        /// <param name="files"></param>
        /// <returns></returns>
        public Files MakeFile(Files files, DocumentServer.Core.Model.DbModel.Physicalhistory physicalhistory)
        {
            return systemIOBusiness.MakeFile(files: files,physicalhistory:physicalhistory);
        }
        /// <summary>
        /// 进行OnlyOffice数据回调结构
        /// </summary>
        /// <param name="fileid"></param>
        /// <returns
        public FilesVersion TrackFile(Files files, Dictionary<string, object> fileData)
        {
            return systemIOBusiness.TrackFile(files: files, fileData: fileData);
        }
    }
}
