using BusinessLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;



namespace DataAccessLayer.Model
{
    public class ConnectTaskDb :DbContext
    {
        public ConnectTaskDb(DbContextOptions<ConnectTaskDb> options) : base(options)
        {

        }
        public DbSet<ProjectTask> Tasks { get; set;}
        public DbSet<Project> Projects { get; set; }
    }
}
