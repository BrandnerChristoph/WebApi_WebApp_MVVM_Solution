using Microsoft.EntityFrameworkCore;
using TaskMngmt_WebApi.Models;

namespace TaskMngmt_WebApi.Data
{
    public class TaskItemDbContext : DbContext
    {

        public DbSet<TaskItem> TaskItems { get; set; }

        public TaskItemDbContext(DbContextOptions<TaskItemDbContext> options) : base(options) { }

    }
}
