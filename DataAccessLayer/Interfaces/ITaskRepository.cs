
using DataAccessLayer.Model;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
     public interface ITaskRepository
    {
        Task<TaskDto> GetTask(int Id);
        Task<TaskDto> AddTask();
        Task<TaskDto> UpdateTask();

        Task<TaskDto> DeleteTask(int Id);
    }
}
