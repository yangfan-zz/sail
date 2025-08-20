using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Sail.Exam.QuestionKit.QuestionContainers.References
{
    public interface IQuestionReferencedCheckerManager
    {
        /// <summary>
        /// 判断给定的问题标识，是否被引用
        /// </summary>
        /// <param name="questionId">问题标识</param>
        /// <param name="excludeContainerId">排除的容器标识</param>
        /// <returns>是否被引用</returns>
        Task<bool> IsReferencedAsync(Guid questionId, Guid? excludeContainerId = null);

        /// <summary>
        /// 判断给定的问题标识，是否被引用
        /// </summary>
        /// <param name="questionIds">问题标识集合</param>
        /// <param name="excludeContainerId">排除的容器标识</param>
        /// <returns>被引用的标识</returns>
        Task<List<Guid>> GetReferencedAsync(ICollection<Guid> questionIds, Guid? excludeContainerId = null);

        /// <summary>
        /// 根据给定的问题标识， 返回那些问题标识没被引用
        /// </summary>
        /// <param name="questionIds">问题标识集合</param>
        /// <param name="excludeContainerId">排除的容器标识</param>
        /// <returns>未被引用的标识</returns>
        Task<List<Guid>> GetUnreferencedAsync(ICollection<Guid> questionIds, Guid? excludeContainerId = null);
    }
}
