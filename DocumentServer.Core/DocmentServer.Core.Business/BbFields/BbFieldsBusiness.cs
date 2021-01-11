using System.Data;

namespace DocmentServer.Core.Business.BbFields
{
    public class BbFieldsBusiness : Base.BaseBusiness, IBbFieldsBusiness
    {
        public BbFieldsBusiness(IDbConnection _dbConnection) : base(_dbConnection)
        {

        }
    }
}
