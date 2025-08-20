using Volo.Abp.Modularity;

namespace Sail.Exam.QuestionKit;

[DependsOn(
    typeof(QuestionKitDomainModule),
    typeof(QuestionKitTestBaseModule)
)]
public class QuestionKitDomainTestModule : AbpModule
{

}
