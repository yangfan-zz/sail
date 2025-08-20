using Sail.Exam.QuestionKit.QuestionContainers.References;
using Sail.Exam.QuestionKit.Questions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Services;

namespace Sail.Exam.QuestionKit.QuestionContainers
{
    public abstract class QuestionContainerManager<TContainer, TQuestionWithContainer> : DomainService
        where TQuestionWithContainer : IQuestionWithContainer
        where TContainer : IQuestionContainer<TQuestionWithContainer>
    {
        public abstract QuestionContainerType ContainerType { get; }

        protected IQuestionRepository QuestionRepository =>
            LazyServiceProvider.LazyGetRequiredService<IQuestionRepository>();

        protected IQuestionReferencedCheckerManager QuestionReferencedManager =>
            LazyServiceProvider.LazyGetRequiredService<IQuestionReferencedCheckerManager>();

        #region 删除引用试题

        /// <summary>
        /// 删除未引用的问题
        /// </summary>
        /// <param name="questionId">问题标识</param>
        /// <param name="expectedId"></param>
        /// <returns></returns>
        protected virtual async Task DeleteUnreferencedQuestionAsync(Guid questionId, Guid? expectedId = null)
        {
            if (await QuestionReferencedManager.IsReferencedAsync(questionId, expectedId))
            {
                return;
            }

            await QuestionRepository.DeleteAsync(questionId);
        }

        /// <summary>
        /// 删除未被引用的问题
        /// </summary>
        /// <param name="questionIds"></param>
        /// <param name="expectedId"></param>
        /// <returns></returns>
        protected virtual async Task DeleteUnreferencedQuestionsAsync(List<Guid> questionIds, Guid? expectedId = null)
        {
            var unRefQuestionIds = await QuestionReferencedManager.GetUnreferencedAsync(questionIds, expectedId);
            await QuestionRepository.DeleteManyAsync(unRefQuestionIds);
        }

        #endregion

        #region 更新试题

        protected async Task<Question> UpdateQuestionAsync(Guid id, IQuestionBody inputQuestion)
        {
            var question = await QuestionRepository.GetAsync(id);
            question.SetQuestion(inputQuestion);
            return await QuestionRepository.UpdateAsync(question);
        }

        #endregion

        #region 创建试题

        protected virtual async Task<Question> CreateQuestionAsync(IQuestionBody question, Guid? referQuestionId,
            bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entity = await CreateQuestionAsync(question, autoSave, cancellationToken);

            if (!referQuestionId.HasValue)
            {
                return entity;
            }

            var referQuestion =
                await QuestionRepository.FindAsync(referQuestionId.Value, cancellationToken: cancellationToken);

            if (referQuestion == null)
            {
                return entity;
            }

            entity.SetReference(referQuestion.RootQuestionId, referQuestion.Id);

            return entity;
        }

        protected virtual async Task<Question> CreateQuestionAsync(IQuestionBody question,
            bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entity = new Question(GuidGenerator.Create(), question, ContainerType);
            return await QuestionRepository.InsertAsync(entity, autoSave, cancellationToken);
        }

        protected virtual async Task<List<Question>> CreateQuestionsAsync(ICollection<IQuestionBody> questions,
            bool autoSave = false, CancellationToken cancellationToken = default)
        {
            var entities = questions.Select(q => new Question(GuidGenerator.Create(), q, ContainerType)).ToList();

            // 添加问题
            await QuestionRepository.InsertManyAsync(entities, autoSave, cancellationToken);

            return entities;
        }

        #endregion
    }
}
