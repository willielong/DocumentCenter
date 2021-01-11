using AutoMapper;
using DocumentServer.Core.Model.DbModel;
using DocumentServer.Core.Model.Input;
using DocumentServer.Core.Model.Oupt;

namespace DocumentServer.Core.Mapper
{
    public class AccoutInfoProfile : Profile,ICommProfile
    {
        public AccoutInfoProfile()
        {
            InitProfile();
        }

        public void InitProfile()
        {
            CreateMap<AccoutInfo, AccountOutput>().BeforeMap((data, dto) =>
            {
                ///创建人
                //if (!string.IsNullOrWhiteSpace(data.Caretor) && data.Caretor.Split('|').Length > 1)
                //{
                //    dto.dis_caretor = data.Caretor.Split('|')[0];
                //    dto.caretor = data.Caretor.Split('|')[1];
                //}

                /////修改人
                //if (!string.IsNullOrWhiteSpace(data.Modifier) && data.Modifier.Split('|').Length > 1)
                //{
                //    dto.dis_modifier = data.Modifier.Split('|')[0];
                //    dto.modifier = data.Modifier.Split('|')[1];
                //}
            });
            CreateMap<AccountInput, AccoutInfo>();
        }
    }
}
