using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
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

        public async Task<DataAccessLayer.Model.TaskDto> AddTaskAsync(ProjectTask projectTask)
        {
            var project = _taskRepository.GetProjectAsync(projectTask.ProjectId);
            DataAccessLayer.Model.TaskDto taskModel = new DataAccessLayer.Model.TaskDto
            {
                Name = projectTask.Name,
                Priority = projectTask.Priority,
                ProjectId = projectTask.ProjectId,
                Description = projectTask.Description,
                Status = projectTask.Status,
                Project = project

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
            return await _taskRepository.GetAllTasksAsync();
        }


        public async Task<DataAccessLayer.Model.TaskDto> GetTaskAsync(int taskId)
        {
            return await _taskRepository.GetTaskAsync(taskId);
        }

        public async Task<DataAccessLayer.Model.TaskDto> UpdateTaskAsync(int taskId, ProjectTask projectTask)
        {
            var project = _taskRepository.GetProjectAsync(projectTask.ProjectId);
            DataAccessLayer.Model.TaskDto projectModel = new DataAccessLayer.Model.TaskDto
            {
                Id = taskId,
                Name = projectTask.Name,
                Project = project,
                ProjectId = projectTask.ProjectId,
                Description = projectTask.Description,
                Priority = projectTask.Priority,
            };
            projectModel.Status = projectTask.Status;
            var result = await _taskRepository.UpdateTaskAsync(projectModel);
            return result;
        }

        public Project GetProjectAsync(int projectId)
        {
            throw new NotImplementedException();
        }
        
        public async Task<IEnumerable<DataAccessLayer.Model.TaskDto>> FindAllTasksAsync(int projectId)
        {
           return await _taskRepository.FindAllTasks(projectId);
        }

    }
}
