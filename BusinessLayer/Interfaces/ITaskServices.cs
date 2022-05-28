using BusinessLayer.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ITaskServices
    {
        Task<Task> GetTask(int taskId);
        Task<IEnumerable<Task>> GetAllTasks();
        Task<Task> AddTask(ProjectTask projectTask);
        Task<Task> DeleteTask(Task task);  
        Task<Task> UpdateTask(int taskId, ProjectTask projectTask);
        Project GetProject (int ProjectId);

    }
}
