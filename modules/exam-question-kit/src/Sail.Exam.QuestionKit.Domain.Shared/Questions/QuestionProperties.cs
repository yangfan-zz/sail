using System.Collections.Generic;

namespace Sail.Exam.QuestionKit.Questions
{
    public class QuestionProperties
    {
        /// <summary>
        /// 选择题选项列表 - 适用于判断、单选、多选等有选项的题型
        /// 每个选项包含值和显示文本
        /// </summary>
        public List<QuestionOption> Options { get; set; } = new();
    }
}
