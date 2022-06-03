using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<TaskDto> GetTaskAsync(int taskId)
        {
            return await _taskDbContext.Tasks.Include(p=> p.Project).FirstOrDefaultAsync(p => p.Id == taskId);
          
        }

        public async Task<TaskDto> AddTaskAsync(TaskDto task)
        {
            var result = await _taskDbContext.Tasks.AddAsync(task);
            await _taskDbContext.SaveChangesAsync();
            return result.Entity;
            
        }
       

        public async Task<TaskDto> DeleteTaskAsync(TaskDto task)
        { 
            _taskDbContext.Remove(task);
            await _taskDbContext.SaveChangesAsync();
            return task;
        }

        public async Task<IEnumerable<Model.TaskDto>> GetAllTasks()
        {
            return await _taskDbContext.Tasks.Include(p=>p.Project).ToListAsync();
            
        }

        
        public async Task<TaskDto> UpdateTaskAsync(TaskDto task)
        {
            var result = await _taskDbContext.Tasks.FirstOrDefaultAsync(p => p.Id == task.Id);
            result.ProjectId = task.ProjectId;
            result.Name = task.Name;
            result.Description = task.Description;
            result.Status = task.Status;
            result.Priority = task.Priority;
            
            await _taskDbContext.SaveChangesAsync();
            return result;
        }
        public ProjectDto GetProject(int projectId)
        {
            var result = _taskDbContext.Projects.FirstOrDefaultAsync(p => p.Id == projectId);
            return result.Result;
        }
    }
}
