using Autofac;

namespace DocumentServer.Core.Comm
{
    public class AutoFacModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(AutoFacConfig.GetAssmenBlys()).InstancePerLifetimeScope()
               .AsImplementedInterfaces().PropertiesAutowired();
            AutoFacConfig.RegisterSpecial(builder);
        }
    }
}
