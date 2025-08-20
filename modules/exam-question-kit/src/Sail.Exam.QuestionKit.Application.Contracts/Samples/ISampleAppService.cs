using System.Threading.Tasks;
using Volo.Abp.Application.Services;

namespace Sail.Exam.QuestionKit.Samples;

public interface ISampleAppService : IApplicationService
{
    Task<SampleDto> GetAsync();

    Task<SampleDto> GetAuthorizedAsync();
}
