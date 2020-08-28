using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocumentServer.Core.Comm
{
    public class AutoFacModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
           // builder.RegisterAssemblyModules(AutoFacConfig.GetAssmenBlys());
            AutoFacConfig.RegisterSpecial(builder);
            base.Load(builder);
        }
    }
}
