using BusinessLayer.Entities;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface ITaskService
    {
        Task<DataAccessLayer.Model.TaskDto> GetTask(int taskId);
        Task<IEnumerable<DataAccessLayer.Model.TaskDto>> GetAllTasks();
        Task<DataAccessLayer.Model.TaskDto> AddTask(ProjectTask projectTask);
        Task<DataAccessLayer.Model.TaskDto> DeleteTask(DataAccessLayer.Model.TaskDto task);  
        Task<DataAccessLayer.Model.TaskDto> UpdateTask(int taskId, ProjectTask projectTask);
        Project GetProject (int projectId);
        
    }
}
