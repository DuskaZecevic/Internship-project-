using BusinessLayer.Interfaces;
using WebApiCommon.Enums;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.JsonPatch;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BusinessLayer.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<ProjectDto> AddProjectAsync(ProjectDto project)
        {
            ProjectDto projectModel = new ProjectDto
            {
                Name = project.Name,
                StartDate = project.StartDate,
                CompletionDate = project.CompletionDate,
                Priority = project.Priority,
                Status = ProjectStatus.NotStarted
            };
            if (project.StartDate != null && project.CompletionDate == null)
            {
                projectModel.Status = ProjectStatus.Active;
            }
            else if (project.StartDate != null && project.CompletionDate != null)
            {
                projectModel.Status = ProjectStatus.Completed;
            }
            var result = await _projectRepository.AddProject(projectModel);
            return result; 
        }

        public async Task<ProjectDto> DeleteProjectAsync(int projectId)
        {
           var result = await _projectRepository.GetProject(projectId);
            await _projectRepository.DeleteProject(result);
            return result;
        }

        public async Task<IEnumerable<ProjectDto>> GetAllProjectsAsync()
        {
            var projects = await _projectRepository.GetAllProjects();
            return projects;
        }

        public async Task<ProjectDto> GetProjectAsync(int projectId)
        {
            return await _projectRepository.GetProject(projectId);
        }

        public async Task<ProjectDto> GetProjectByNameAsync(string name)
        {
            var result = await _projectRepository.GetProjectByName(name);
            return result;
        }

        public async Task<ProjectDto> GetProjectByNameAndIdAsync(string name, int id)
        {
            var result = await _projectRepository.GetProjectByNameAndId(name, id);  
            return result;
        }

        public Task<IEnumerable<ProjectDto>> Search(string name, int priority, ProjectStatus projectStatus, string sort)
        {
            throw new NotImplementedException(); //zavrsi
        }

        public async Task<ProjectDto> UpdateProject(int projectId, ProjectDto project)
        {
            ProjectDto projectModel = new ProjectDto
            {
                Id = projectId,
                Name = project.Name,
                StartDate = project.StartDate,
                CompletionDate = project.CompletionDate,
                Priority = project.Priority,
            };
            if (project.StartDate != null && project.CompletionDate == null)
            {
                projectModel.Status = ProjectStatus.Active;
            }
            else if (project.StartDate != null && project.CompletionDate != null)
            {
                projectModel.Status = ProjectStatus.Completed;
            }
            else
            {
                projectModel.Status = ProjectStatus.NotStarted;
            }
            var result = await _projectRepository.UpdateProject(projectModel);
            return result;
        }

        public async Task<ProjectDto> UpdateProjectPatch(int projectId, JsonPatchDocument<ProjectDto> project)
        {
            var result = await _projectRepository.GetProject(projectId);
            if (result != null)
            {
                await _projectRepository.UpdateProjectPatch(projectId, project);
                return result;
            }
            return null;
        }
    }
}
