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
        public async Task<Model.TaskDto> GetTaskAsync(int taskId)
        {
            return await _taskDbContext.Tasks.Include(p => p.Project).FirstOrDefaultAsync(p => p.Id == taskId);
        }

        public async Task<Model.TaskDto> AddTaskAsync(Model.TaskDto task)
        {
            var result = await _taskDbContext.AddAsync(task);
            await _taskDbContext.SaveChangesAsync();
            return result.Entity;
           
        }

        public async Task<TaskDto> DeleteTaskAsync(TaskDto task)
        { 
            _taskDbContext.Remove(task);
            await _taskDbContext.SaveChangesAsync();
            return task;
        }

        public async Task<IEnumerable<Model.TaskDto>> GetAllTasksAsync()
        {
            return await _taskDbContext.Tasks.ToListAsync();
            
        }

        
        public async Task<Model.TaskDto> UpdateTaskAsync(Model.TaskDto task)
        {
            var result = await _taskDbContext.Tasks.FirstOrDefaultAsync(p => p.Id == task.Id);  
            result.Name = task.Name;
            result.Description = task.Description;
            result.Status = task.Status;
            result.Priority = task.Priority;
            result.ProjectId = task.ProjectId;
            await _taskDbContext.SaveChangesAsync();
            return result;
        }
        public async Task<IEnumerable<TaskDto>> FindAllTasks(int projectId)
        {
            IQueryable<Model.TaskDto> AllTasksInProject = _taskDbContext.Tasks.Where(p=>p.ProjectId == projectId);
            return await AllTasksInProject.ToListAsync();
        }
    }
}
