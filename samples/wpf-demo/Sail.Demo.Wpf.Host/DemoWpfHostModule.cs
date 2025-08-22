using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace Sail.Demo.Wpf.Host;

[DependsOn(typeof(AbpAutofacModule))]
public class DemoWpfHostModule : AbpModule
{
  
}
