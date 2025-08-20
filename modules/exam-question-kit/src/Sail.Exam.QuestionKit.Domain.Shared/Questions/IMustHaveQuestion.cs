using System;

namespace Sail.Exam.QuestionKit.Questions
{
    /// <summary>
    /// 必须要有问标识
    /// </summary>
    public interface IMustHaveQuestion
    {
        public Guid QuestionId { get; }
    }
}
