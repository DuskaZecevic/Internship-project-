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
        Task<Task> AddTask(ProjectTask projectTask);
        Task<Task> DeleteTask(int taskId);  
        Task<Task> UpdateTask(int Id, ProjectTask projectTask);

    }
}
