using BusinessLayer.Entities;
using DataAccessLayer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ITaskService
    {
        Task<ProjectTask> GetTaskAsync(int taskId);
        Task<IEnumerable<ProjectTask>> GetAllTasksAsync();
        Task<ProjectTask> AddTaskAsync(ProjectTask projectTask);
        Task<ProjectTask> DeleteTaskAsync(int id);  
        Task<ProjectTask> UpdateTaskAsync(int taskId, Entities.ProjectTask projectTask);
        ProjectDto GetProject(int projectId);

    }
}
