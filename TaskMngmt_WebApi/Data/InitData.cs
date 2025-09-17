using Microsoft.EntityFrameworkCore;
using TaskMngmt_WebApi.Models;

namespace TaskMngmt_WebApi.Data
{
    public class InitData
    {
        public static void Initialize (IServiceProvider serviceProvider)
        {
            using (var context = new TaskItemDbContext(serviceProvider.GetRequiredService<DbContextOptions<TaskItemDbContext>>()))
            {
                if (context.TaskItems.Any())
                    return;

                context.TaskItems.AddRange(
                    new TaskItem
                    {
                        Name = "Einkaufen",
                        Description = "5 Bananen, 1 kg Brot, Nudeln"
                    },
                    new TaskItem
                    {
                        Name = "Hausaufgaben",
                        Description = "SEW, SYT"
                    }
                    
                );

                context.SaveChanges();
            }
        }

    }
}
