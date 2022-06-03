using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCommon.Enums;




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
            var project = _taskRepository.GetProject(projectTask.ProjectId);
            if (project.StartDate == null && (projectTask.Status == WebApiCommon.Enums.TaskStatus.Done || projectTask.Status == WebApiCommon.Enums.TaskStatus.InProgress))
            {
                return null;
            }
            else if (project.CompletionDate.HasValue && (projectTask.Status == WebApiCommon.Enums.TaskStatus.ToDo|| projectTask.Status == WebApiCommon.Enums.TaskStatus.InProgress))
            {
                return null;
            }
            else if (!Enum.IsDefined(typeof(WebApiCommon.Enums.TaskStatus), projectTask.Status))
            {
                return null;
            }

            TaskDto taskModel = new TaskDto
            {
                Name = projectTask.Name,
                Priority = projectTask.Priority,
                ProjectId = projectTask.ProjectId,
                Description = projectTask.Description,
                Status = projectTask.Status,
                Project = project,
               
                
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
            var project = _taskRepository.GetProject(projectTask.ProjectId);
            DataAccessLayer.Model.TaskDto projectModel = new DataAccessLayer.Model.TaskDto
            {
                Id = taskId,
                ProjectId = projectTask.ProjectId,
                Name = projectTask.Name,
                Description = projectTask.Description,
                Priority = projectTask.Priority,
                Project = project
            };
            projectModel.Status = projectTask.Status;
            var result = await _taskRepository.UpdateTaskAsync(projectModel);
            return result;
        }
        public ProjectDto GetProject(int projectId)
        {
            return _taskRepository.GetProject(projectId);
        }
    }
}
