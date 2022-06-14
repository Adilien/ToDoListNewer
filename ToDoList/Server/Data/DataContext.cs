using Microsoft.EntityFrameworkCore;
using ToDoList.Shared;

namespace ToDoList.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTask>().HasData(
                new UserTask { Id = 1, Text = "I need to book a ticket for tomorrow's interview" },
                new UserTask { Id = 2, Text = "My ticket to London next week needs to have an Open Return." }
            );
        }

        public DbSet<UserTask> UserTasks { get; set; }
    }
}
