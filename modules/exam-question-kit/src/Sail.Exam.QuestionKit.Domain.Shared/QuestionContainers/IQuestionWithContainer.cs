using Sail.Exam.QuestionKit.Questions;
using System;

namespace Sail.Exam.QuestionKit.QuestionContainers
{
    public interface IQuestionWithContainer : IMustHaveQuestion
    {
        Guid GetContainerId();
    }
}
