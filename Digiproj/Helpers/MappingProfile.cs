using AutoMapper;
using DigiProj.Models.Account;
using DigiProj.Shared.Dtos.Responses.MsUser;
using DigiProj.Models;
using DigiProj.Models.Project;
using DigiProj.Shared.Dtos.Requests;
using DigiProj.Shared.Dtos.Requests.Project;
using Digiproj.Shared.Dtos.Requests;
using Digiproj.Shared.Dtos.Responses.MsMenu;
using DigiProj.Models.Users;
using Digiproj.Shared.Dtos.Requests.Users;
using DigiProj.Shared.Dtos.Responses;
using DigiProj.Shared.Dtos.Responses.MsTask;

namespace DigiProj.Helpers
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			//Domain to Dto
			CreateMap<LoginInputModel, LoginRequest>();
			CreateMap<UsernameInputModel, UsernameRequest>();
			CreateMap<ChangePasswordInputModel, ChangePasswordRequest>();
			CreateMap<MenuControllerInputModel, MenuControllerRequest>();

			//crud project
			CreateMap<SearchProjectInputModel, SearchProjectRequest>();
			CreateMap<FilterAutoCompleteModel, FilterAutoComplete>();
			CreateMap<DetailProjectInputModel, DetailProjectRequest>();
			CreateMap<DeleteProjectInputModel, DeleteProjectRequest>();

		
			// User
			CreateMap<SearchUserInputModel, UserRequest>();

			CreateMap<CreateProjectInputModel, CreateProjectRequest>();
			CreateMap<UpdateProjectInputModel, UpdateProjectRequest>();

		}
	}
}
