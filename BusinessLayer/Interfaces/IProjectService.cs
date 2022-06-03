using BusinessLayer.Entities;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IProjectService
    {
        Task<Project> GetProjectAsync(int projectId);
        Task<IEnumerable<Project>> GetAllProjectsAsync();
        Task<Project> AddProjectAsync(Project project);
        Task<Project> UpdateProject(int projectId, Project project);
        Task<Project> UpdateProjectPatch(int projectId, JsonPatchDocument<ProjectDto> project);
        Task<Project> DeleteProjectAsync(int projectId);
        Task<Project> GetProjectByNameAsync(string name);
        Task<Project> GetProjectByNameAndIdAsync(string name, int id);



    }
}
