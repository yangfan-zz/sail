using System;
using System.Collections.Generic;
using System.Linq;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Sail.Exam.QuestionKit.QuestionContainers
{
    public abstract class QuestionContainer<TQuestionWithContainer> : FullAuditedAggregateRoot<Guid>,
        IQuestionContainer<TQuestionWithContainer> where TQuestionWithContainer : IQuestionWithContainer
    {
        protected QuestionContainer()
        {
            Questions = new List<TQuestionWithContainer>();
        }

        protected QuestionContainer(Guid id) : base(id)
        {
            Questions = new List<TQuestionWithContainer>();
        }

        /// <summary>
        /// 
        /// </summary>
        public ICollection<TQuestionWithContainer> Questions { get; }

        #region 问题数量

        /// <summary>
        /// 问题数量
        /// </summary>
        public int QuestionCount { get; private set; }

        protected void SetQuestionCount(int count)
        {
            var maxQuestionCount = GetMaxQuestionCount();
            if (count > maxQuestionCount)
            {
                throw new UserFriendlyException($"超出最大问题数量{maxQuestionCount}");
            }

            QuestionCount = count;
        }

        #endregion

        #region 添加问题

        protected TQuestionWithContainer AddQuestion(TQuestionWithContainer question)
        {
            var maxQuestionCount = GetMaxQuestionCount();
            if (QuestionCount + 1 > maxQuestionCount)
            {
                throw new UserFriendlyException($"超出最大问题数量{maxQuestionCount}");
            }

            Questions.Add(question);
            QuestionCount += 1;
            return question;
        }

        #endregion

        #region 移除问题

        internal bool RemoveQuestion(Guid questionId)
        {
            var question = Questions.SingleOrDefault(c => c.QuestionId == questionId);
            return question != null && TryRemoveQuestion(question);
        }

        internal List<Guid> RemoveQuestions(ICollection<Guid> questionIds) => questionIds.Where(RemoveQuestion).ToList();


        protected bool TryRemoveQuestion(TQuestionWithContainer question)
        {
            if (!Questions.Remove(question))
            {
                return false;
            }

            QuestionCount -= 1;
            return true;
        }

        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected virtual int GetMaxQuestionCount() => 99999;
    }
}
