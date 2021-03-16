using DocumentServer.Core.Infrastrure;
using System.Data;

namespace DocmentServer.Core.Business.BbFields
{
    public class BbFieldsBusiness : Base.BaseBusiness, IBbFieldsBusiness
    {
        public BbFieldsBusiness(IConnectionBase _dbConnection) : base(_dbConnection)
        {

        }
    }
}
