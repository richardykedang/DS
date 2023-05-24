using DigiProj.Shared.Dtos.Responses.MsProject;
using DigiProj.Shared.Dtos.Responses;
using Digiproj.Shared.Dtos.Responses.MsDepartment;

namespace DigiProj.Services.Interfaces
{
	public interface IDepartmentService
	{
		Task<GlobalObjectListResponse<DepartmentResponse>> GetDepartment(CancellationToken cancellationToken = default);

	}
}
