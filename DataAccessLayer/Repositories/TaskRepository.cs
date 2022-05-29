using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _taskDbContext;
        public TaskRepository(TaskDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;
        }
        public Task<Model.TaskDto> GetTaskAsync(int taskId)
        {

            throw new NotImplementedException();
        }

        public ProjectDto GetProjectAsync(int ProjectId)
        {
            throw new NotImplementedException();
        }
        public Task<Model.TaskDto> AddTaskAsync(Model.TaskDto task)
        {

            throw new NotImplementedException();
        }

        public Task<TaskDto> DeleteTaskAsync(TaskDto task)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Model.TaskDto>> GetAllTasksAsync()
        {

            throw new NotImplementedException();
        }

        
        public Task<Model.TaskDto> UpdateTaskAsync(Model.TaskDto task)
        {
            throw new NotImplementedException();
        }
        public Task<IEnumerable<TaskDto>> FindAllTasks(int projectId)
        {
            throw new NotImplementedException(); //zavrsi
        }
    }
}
