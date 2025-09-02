using Sail.Abp.Avalonia.Hosting;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace AvaloniaApplication1;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(SailAvaloniaHostingModule))]
public class AvaloniaApplication1Module : AbpModule
{

}
