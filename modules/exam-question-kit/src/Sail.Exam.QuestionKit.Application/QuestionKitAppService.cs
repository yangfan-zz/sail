using Sail.Exam.QuestionKit.Localization;
using Volo.Abp.Application.Services;

namespace Sail.Exam.QuestionKit;

public abstract class QuestionKitAppService : ApplicationService
{
    protected QuestionKitAppService()
    {
        LocalizationResource = typeof(QuestionKitResource);
        ObjectMapperContext = typeof(QuestionKitApplicationModule);
    }
}
