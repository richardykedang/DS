

using DigiProj.Shared.Dtos.Requests.Project;
using DigiProj.Shared.Dtos.Responses;
using DigiProj.Shared.Dtos.Responses.MsProject;

namespace DigiProj.Services.Interfaces
{
    public interface IProjectApiService
    {
		Task<GlobalObjectListResponse<TextModelProjectResponse>> GetAutoCompleteProjects(CancellationToken cancellationToken = default);
		Task<GlobalObjectListResponse<TextModelResponse>> GetAutoCompleteStatus(CancellationToken cancellationToken = default);
		Task<GlobalObjectListResponse<ProjectResponse>> GetDetailProject(string ProjectId, CancellationToken cancellationToken = default);
		Task<GlobalObjectListResponse<ProjectResponse>> GetProjects(CancellationToken cancellationToken = default);
		Task<GlobalResponse> CreateProject(CreateProjectRequest requestDto, CancellationToken cancellationToken = default);
		Task<GlobalResponse> UpdateProject(UpdateProjectRequest requestDto, CancellationToken cancellationToken = default);
		Task<GlobalObjectListResponse<ProjectResponse>> GetSearchProject(SearchProjectRequest requestDto, CancellationToken cancellationToken = default);
		Task<GlobalResponse> DeleteProject(DeleteProjectRequest requestDto, CancellationToken cancellationToken = default);

        Task<GlobalResponse> CreateMemberProject(CreateMemberRequest requestDto, CancellationToken cancellationToken = default);
        Task<GlobalObjectListResponse<ProjectAutoCompleteResponse>> GetAutoCompleteEmployeeProject(string ProjectId, CancellationToken cancellationToken = default);

        //Task<string> GetProjectLastNumber(CancellationToken cancellationToken = default);


    }
}
