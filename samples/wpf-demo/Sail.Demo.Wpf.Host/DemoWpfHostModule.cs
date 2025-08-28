using Sail.Abp.Wpf;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Sail.Demo.Wpf;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(DemoWpfUiModule),
    typeof(SailWpfHostingModule))]
public class DemoWpfHostModule : AbpModule
{

}
