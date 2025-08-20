using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AutoMapper;
using Volo.Abp.Modularity;
using Volo.Abp.Application;

namespace Sail.Exam.QuestionKit;

[DependsOn(
    typeof(QuestionKitDomainModule),
    typeof(QuestionKitApplicationContractsModule),
    typeof(AbpDddApplicationModule),
    typeof(AbpAutoMapperModule)
    )]
public class QuestionKitApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAutoMapperObjectMapper<QuestionKitApplicationModule>();
        Configure<AbpAutoMapperOptions>(options =>
        {
            options.AddMaps<QuestionKitApplicationModule>(validate: true);
        });
    }
}
