using DataAccessLayer.Model;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCommon.Enums;

namespace BusinessLayer.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDto> GetProjectAsync(int projectId);
        Task<IEnumerable<ProjectDto>> GetAllProjectsAsync();
        Task<ProjectDto> AddProjectAsync(ProjectDto project);
        Task<ProjectDto> UpdateProject(int projectId, ProjectDto project);
        Task<ProjectDto> UpdateProjectPatch(int projectId, JsonPatchDocument<ProjectDto> project);
        Task<ProjectDto> DeleteProjectAsync(int projectId);
        Task<IEnumerable<ProjectDto>> Search(string name, int priority, ProjectStatus projectStatus, string sort);
        Task<ProjectDto> GetProjectByNameAsync(string name);
        Task<ProjectDto> GetProjectByNameAndIdAsync(string name, int id);



    }
}
