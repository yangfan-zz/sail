using System;

namespace Sail.Exam.QuestionKit.Questions
{
    /// <summary>
    /// 试题关系
    /// </summary>
    public interface IQuestionReference
    {
        public Guid RootQuestionId { get; }

        public Guid? ReferQuestionId { get; }
    }
}
