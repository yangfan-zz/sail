using Volo.Abp.Application;
using Volo.Abp.Modularity;

namespace Sail.Abp.Wpf.Mvvm;

[DependsOn(typeof(SailWpfModule),
    typeof(AbpDddApplicationModule))]
public class SailWpfMvvmModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        base.ConfigureServices(context);
    }
}