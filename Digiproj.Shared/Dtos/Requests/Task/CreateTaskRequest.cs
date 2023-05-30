using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Digiproj.Shared.Dtos.Requests.Task
{
    public class CreateTaskRequest
    {
        public string ProjectId { get; set; }
        public string TaskName { get; set; }
        public string TaskOwner { get; set; }
        public string Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class UpdateTaskRequest
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string TaskOwner { get; set; }
        public string Priority { get; set; }
        public int? Status { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class DeleteTaskRequest
    {
        public Guid Id { get; set; }
    }
}
