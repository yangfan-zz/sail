namespace Sail.Exam.QuestionKit.Questions
{
    /// <summary>
    /// 题目类型枚举
    /// </summary>
    public enum QuestionType
    {
        /// <summary>
        /// 单项选择题 - 只有一个正确答案的选择题
        /// </summary>
        SingleChoice = 0,

        /// <summary>
        /// 多项选择题 - 有多个正确答案的选择题
        /// </summary>
        MultipleChoice = 1,

        /// <summary>
        /// 判断题 - 判断正误的题目
        /// </summary>
        TrueFalse = 2,

        /// <summary>
        /// 填空题 - 在空白处填写答案的题目
        /// </summary>
        FillInTheBlank = 3,

        /// <summary>
        /// 简答题 - 需要简要回答的题目
        /// </summary>
        ShortAnswer = 4,

        /// <summary>
        /// 论述题 - 需要详细阐述观点的题目
        /// </summary>
        Essay = 5,

        /// <summary>
        /// 编程题 - 需要编写代码解决的题目
        /// </summary>
        Programming = 6,

        /// <summary>
        /// 计算题 - 需要进行数学计算的题目
        /// </summary>
        Calculation = 7,

        /// <summary>
        /// 案例分析题 - 基于案例进行分析的题目
        /// </summary>
        CaseStudy = 8,

        /// <summary>
        /// 匹配题 - 将左右两列项目正确匹配的题目
        /// </summary>
        Matching = 9,

        /// <summary>
        /// 排序题 - 将项目按正确顺序排列的题目
        /// </summary>
        Sequencing = 10,

        /// <summary>
        /// 作图题 - 需要绘制图表或图形的题目
        /// </summary>
        Drawing = 11,

        /// <summary>
        /// 听力题 - 基于音频内容回答的题目
        /// </summary>
        Listening = 12,

        /// <summary>
        /// 口语题 - 需要口头回答的题目
        /// </summary>
        Speaking = 13,

        /// <summary>
        /// 阅读理解题 - 基于阅读材料回答的题目
        /// </summary>
        ReadingComprehension = 14,

        /// <summary>
        /// 综合题 - 综合多种技能和知识的题目
        /// </summary>
        Integrated = 15
    }
}
