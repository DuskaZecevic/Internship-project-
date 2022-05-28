using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataAccessLayer.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _taskDbContext;
        public TaskRepository(TaskDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;
        }
        public Task<Model.TaskDto> GetTask(int taskId)
        {

            throw new NotImplementedException();
        }

        public ProjectDto GetProject(int ProjectId)
        {
            throw new NotImplementedException();
        }
        public Task<TaskDto> AddTask(TaskDto task)
        {

            throw new NotImplementedException();
        }

        public Task<TaskDto> DeleteTask(TaskDto task)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Model.TaskDto>> GetAllTasks()
        {

            throw new NotImplementedException();
        }

        
        public Task<Model.TaskDto> UpdateTask(Model.TaskDto task)
        {
            throw new NotImplementedException();
        }
    }
}
