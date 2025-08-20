using Volo.Abp.Domain;
using Volo.Abp.Modularity;
using Volo.Abp.Commercial.SuiteTemplates;

namespace Sail.Exam.QuestionKit;

[DependsOn(
    typeof(AbpDddDomainModule),
    typeof(VoloAbpCommercialSuiteTemplatesModule),
    typeof(QuestionKitDomainSharedModule)
)]
public class QuestionKitDomainModule : AbpModule
{

}
