using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using DataAccessLayer.Repositories;
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

        public async Task<ProjectTask> AddTaskAsync(ProjectTask projectTask)
        {
            var project = _taskRepository.GetProject(projectTask.ProjectId);
            TaskDto taskModel = GetMappedTaskDto(projectTask);
            
            taskModel.Project = project;
           
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
            var result = await _taskRepository.AddTaskAsync(taskModel);
            return GetMappedTask(result);
            
        }

        public async Task<ProjectTask> DeleteTaskAsync(int id)
        {
            var result = await _taskRepository.GetTaskAsync(id);
            await _taskRepository.DeleteTaskAsync(result);
            return GetMappedTask(result);
           
            
        }

        public async Task<IEnumerable<ProjectTask>> GetAllTasksAsync()
        {
            
            
            var tasks = new List<ProjectTask>();
            foreach (var taskDto in await _taskRepository.GetAllTasks())
             {

                 tasks.Add(GetMappedTask(taskDto));

             }
             return tasks;
        }


        public async Task<ProjectTask> GetTaskAsync(int taskId)
        {
            return GetMappedTask(await _taskRepository.GetTaskAsync(taskId));
        }

        public async Task<ProjectTask> UpdateTaskAsync(int taskId, ProjectTask projectTask)
        {
            var project = _taskRepository.GetProject(projectTask.ProjectId);
            TaskDto taskModel = GetMappedTaskDto(projectTask);
            taskModel.Id = taskId;
            taskModel.Project = project;
            taskModel.Status = projectTask.Status;

            var result = GetMappedTask ( await _taskRepository.UpdateTaskAsync(taskModel));
            return result;
            
        }

    
        public ProjectDto GetProject(int projectId)
        {
            var result = _taskRepository.GetProject(projectId);
            return result;
        }
        private ProjectTask GetMappedTask(TaskDto taskDto)
        {
            return new ProjectTask()
            {
                ProjectId = taskDto.ProjectId,
                Name = taskDto.Name,
                Description = taskDto.Description,
                Priority = taskDto.Priority,
                Status = taskDto.Status,
                
            };
        }
        private TaskDto GetMappedTaskDto(ProjectTask projectTask)
        {
            return new TaskDto()
            {
                ProjectId = projectTask.ProjectId,
                Name = projectTask.Name,
                Description = projectTask.Description,
                Priority = projectTask.Priority,
                Status= projectTask.Status,
            };
        }
    }

}
