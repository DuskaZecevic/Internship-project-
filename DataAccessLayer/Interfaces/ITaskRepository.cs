﻿using DataAccessLayer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface ITaskRepository
    {
        Task<TaskDto> GetTaskAsync(int Id);
        Task<IEnumerable<Model.TaskDto>> GetAllTasks();
        Task<Model.TaskDto> AddTaskAsync(Model.TaskDto task);
        Task<Model.TaskDto> UpdateTaskAsync(Model.TaskDto task);
        Task<Model.TaskDto> DeleteTaskAsync(Model.TaskDto task);
        
    }
}
