using Volo.Abp.Modularity;

namespace Sail.Exam.QuestionKit;

/* Inherit from this class for your domain layer tests.
 * See SampleManager_Tests for example.
 */
public abstract class QuestionKitDomainTestBase<TStartupModule> : QuestionKitTestBase<TStartupModule>
    where TStartupModule : IAbpModule
{

}
