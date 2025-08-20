using System;

namespace Sail.Exam.QuestionKit.Questions
{
    /// <summary>
    /// 试题关系
    /// </summary>
    public interface IQuestionRelation
    {
        public Guid RootQuestionId { get; }

        public Guid? ReferQuestionId { get; }
    }
}
