namespace TaskManagerServer.Entities
{
    public class TaskEntity
    {
        public int TaskId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public Status TaskStatus { get; set; }
    }
}
