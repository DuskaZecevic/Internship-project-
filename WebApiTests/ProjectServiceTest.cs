using BusinessLayer.Services;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace WebApiTests
{
    public class ProjectServiceTest
    {
        private readonly IEnumerable<ProjectDto> _projects;
        private readonly ProjectService _projectServiceTest;
        private readonly Mock<IProjectRepository> _projectRepositoryMock = new Mock<IProjectRepository>();
        public ProjectServiceTest()
        {
            _projects = new List<ProjectDto>()
            {
                new ProjectDto() { Id = 1, Name = "a", Status = WebApiCommon.Enums.ProjectStatus.NotStarted, StartDate =DateTime.Now, CompletionDate = DateTime.Now ,Priority = 2 },
                 new ProjectDto() { Id = 2, Name = "b", Status = WebApiCommon.Enums.ProjectStatus.Active, StartDate =DateTime.Now,CompletionDate = DateTime.Now, Priority = 3 },
                  new ProjectDto() { Id = 3, Name = "c", Status = WebApiCommon.Enums.ProjectStatus.Completed, StartDate =DateTime.Now,CompletionDate = DateTime.Now, Priority = 4 }
            };

            _projectServiceTest = new ProjectService(_projectRepositoryMock.Object);
        }
        [Fact]
        public async Task GetAllProjects_shouldReturnAllProjects_WhenTheyExist()
        {
            //Arange
            _projectRepositoryMock.Setup(x => x.GetAllProjects()).ReturnsAsync(_projects);
            //Act
            var project = await _projectServiceTest.GetAllProjectsAsync();
            //Assert
            Assert.Equal(3, project.Count());
        }
        [Fact]
        public async Task GetAllTasks_shouldReturnAllNull_WhenTheyDoNotExist()
        {
            //Arange
            _projectRepositoryMock.Setup(x => x.GetAllProjects()).ReturnsAsync(() => null);
            //Act
            var project = await _projectServiceTest.GetAllProjectsAsync();
            //Assert
            Assert.Null(project);
        }
        [Fact]
        public async Task GetAllTasks_ShouldThrowAnException()
        {
            //Arange
            _projectRepositoryMock.Setup(x => x.GetAllProjects()).ThrowsAsync(new System.Exception("Unit test exception"));
            //Act
            var result = await Assert.ThrowsAsync<System.Exception>(async () => await _projectServiceTest.GetAllProjectsAsync());
            //Assert
            Assert.True(result.Message == "Unit test exception");
            _projectRepositoryMock.Verify(x => x.GetAllProjects(), Times.Once);
        }
    }
}
