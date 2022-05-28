using ClassLibrary2.Enums;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
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
        Task<IEnumerable<ProjectDto>> Search(int projectId, int priority, ProjectStatus projectStatus, string sort);
        Task<ProjectDto> UpdateProjectPatch(int projectId, JsonPatchDocument<ProjectDto> project);
        Task<IEnumerable<Model.TaskDto>> FindAllTasks(int projectId);

    }
}
