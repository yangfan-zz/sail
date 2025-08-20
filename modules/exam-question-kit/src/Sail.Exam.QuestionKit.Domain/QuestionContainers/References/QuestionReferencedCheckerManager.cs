using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace Sail.Exam.QuestionKit.QuestionContainers.References
{
    public class QuestionReferencedCheckerManager(IEnumerable<IQuestionReferencedChecker> providers)
        : IQuestionReferencedCheckerManager, ITransientDependency
    {
        public IEnumerable<IQuestionReferencedChecker> Providers { get; protected set; } = providers;

        public async Task<bool> IsReferencedAsync(Guid questionId, Guid? excludeContainerId = null)
        {
            foreach (var provider in Providers)
            {
                if (await provider.IsReferencedAsync(questionId, excludeContainerId))
                {
                    return true;
                }
            }

            return false;
        }

        public async Task<List<Guid>> GetReferencedAsync(ICollection<Guid> questionIds, Guid? expectedId = null)
        {
            if (questionIds.IsNullOrEmpty())
            {
                return new List<Guid>();
            }

            var allIds = questionIds.ToList();
            var referencedIds = new List<Guid>();
            foreach (var provider in Providers)
            {
                var refIds = await provider.GetReferencedAsync(allIds, expectedId);

                referencedIds.AddRange(refIds);

                foreach (var refId in refIds)
                {
                    allIds.Remove(refId);
                }
            }

            return referencedIds;
        }

        public async Task<List<Guid>> GetUnreferencedAsync(ICollection<Guid> questionIds, Guid? excludeContainerId = null)
        {
            return questionIds.Except(await GetReferencedAsync(questionIds, excludeContainerId)).ToList();
        }
    }
}
