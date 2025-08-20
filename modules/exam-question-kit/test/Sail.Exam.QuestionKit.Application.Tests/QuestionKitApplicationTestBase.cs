using Volo.Abp.Modularity;

namespace Sail.Exam.QuestionKit;

/* Inherit from this class for your application layer tests.
 * See SampleAppService_Tests for example.
 */
public abstract class QuestionKitApplicationTestBase<TStartupModule> : QuestionKitTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
