using AutoMapper;
using Digistrat.Models.Account;
using Digistrat.Models.Project;
using Digistrat.Shared.Dtos.Requests;
using Digistrat.Shared.Dtos.Requests.Project;
using Digistrat.Shared.Dtos.Responses;
using Digistrat.Shared.Dtos.Responses.MsUser;
using Digistrat.Shared.Entities;
using System.Diagnostics;

namespace Digistrat.Helpers
{
    public class MappingProfile : Profile
	{
		public MappingProfile()
		{
			//Domain to Dto
			CreateMap<LoginInputModel, LoginRequest>();
			CreateMap<ChangePasswordInputModel, ChangePasswordRequest>();
			CreateMap<SearchProjectInputModel, SearchProjectRequest>();

			//Dto to Domain 
			CreateMap<MaintenanceResponse, Maintenance>();
			//CreateMap<UserMenusResponse, MsMenu>();

			CreateMap<ProfilUserResponse, ProfileUser>();

		}
	}
}
