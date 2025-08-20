using Sail.Exam.QuestionKit.QuestionContainers;
using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace Sail.Exam.QuestionKit.EducationQuestions
{
    /// <summary>
    /// 教育相关试题
    /// </summary>
    public class EducationQuestion : FullAuditedAggregateRoot<Guid>, IQuestionWithContainer
    {
        protected EducationQuestion()
        {
        }

        public EducationQuestion(Guid id, Guid questionId) : base(id)
        {
            QuestionId = questionId;
        }

        /// <summary>
        /// 试题编号
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        /// 试题标识
        /// </summary>
        public Guid QuestionId { get; }
        
        public Guid GetContainerId()
        {
            throw new NotImplementedException();
        }
    }
}
