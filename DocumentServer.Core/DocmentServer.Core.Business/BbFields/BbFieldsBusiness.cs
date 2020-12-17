using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace DocmentServer.Core.Business.BbFields
{
    public class BbFieldsBusiness : Base.BaseBusiness, IBbFieldsBusiness
    {
        public BbFieldsBusiness(IDbConnection _dbConnection) : base(_dbConnection)
        {

        }
    }
}
