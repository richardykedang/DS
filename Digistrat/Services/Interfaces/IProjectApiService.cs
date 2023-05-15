﻿using Digistrat.Shared.Dtos.Requests;
using Digistrat.Shared.Dtos.Requests.Project;
using Digistrat.Shared.Dtos.Responses;
using Digistrat.Shared.Dtos.Responses.MsProject;

namespace Digistrat.Services.Interfaces
{
    public interface IProjectApiService
    {
        Task<GlobalObjectListResponse<ProjectResponse>> GetProjects(CancellationToken cancellationToken = default);

        Task<GlobalObjectListResponse<ProjectResponse>> GetSearchProject(SearchProjectRequest requestDto, CancellationToken cancellationToken = default);


    }
}