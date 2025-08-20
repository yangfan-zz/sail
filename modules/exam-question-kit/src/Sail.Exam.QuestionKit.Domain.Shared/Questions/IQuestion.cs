namespace Sail.Exam.QuestionKit.Questions
{
    public interface IQuestion
    {
        /// <summary>
        /// 题目类型 - 定义题目的形式和答题方式
        /// </summary>
        public QuestionType Type { get; }

        /// <summary>
        /// 题目标题/题干 - 问题的主要描述内容
        /// 示例: "下列关于面向对象编程的描述中，正确的是？"
        /// </summary>
        public string Title { get; }

        /// <summary>
        /// 题目描述/补充说明 - 对题干的额外解释或上下文信息
        /// 示例: "阅读以下代码片段后回答问题"
        /// </summary>
        public string Description { get; }
    }

   
}
