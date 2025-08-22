using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Sail.Demo.Wpf;

[DependsOn(
    typeof(DemoWpfApplicationModule),
    typeof(AbpAutofacModule))]
public class DemoWpfHostModule : AbpModule
{

}
