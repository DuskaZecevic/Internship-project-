using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _taskdbContext;
        public TaskRepository(TaskDbContext taskDbContext)
        {
            _taskdbContext = taskDbContext;
        }
        public Task<TaskDto> AddTask(TaskDto task)
        {
            throw new NotImplementedException();
        }

        public Task<TaskDto> DeleteTask(TaskDto task)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskDto>> GetAllTasks()
        {
            throw new NotImplementedException();
        }

        public ProjectDto GetProject(int ProjectId)
        {
            throw new NotImplementedException();
        }

        public Task<TaskDto> GetTask(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskDto> UpdateTask(TaskDto task)
        {
            throw new NotImplementedException();
        }
    }
}
