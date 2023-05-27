using DigiProj.Shared.Dtos.Responses.MsProject;
using DigiProj.Shared.Dtos.Responses;
using DigiProj.Shared.Dtos.Responses.MsTask;

namespace DigiProj.Services.Interfaces
{
    public interface ITaskApiService
    {
        Task<GlobalObjectListResponse<TaskDetailResponse>> GetDetailTask(string ProjectId, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponse<TaskTotalResponse>> GetTotalTaskProject(string ProjectId, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponse<TaskProjectesponse>> GetTaskProject(string ProjectId, CancellationToken cancellationToken = default);

    }
}
