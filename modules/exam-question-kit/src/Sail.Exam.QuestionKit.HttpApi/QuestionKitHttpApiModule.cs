using Localization.Resources.AbpUi;
using Sail.Exam.QuestionKit.Localization;
using Volo.Abp.AspNetCore.Mvc;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Microsoft.Extensions.DependencyInjection;

namespace Sail.Exam.QuestionKit;

[DependsOn(
    typeof(QuestionKitApplicationContractsModule),
    typeof(AbpAspNetCoreMvcModule))]
public class QuestionKitHttpApiModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        PreConfigure<IMvcBuilder>(mvcBuilder =>
        {
            mvcBuilder.AddApplicationPartIfNotExists(typeof(QuestionKitHttpApiModule).Assembly);
        });
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpLocalizationOptions>(options =>
        {
            options.Resources
                .Get<QuestionKitResource>()
                .AddBaseTypes(typeof(AbpUiResource));
        });
    }
}
