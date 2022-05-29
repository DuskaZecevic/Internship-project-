using DataAccessLayer.Model;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApiCommon.Enums;

namespace BusinessLayer.Interfaces
{
    public interface IProjectService
    {
        Task<ProjectDto> GetProject(int projectId);
        Task<IEnumerable<ProjectDto>> GetAllProjects();
        Task<ProjectDto> AddProject(ProjectDto project);
        Task<ProjectDto> UpdateProject(int projectId, ProjectDto project);
        Task<ProjectDto> UpdateProjectPatch(int projectId, JsonPatchDocument<ProjectDto> project);
        Task<ProjectDto> DeleteProject(int projectId);
        Task<IEnumerable<DataAccessLayer.Model.TaskDto>> FindAllTasks(int projectId);
        Task<IEnumerable<ProjectDto>> Search(string name, int priority, ProjectStatus projectStatus, string sort);
        Task<ProjectDto> GetProjectByName(string name);
        Task<ProjectDto> GetProjectByNameAndId(string name, int id);
        
        

    }
}
