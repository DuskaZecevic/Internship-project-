using DataAccessLayer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskDto> GetTaskAsync(int Id);
        Task<IEnumerable<TaskDto>> GetAllTasks();
        Task<TaskDto> AddTaskAsync(TaskDto task);
        Task<TaskDto> UpdateTaskAsync(TaskDto task);
        Task<TaskDto> DeleteTaskAsync(TaskDto task);
        ProjectDto GetProject(int projectId);

    }
}
