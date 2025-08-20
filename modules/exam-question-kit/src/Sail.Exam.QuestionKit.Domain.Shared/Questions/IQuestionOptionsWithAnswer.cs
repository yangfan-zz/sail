using System.Collections.Generic;

namespace Sail.Exam.QuestionKit.Questions
{
    /// <summary>
    /// 问题选项和答案
    /// </summary>
    public interface IQuestionOptionsWithAnswer
    {
        ICollection<QuestionOption> Options { get; }

        QuestionAnswer Answer { get; }
    }
}
