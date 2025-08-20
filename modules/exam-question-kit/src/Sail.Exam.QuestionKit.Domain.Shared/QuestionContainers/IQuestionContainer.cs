using System.Collections.Generic;

namespace Sail.Exam.QuestionKit.QuestionContainers
{
    public interface IQuestionContainer<TContainerWithQuestion>
        where TContainerWithQuestion : IQuestionWithContainer
    {
        /// <summary>
        /// 实体集合
        /// </summary>
        ICollection<TContainerWithQuestion> Questions { get; }

        /// <summary>
        /// 试题数量
        /// </summary>
        int QuestionCount { get; }
    }
}
