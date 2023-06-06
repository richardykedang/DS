namespace DigiProj.Models.Task
{
    public class CreateTaskInputModel
    {
        public string ProjectId { get; set; }
        public string TaskName { get; set; }
        public string TaskOwner { get; set; }
        public string Priority { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }

    public class UpdateTaskInputModel
    {
        public Guid Id { get; set; }
        public string TaskName { get; set; }
        public string TaskOwner { get; set; }
        public string Priority { get; set; }
        public int? Status { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }

    public class DeleteTaskInputModel
    {
        public Guid Id { get; set; }
    }
	public class DeleteMemberInputModel
	{
		public int IdAssign { get; set; }
	}
}
