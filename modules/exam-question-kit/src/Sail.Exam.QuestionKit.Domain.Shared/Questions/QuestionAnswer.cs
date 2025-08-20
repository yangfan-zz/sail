using System.Collections.Generic;

namespace Sail.Exam.QuestionKit.Questions
{
    /// <summary>
    /// 问题答案
    /// </summary>
    public class QuestionAnswer
    {
        /// <summary>
        /// 正确答案(支持，判断，单选、多选、填空)
        /// </summary>
        public List<string> CorrectAnswer { get; set; } = new();

        /// <summary>
        /// 
        /// </summary>
        public string? Analysis { get; set; }
    }
}
