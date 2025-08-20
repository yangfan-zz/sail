using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Http.Client;
using Volo.Abp.Modularity;
using Volo.Abp.VirtualFileSystem;

namespace Sail.Exam.QuestionKit;

[DependsOn(
    typeof(QuestionKitApplicationContractsModule),
    typeof(AbpHttpClientModule))]
public class QuestionKitHttpApiClientModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(QuestionKitApplicationContractsModule).Assembly,
            QuestionKitRemoteServiceConsts.RemoteServiceName
        );

        Configure<AbpVirtualFileSystemOptions>(options =>
        {
            options.FileSets.AddEmbedded<QuestionKitHttpApiClientModule>();
        });

    }
}
