using Digiproj.Shared.Dtos.Requests.Project;
using DigiProj.Shared.Dtos.Requests.Project;
using DigiProj.Shared.Dtos.Responses.MsUser;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Globalization;
namespace DigiProj.Models.Project
{
    public class FindProjectInputModel : Filter
    {
        public string ProjectId { get; set; }
        public string Column { get; set; }
        public bool Y { get; set; }
    }
}
