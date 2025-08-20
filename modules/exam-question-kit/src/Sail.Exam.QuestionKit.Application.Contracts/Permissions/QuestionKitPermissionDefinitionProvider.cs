using Sail.Exam.QuestionKit.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace Sail.Exam.QuestionKit.Permissions;

public class QuestionKitPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(QuestionKitPermissions.GroupName, L("Permission:QuestionKit"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<QuestionKitResource>(name);
    }
}
