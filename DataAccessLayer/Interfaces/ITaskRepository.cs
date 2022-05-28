
using DataAccessLayer.Model;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
     public interface ITaskRepository
    {
        Task<TaskDto> GetTask(int Id);
        Task<IEnumerable<Model.TaskDto>> GetAllTasks();
        Task<Model.TaskDto> AddTask(Model.TaskDto task);
        Task<Model.TaskDto> UpdateTask(Model.TaskDto task);
        Task<Model.TaskDto> DeleteTask(Model.TaskDto task);
        ProjectDto GetProject(int ProjectId);
    }
}
