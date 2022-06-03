using BusinessLayer.Entities;
using DataAccessLayer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ITaskService
    {
        Task<DataAccessLayer.Model.TaskDto> GetTaskAsync(int taskId);
        Task<IEnumerable<DataAccessLayer.Model.TaskDto>> GetAllTasksAsync();
        Task<DataAccessLayer.Model.TaskDto> AddTaskAsync(TaskDto projectTask);
        Task<DataAccessLayer.Model.TaskDto> DeleteTaskAsync(DataAccessLayer.Model.TaskDto task);  
        Task<DataAccessLayer.Model.TaskDto> UpdateTaskAsync(int taskId, ProjectTask projectTask);
        ProjectDto GetProject(int projectId);

    }
}
