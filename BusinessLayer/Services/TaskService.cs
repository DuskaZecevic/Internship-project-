using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;




namespace BusinessLayer.Services
{
    public class TaskService : ITaskServices
    {

        public readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {   
            _taskRepository = taskRepository;
        }
        public async Task<DataAccessLayer.Model.TaskDto> AddTask(ProjectTask projectTask)
        {
            var project = _taskRepository.GetProject(projectTask.ProjectId);
            DataAccessLayer.Model.TaskDto taskModel = new DataAccessLayer.Model.TaskDto
            {
                Name = projectTask.Name,
                Priority = projectTask.Priority,
                ProjectId = projectTask.ProjectId,
                Description = projectTask.Description,
                Status = projectTask.Status,
                
            };
            var result = await _taskRepository.AddTask(taskModel);
            return result;
            
        }

        public Task AddTask(TaskDto dtoTask)
        {
            throw new NotImplementedException();
        }

        public Task<Task> DeleteTask(Task task)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<DataAccessLayer.Model.TaskDto>> GetAllTasks()
        {
            return await _taskRepository.GetAllTasks();
        }

        public Project GetProject(int ProjectId)
        {
            throw new NotImplementedException();
        }

        public async Task<DataAccessLayer.Model.TaskDto> GetTask(int taskId)
        {
            return await _taskRepository.GetTask(taskId);
        }

        public Task<Task> UpdateTask(int taskId, ProjectTask projectTask)
        {
            throw new NotImplementedException();
        }

        Task<Task> ITaskServices.AddTask(ProjectTask projectTask)
        {
            throw new NotImplementedException();
        }

        Task<IEnumerable<Task>> ITaskServices.GetAllTasks()
        {
            throw new NotImplementedException();
        }

        Task<Task> ITaskServices.GetTask(int taskId)
        {
            throw new NotImplementedException();
        }
    }
}
