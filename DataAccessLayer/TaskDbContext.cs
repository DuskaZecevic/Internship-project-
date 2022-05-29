using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;



namespace DataAccessLayer
{
    public class TaskDbContext :DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }
        public DbSet<TaskDto> Tasks { get; set;}
        public DbSet<ProjectDto> Projects { get; set; }
    }
}
