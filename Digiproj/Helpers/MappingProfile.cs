using AutoMapper;
using DigiProj.Models.Account;
using DigiProj.Shared.Dtos.Responses.MsUser;
using DigiProj.Models;
using DigiProj.Models.Project;
using DigiProj.Shared.Dtos.Requests;
using DigiProj.Shared.Dtos.Requests.Project;
using DigiProj.Shared.Dtos.Responses;
using DigiProj.Shared.Entities;
using Digiproj.Shared.Entities.MsRole;
using Digiproj.Shared.Entities;
using Digiproj.Shared.Dtos.Requests;
using Digiproj.Shared.Dtos.Responses.MsMenu;
using DigiProj.Models.Users;
using Digiproj.Shared.Dtos.Requests.Users;

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
			

			//Dto to Domain 
			CreateMap<MaintenanceResponse, Maintenance>(); //api with sp
            CreateMap<UserRolesResponse, MsRole>(); //api with sp
            CreateMap<ProfilUserResponse, ProfileUser>(); //api with sp
            CreateMap<UserMenusResponse, MsMenu>(); //api with sp
            CreateMap<MsMenusResponse, MsMenus>(); //api with sp

			// User
			CreateMap<SearchUserInputModel, UserRequest>();
		}
	}
}
