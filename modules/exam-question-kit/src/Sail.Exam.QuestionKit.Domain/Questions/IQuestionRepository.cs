using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace Sail.Exam.QuestionKit.Questions
{
    public interface IQuestionRepository : IRepository<Question, Guid>
    {
        Task<List<Question>> GetListAsync(
            QuestionType? questionType,
            string stem,
            int skipCount = 0,
            int maxResultCount = 0,
            string sorting = null,
            ICollection<Guid> ids = null,
            CancellationToken cancellationToken = default);

        Task<int> GetCountAsync(
            QuestionType? questionType,
            string stem,
            CancellationToken cancellationToken = default);
    }
}
