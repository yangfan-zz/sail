using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Sail.Exam.QuestionKit.EntityFrameworkCore;

[ConnectionStringName(QuestionKitDbProperties.ConnectionStringName)]
public interface IQuestionKitDbContext : IEfCoreDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * DbSet<Question> Questions { get; }
     */
}
