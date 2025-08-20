using Volo.Abp.Reflection;

namespace Sail.Exam.QuestionKit.Permissions;

public class QuestionKitPermissions
{
    public const string GroupName = "QuestionKit";

    public static string[] GetAll()
    {
        return ReflectionHelper.GetPublicConstantsRecursively(typeof(QuestionKitPermissions));
    }
}
