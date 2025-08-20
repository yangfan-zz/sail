using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Volo.Abp;
using Volo.Abp.Domain.Entities.Auditing;

namespace Sail.Exam.QuestionKit.Questions
{
    public class Question : FullAuditedAggregateRoot<Guid>, IQuestionBody, IQuestionReference
    {
        #region 构造函数

        protected Question()
        {

        }

        internal Question(Guid id, IQuestionBody question, QuestionContainerType containerType) : base(id)
        {
            SetQuestion(question);
            SetReference(id, null);
            CreationLocation = containerType;
        }

        #endregion

        #region 试题关系

        public Guid RootQuestionId { get; protected set; }

        public Guid? ReferQuestionId { get; protected set; }

        #endregion


        /// <summary>
        /// 题目类型 - 定义题目的形式和答题方式
        /// </summary>
        public QuestionType Type { get; protected set; }

        /// <summary>
        /// 题目标题/题干 - 问题的主要描述内容
        /// 示例: "下列关于面向对象编程的描述中，正确的是？"
        /// </summary>
        public string Title { get; protected set; }

        /// <summary>
        /// 题目描述/补充说明 - 对题干的额外解释或上下文信息
        /// 示例: "阅读以下代码片段后回答问题"
        /// </summary>
        public string Description { get; protected set; }

        /// <summary>
        /// 选择题选项列表 - 适用于判断、单选、多选等有选项的题型
        /// 每个选项包含值和显示文本
        /// </summary>
        public ICollection<QuestionOption> Options { get; set; } = new Collection<QuestionOption>();

        /// <summary>
        /// 问题答案
        /// </summary>
        public QuestionAnswer Answer { get; set; }

        /// <summary>
        /// 试题创建时，所在的位置
        /// </summary>
        public QuestionContainerType CreationLocation { get; protected set; }

        internal void SetQuestion(IQuestionBody question)
        {
            Check.NotNull(question, nameof(question));

            Title = Check.NotNullOrWhiteSpace(question.Title, nameof(Question.Title));
            Type = question.Type;

            Options.Clear();
            if (!question.Options.IsNullOrEmpty())
            {
                foreach (var option in question.Options)
                {
                    Options.Add(option);
                }
            }

            Answer = question.Answer;
        }

        internal void SetReference(Guid rootId, Guid? referId)
        {
            RootQuestionId = rootId;
            ReferQuestionId = referId;
        }
    }
}
