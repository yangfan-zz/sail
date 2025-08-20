using Sail.Exam.QuestionKit.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace Sail.Exam.QuestionKit;

public abstract class QuestionKitController : AbpControllerBase
{
    protected QuestionKitController()
    {
        LocalizationResource = typeof(QuestionKitResource);
    }
}
