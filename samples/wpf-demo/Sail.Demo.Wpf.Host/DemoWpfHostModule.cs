using Sail.Abp.Wpf;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Sail.Demo.Wpf;

[DependsOn(
    typeof(DemoWpfApplicationModule),
    typeof(AbpAutofacModule),
    typeof(SailWpfHostingModule))]
public class DemoWpfHostModule : AbpModule
{

}
