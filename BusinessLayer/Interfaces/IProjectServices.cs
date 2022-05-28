using BusinessLayer.Entities;
using ClassLibrary2.Enums;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Interfaces
{
    public interface IProjectServices
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
