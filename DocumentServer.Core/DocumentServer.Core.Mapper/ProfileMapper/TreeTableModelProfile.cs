using AutoMapper;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.Oupt;
using DocumetCenter.Core.Enum;

namespace DocumentServer.Core.Mapper.ProfileMapper
{
    public class TreeTableModelProfile : Profile, ICommProfile
    {
        public TreeTableModelProfile()
        {
            InitProfile();
        }

        public void InitProfile()
        {
            CreateMap<FileFloder, TreeTableModel>().BeforeMap((data, dto) =>
            {
                dto.cnname = data.cnname;
                dto.enname = data.enname;
                dto.currentVersion = "";
                dto.dic_filetype = TextType.文件夹.ToString();
                dto.dic_orgtype = data.flodertype.ConvertToOrgTypeString();
                dto.ext = "";
                dto.filetype = (int)TextType.文件夹;
                dto.id = data.autoid;
                dto.orgtype = data.flodertype;
                dto.sequence = data.sequence;
                dto.size = "";
                dto.path = data.path;
                dto.orgid = data.orgid;
                dto.fileurl = "";
            });
            CreateMap<Files, TreeTableModel>().BeforeMap((data, dto) =>
            {
                dto.cnname = data.cnname;
                dto.enname = data.enname;
                dto.currentVersion = data.currentVersion.ToString();
                dto.dic_filetype = data.ext.ConvertToExt();
                dto.dic_orgtype = data.filetype.ConvertToOrgTypeString();
                dto.ext = data.ext;
                dto.filetype = data.ext.ConvertToExtInt();
                dto.id = data.autoid;
                dto.orgtype = data.filetype;
                dto.sequence = data.sequence;
                dto.size = data.size.CovertToGb();
                dto.path = data.path;
                dto.orgid = -1;
            });
        }
    }
}
