using DigiProj.Shared.Dtos.Responses.MsProject;
using DigiProj.Shared.Dtos.Responses;
using DigiProj.Shared.Dtos.Responses.MsTask;
using DigiProj.Shared.Dtos.Requests.Project;
using Digiproj.Shared.Dtos.Requests.Task;

namespace DigiProj.Services.Interfaces
{
    public interface ITaskApiService
    {
        Task<GlobalObjectListResponse<TaskDetailResponse>> GetMemberProjectDetailAsync(string ProjectId, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponse<TaskTotalResponse>> GetTotalTaskProject(string ProjectId, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponse<TaskProjectesponse>> GetTaskProject(string ProjectId, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponse<TaskProjectesponse>> GetTaskEmployeeProject(string EmployeeId,string ProjectId, CancellationToken cancellationToken = default);
        Task<GlobalResponse> CreateTask(CreateTaskRequest requestDto, CancellationToken cancellationToken = default);
        Task<GlobalResponse> DeleteTask(DeleteTaskRequest requestDto, CancellationToken cancellationToken = default);
        Task<GlobalResponse> UpdateTask(UpdateTaskRequest requestDto, CancellationToken cancellationToken = default);
		Task<GlobalObjectListResponse<TaskTotalByProjectResponse>> GetTotalTaskByProject(CancellationToken cancellationToken = default);

	}
}
