using BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;



namespace DataAccessLayer.Model
{
    public class TaskDbContext :DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options)
        {

        }
        public DbSet<ProjectTask> Tasks { get; set;}
        public DbSet<Project> Projects { get; set; }
    }
}
