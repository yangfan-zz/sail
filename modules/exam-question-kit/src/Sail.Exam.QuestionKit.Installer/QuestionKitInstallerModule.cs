using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Sail.Exam.QuestionKit;

[DependsOn(
    typeof(AbpVirtualFileSystemModule)
    )]
public class QuestionKitInstallerModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<QuestionKitInstallerModule>();
        });
    }
}
