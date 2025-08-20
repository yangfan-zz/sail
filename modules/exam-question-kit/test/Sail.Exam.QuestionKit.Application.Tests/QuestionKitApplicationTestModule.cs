using Volo.Abp.Modularity;

namespace Sail.Exam.QuestionKit;

[DependsOn(
    typeof(QuestionKitApplicationModule),
    typeof(QuestionKitDomainTestModule)
    )]
public class QuestionKitApplicationTestModule : AbpModule
{

}
