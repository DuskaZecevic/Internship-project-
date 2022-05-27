using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class TaskRepository : ITaskRepository
    {
        private readonly TaskDbContext _dbContext;
        public TaskRepository(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<TaskDto> AddTask()
        {
            throw new NotImplementedException();
        }

        public Task<TaskDto> DeleteTask(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskDto> GetTask(int Id)
        {
            throw new NotImplementedException();
        }

        public Task<TaskDto> UpdateTask()
        {
            throw new NotImplementedException();
        }
    }
}
