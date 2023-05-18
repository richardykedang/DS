using AutoMapper;
using DigiProj.Models.Account;
using DigiProj.Shared.Dtos.Responses.MsUser;
using DigiProj.Models;
using DigiProj.Models.Account;
using DigiProj.Models.Project;
using DigiProj.Shared.Dtos.Requests;
using DigiProj.Shared.Dtos.Requests.Project;
using DigiProj.Shared.Dtos.Responses;
using DigiProj.Shared.Entities;
using System.Diagnostics;

namespace DigiProj.Helpers
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			//Domain to Dto
			CreateMap<LoginInputModel, LoginRequest>();
			CreateMap<ChangePasswordInputModel, ChangePasswordRequest>();
			CreateMap<SearchProjectInputModel, SearchProjectRequest>();
			CreateMap<FilterAutoCompleteModel, FilterAutoComplete>();
			CreateMap<DetailProjectInputModel, DetailProjectRequest>();

			//Dto to Domain 
			CreateMap<MaintenanceResponse, Maintenance>();
			//CreateMap<UserMenusResponse, MsMenu>();

			CreateMap<ProfilUserResponse, ProfileUser>();

		}
	}
}
