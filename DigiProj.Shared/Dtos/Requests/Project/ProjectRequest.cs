﻿using Digiproj.Shared.Dtos.Requests.Project;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigiProj.Shared.Dtos.Requests.Project
{
	public class SearchProjectRequest : Filter
	{
		public string ProjectName { get; set; }
		public string DepartmentName { get; set; }

		[DefaultValue(0)]
		public int? Status { get; set; }

		public string Column { get; set; }
		public bool Y { get; set; }
	}

	public class CreateProjectRequest
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
		public List<AssignToRequest> AssignTo { get; set; }
	}

	public class CreateMemberRequest
	{
		public string ProjectId { get; set; }
		public List<string> EmployeeId { get; set; }
		public List<AssignToRequest> AssignTo { get; set; }

	}

	public class UpdateProjectRequest
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
	public class DeleteProjectRequest
	{
		public string ProjectId { get; set; }
	}
	public class DetailProjectRequest
	{
		public string ProjectId { get; set; }
	}

	public class FindProjectRequest : Filter
	{
		public string ProjectId { get; set; }
        public string Column { get; set; }
        public bool Y { get; set; }
    }
}
