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
    public class TaskService : ITaskService
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
                Project = project

            };
            var result = await _taskRepository.AddTask(taskModel);
            return result;

        }

        public async Task<DataAccessLayer.Model.TaskDto> DeleteTask(DataAccessLayer.Model.TaskDto taskDto)
        {
            await _taskRepository.DeleteTask(taskDto);
            return taskDto;
        }

        public async Task<IEnumerable<DataAccessLayer.Model.TaskDto>> GetAllTasks()
        {
            return await _taskRepository.GetAllTasks();
        }


        public async Task<DataAccessLayer.Model.TaskDto> GetTask(int taskId)
        {
            return await _taskRepository.GetTask(taskId);
        }

        public async Task<DataAccessLayer.Model.TaskDto> UpdateTask(int taskId, ProjectTask projectTask)
        {
            var project = _taskRepository.GetProject(projectTask.ProjectId);
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
            var result = await _taskRepository.UpdateTask(projectModel);
            return result;
        }

        public Project GetProject(int projectId)
        {
            throw new NotImplementedException();
        }

    }
}
