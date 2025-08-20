namespace Sail.Exam.QuestionKit.Questions
{
    /// <summary>
    /// 选项类型枚举
    /// </summary>
    public enum QuestionOptionType
    {
        /// <summary>
        /// 文本选项 - 选项内容为纯文本
        /// </summary>
        Text = 0,

        /// <summary>
        /// 图片选项 - 选项内容为图片
        /// </summary>
        Image = 1,

        /// <summary>
        /// 音频选项 - 选项内容为音频
        /// </summary>
        Audio = 2,

        /// <summary>
        /// 视频选项 - 选项内容为视频
        /// </summary>
        Video = 3,

        /// <summary>
        /// 混合选项 - 选项包含文本和多媒体内容
        /// </summary>
        Mixed = 4
    }
}
