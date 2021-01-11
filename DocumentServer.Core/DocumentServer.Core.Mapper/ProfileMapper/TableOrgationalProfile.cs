using AutoMapper;
using DocumentServer.Core.Comm;
using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.Oupt;

namespace DocumentServer.Core.Mapper.ProfileMapper
{
    public class TableOrgationalProfile : Profile, ICommProfile
    {
        public TableOrgationalProfile()
        {
            InitProfile();
        }

        public void InitProfile()
        {
            CreateMap<Organization, TableOrgational>().BeforeMap((data,view)=> {
                view.seq = data.sequence;
                view.sequence = data.sequence;
                view.cnname = data.cnname;
                view.dic_createdate = data.creatdate.ToString("yyyy-MM-dd HH:mm");
                view.dic_orgtype = DocumetCenter.Core.Enum.OrgationalType.Organization.ConvertToDicOrgTypeString();
                view.parentid = data.parentId;
                view.unitid = data.untid;
                view.orgcode = data.orgcode;
                view.id = data.orgid;
                view.enname = data.enname;
                view.orgtype = DocumetCenter.Core.Enum.OrgationalType.Organization;
                view.creator = data.creator;
                view.head = data.head;
                view.c_head = data.c_head;
            });
            CreateMap<UnitInfo, TableOrgational>().BeforeMap((data, view) => {
                view.seq = data.sequence;
                view.sequence = data.sequence;
                view.cnname = data.cnname;
                view.dic_createdate = data.creatdate.ToString("yyyy-MM-dd HH:mm");
                view.dic_orgtype = DocumetCenter.Core.Enum.OrgationalType.Unit.ConvertToDicOrgTypeString();
                view.parentid = data.parentId;
                view.unitid = data.unitid;
                view.orgcode = data.unitcode;
                view.id = data.unitid;
                view.enname = data.enname;
                view.orgtype = DocumetCenter.Core.Enum.OrgationalType.Unit;
                view.creator = data.creator;
                view.head = data.head;
                view.c_head = data.c_head;
            }); 
        }
    }
}
