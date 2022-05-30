using BusinessLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Moq;
using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Task = System.Threading.Tasks.Task;
using Xunit;

namespace WebApiTests
{
    public class TaskServiceTest
    {
        private readonly IEnumerable<TaskDto> _tasks;
        private readonly TaskService _taskServiceTest;
        private readonly Mock<ITaskRepository> _taskRepositoryMock = new Mock<ITaskRepository>();
        public TaskServiceTest()
        {
            _tasks = new List<TaskDto>()
            {
                new TaskDto() { ProjectId = 1, Name = "a", Status = WebApiCommon.Enums.TaskStatus.InProgress, Description ="a", Priority = 2 },
                 new TaskDto() { ProjectId = 2, Name = "b", Status = WebApiCommon.Enums.TaskStatus.Done, Description ="b", Priority = 3 },
                  new TaskDto() { ProjectId = 3, Name = "c", Status = WebApiCommon.Enums.TaskStatus.ToDo, Description ="c", Priority = 4 }
            };

            _taskServiceTest = new TaskService(_taskRepositoryMock.Object);
        }
        [Fact]
        public async Task GetAllTasks_shouldReturnAllTasks_WhenTheyExist()
        {
            //Arange
            _taskRepositoryMock.Setup(x => x.GetAllTasks()).ReturnsAsync(_tasks);
            //Act
            var task = await _taskServiceTest.GetAllTasksAsync();
            //Assert
            Assert.AreEqual(3, task.Count());
        }
        [Fact]
        public async Task GetAllTasks_shouldReturnAllNull_WhenTheyDoNotExist()
        {
            //Arange
            _taskRepositoryMock.Setup(x => x.GetAllTasks()).ReturnsAsync(()=>null);
            //Act
            var task = await _taskServiceTest.GetAllTasksAsync();
            //Assert
            Assert.Null(task);
        }

    }
}
