namespace TaskMngmt_WebApi.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int IsFinished { get; set; } = 0;
        public DateTime CreatedAt { get; set; }

        public TaskItem()
        {
            this.CreatedAt = DateTime.Now;
        }
    }
}
