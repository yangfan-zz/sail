namespace Sail.Exam.QuestionKit.Questions
{
    /// <summary>
    /// 选择题选项类 - 表示选择题中的一个可选项
    /// 支持文本、图片、音频等多种形式的选项内容
    /// </summary>
    public class QuestionOption
    {
        /// <summary>
        /// 选项文本 - 选项的显示内容，可以是纯文本或HTML格式
        /// 长度限制: 1-1000个字符
        /// </summary>
        public string Text { get; set; } = null!;

        /// <summary>
        /// 选项图片URL - 如果选项包含图片，存储图片的URL地址
        /// 示例: "/images/options/option_a.png"
        /// </summary>
        public string? ImageUrl { get; set; }

        /// <summary>
        /// 选项音频URL - 如果选项包含音频，存储音频的URL地址
        /// 示例: "/audio/options/option_a.mp3"
        /// </summary>
        public string? AudioUrl { get; set; }

        /// <summary>
        /// 是否为正确答案 - 标记此选项是否为题目的正确答案
        /// 注意: 此属性通常只在创建/编辑题目时使用，不应暴露给答题者
        /// </summary>
        public bool IsCorrect { get; set; }

        /// <summary>
        /// 选项类型 - 标识选项的内容类型
        /// 用于前端正确渲染选项内容
        /// </summary>
        public QuestionOptionType Type { get; set; }
    }
}
