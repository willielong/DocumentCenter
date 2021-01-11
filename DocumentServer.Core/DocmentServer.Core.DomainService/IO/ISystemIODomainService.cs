using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.OnlyOfficeConfigModel;

namespace DocmentServer.Core.DomainService.IO
{
    public interface ISystemIODomainService
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
        /// <returns></returns>
        FilesVersion TrackFile(Files files, OutOfficeConfigModel fileData);
    }
}
