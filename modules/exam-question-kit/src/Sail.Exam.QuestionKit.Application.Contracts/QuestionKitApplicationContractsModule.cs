using Volo.Abp.Application;
using Volo.Abp.Modularity;
using Volo.Abp.Authorization;

namespace Sail.Exam.QuestionKit;

[DependsOn(
    typeof(QuestionKitDomainSharedModule),
    typeof(AbpDddApplicationContractsModule),
    typeof(AbpAuthorizationModule)
    )]
public class QuestionKitApplicationContractsModule : AbpModule
{

}
