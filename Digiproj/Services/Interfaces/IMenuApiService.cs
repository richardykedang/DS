using Digiproj.Shared.Dtos.Requests;
using Digiproj.Shared.Dtos.Responses.MsMenu;
using DigiProj.Shared.Dtos.Responses;

namespace DigiProj.Services.Interfaces
{
    public interface IMenuApiService
    {
        Task<GlobalObjectListResponse<MsMenusResponse>> GetMenuController(MenuControllerRequest requestDto, CancellationToken cancellationToken = default);
    }
}
