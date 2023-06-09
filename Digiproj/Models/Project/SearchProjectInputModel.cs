﻿using Digiproj.Shared.Dtos.Requests.Project;
using DigiProj.Shared.Dtos.Requests.Project;
using DigiProj.Shared.Dtos.Responses.MsUser;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Globalization;

namespace DigiProj.Models.Project
{
	public class SearchProjectInputModel : Filter
	{

		public string ProjectName { get; set; }
		public string DepartmentName { get; set; }

		[DefaultValue(0)]
		public int? Status { get; set; }
		public string Column { get; set; }
		public bool Y { get; set; }
	}

	public class CreateProjectInputModel
	{
		public string ProjectId { get; set; }
		public string ProjectName { get; set; }
		public string ProjectOwner { get; set; }
		public int DepartmentId { get; set; }
		public int Status { get; set; }
		public string Summary { get; set; }
		public DateTime StartDate { get; set; }
		public DateTime EndDate { get; set; }
		public bool IsActive { get; set; }

		////parameter array
		[Required]
		public List<string> EmployeeId { get; set; }
		public List<AssignToInputModel> AssignTo { get; set; }

	}

    public class CreateMemberInputModel
    {
        public string ProjectId { get; set; }
        public List<string> EmployeeId { get; set; }
        public List<AssignToRequest> AssignTo { get; set; }

    }

    public class UpdateProjectInputModel
	{
		public string ProjectId { get; set; }
		public string ProjectName { get; set; }
		public string ProjectOwner { get; set; }
		public int DepartmentId { get; set; }
		public int Status { get; set; }
		public string Summary { get; set; }
		public string StartDate { get; set; }
		public string EndDate { get; set; }
		public bool IsActive { get; set; }
	}
	public class DeleteProjectInputModel
	{
		public string ProjectId { get; set; }
	}

	public class DetailProjectInputModel
	{
		public string ProjectId { get; set; }
	}
}
