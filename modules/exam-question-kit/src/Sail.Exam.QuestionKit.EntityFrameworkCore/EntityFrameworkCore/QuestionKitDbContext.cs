using Microsoft.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.EntityFrameworkCore;

namespace Sail.Exam.QuestionKit.EntityFrameworkCore;

[ConnectionStringName(QuestionKitDbProperties.ConnectionStringName)]
public class QuestionKitDbContext : AbpDbContext<QuestionKitDbContext>, IQuestionKitDbContext
{
    /* Add DbSet for each Aggregate Root here. Example:
     * public DbSet<Question> Questions { get; set; }
     */

    public QuestionKitDbContext(DbContextOptions<QuestionKitDbContext> options)
        : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigureQuestionKit();
    }
}
