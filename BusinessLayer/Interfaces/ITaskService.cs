using BusinessLayer.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ITaskService
    {
        Task<DataAccessLayer.Model.TaskDto> GetTaskAsync(int taskId);
        Task<IEnumerable<DataAccessLayer.Model.TaskDto>> GetAllTasksAsync();
        Task<DataAccessLayer.Model.TaskDto> AddTaskAsync(ProjectTask projectTask);
        Task<DataAccessLayer.Model.TaskDto> DeleteTaskAsync(DataAccessLayer.Model.TaskDto task);  
        Task<DataAccessLayer.Model.TaskDto> UpdateTaskAsync(int taskId, ProjectTask projectTask);
        Task<IEnumerable<DataAccessLayer.Model.TaskDto>> FindAllTasksAsync(int projectId);
        
        
    }
}
