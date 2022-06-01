using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;




namespace BusinessLayer.Services
{
    public class TaskService : ITaskService
    {

        public readonly ITaskRepository _taskRepository;
        public TaskService(ITaskRepository taskRepository)
        {   
            _taskRepository = taskRepository;
        }

        public async Task<TaskDto> AddTaskAsync(TaskDto projectTask)
        {
            
            TaskDto taskModel = new TaskDto
            {
                Name = projectTask.Name,
                Priority = projectTask.Priority,
                Id = projectTask.Id,
                Description = projectTask.Description,
                Status = projectTask.Status,
                
            };
            var result = await _taskRepository.AddTaskAsync(taskModel);
            return result;
            
        }

        public async Task<DataAccessLayer.Model.TaskDto> DeleteTaskAsync(DataAccessLayer.Model.TaskDto taskDto)
        {
            await _taskRepository.DeleteTaskAsync(taskDto);
            return taskDto;
        }

        public async Task<IEnumerable<DataAccessLayer.Model.TaskDto>> GetAllTasksAsync()
        {
            return await _taskRepository.GetAllTasks();
        }


        public async Task<DataAccessLayer.Model.TaskDto> GetTaskAsync(int taskId)
        {
            return await _taskRepository.GetTaskAsync(taskId);
        }

        public async Task<DataAccessLayer.Model.TaskDto> UpdateTaskAsync(int taskId, ProjectTask projectTask)
        {
            
            DataAccessLayer.Model.TaskDto projectModel = new DataAccessLayer.Model.TaskDto
            {
                //ProjectId = taskId,
                Id = projectTask.Id,
                Name = projectTask.Name,
                Description = projectTask.Description,
                Priority = projectTask.Priority,
            };
            projectModel.Status = projectTask.Status;
            var result = await _taskRepository.UpdateTaskAsync(projectModel);
            return result;
        }
    }
}
