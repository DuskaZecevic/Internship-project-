using WebApiCommon.Enums;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Interfaces
{
    public interface IProjectRepository
    {
        Task<ProjectDto> GetProject(int projectId); 
        Task<IEnumerable<ProjectDto>> GetAllProjects();
        Task<ProjectDto> AddProject (ProjectDto project);
        Task<ProjectDto> UpdateProject (ProjectDto project);
        Task <ProjectDto> DeleteProject (ProjectDto project);
        Task <ProjectDto> GetProjectByName(string name);
        Task<ProjectDto> GetProjectByNameAndId(string name, int id);
        Task<ProjectDto> UpdateProjectPatch(int projectId, JsonPatchDocument<ProjectDto> project);
        

    }
}
