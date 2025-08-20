namespace Sail.Exam.QuestionKit;

public static class QuestionKitDbProperties
{
    public static string DbTablePrefix { get; set; } = "QuestionKit";

    public static string? DbSchema { get; set; } = null;

    public const string ConnectionStringName = "QuestionKit";
}
