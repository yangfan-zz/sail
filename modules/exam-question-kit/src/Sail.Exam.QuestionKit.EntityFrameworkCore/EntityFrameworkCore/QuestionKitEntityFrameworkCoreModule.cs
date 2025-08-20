using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace Sail.Exam.QuestionKit.EntityFrameworkCore;

[DependsOn(
    typeof(QuestionKitDomainModule),
    typeof(AbpEntityFrameworkCoreModule)
)]
public class QuestionKitEntityFrameworkCoreModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddAbpDbContext<QuestionKitDbContext>(options =>
        {
            options.AddDefaultRepositories<IQuestionKitDbContext>(includeAllEntities: true);
            
            /* Add custom repositories here. Example:
            * options.AddRepository<Question, EfCoreQuestionRepository>();
            */
        });
    }
}
