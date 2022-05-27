using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;




namespace BusinessLayer.Services
{
    public class TaskService : ITaskServices
    {
        

        public Task<Task> AddTask(ProjectTask projectTask)
        {
            throw new NotImplementedException();
        }

        public Task<Task> DeleteTask(int taskId)
        {
            throw new NotImplementedException();
        }

        public Task<Task> GetTask(int taskId)
        {
            throw new NotImplementedException();
        }

        public Task<Task> UpdateTask(int Id, ProjectTask projectTask)
        {
            throw new NotImplementedException();
        }
    }
}
