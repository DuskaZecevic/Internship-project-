using BusinessLayer.Interfaces;
using WebApiCommon.Enums;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.JsonPatch;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Entities;

namespace BusinessLayer.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;
        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public async Task<Project> AddProjectAsync(Project project)
        {
            ProjectDto projectModel = GetMappedProjectDto(project);

            if (projectModel.StartDate != null && projectModel.CompletionDate == null)
            {
                projectModel.Status = ProjectStatus.Active;
            }
            else if (projectModel.StartDate != null && projectModel.CompletionDate != null)
            {
                projectModel.Status = ProjectStatus.Completed;
            }
            var result = await _projectRepository.AddProject(projectModel);

            return GetMappedProject(result);        
        }

        public async Task<Project> DeleteProjectAsync(int projectId)
        {
           var result = await _projectRepository.GetProject(projectId);
            await _projectRepository.DeleteProject(result);
            return GetMappedProject(result);
        }

        public async Task<IEnumerable<Project>> GetAllProjectsAsync()
        {
            var projects = new List<Project>();
            foreach (var projectDto in await _projectRepository.GetAllProjects())
            {
                projects.Add(GetMappedProject(projectDto));
            }
            return projects;
        }

        public async Task<Project> GetProjectAsync(int projectId)
        {
            return GetMappedProject(await _projectRepository.GetProject(projectId));
        }

        public async Task<Project> GetProjectByNameAsync(string name)
        {
            return GetMappedProject(await _projectRepository.GetProjectByName(name));
        }

        public async Task<Project> GetProjectByNameAndIdAsync(string name, int id)
        {
            return GetMappedProject(await _projectRepository.GetProjectByNameAndId(name, id)); 
        }

        public async Task<Project> UpdateProject(int projectId, Project project)
        {
            ProjectDto projectModel = GetMappedProjectDto(project);
            projectModel.Id = projectId;

            if (projectModel.StartDate != null && projectModel.CompletionDate == null)
            {
                projectModel.Status = ProjectStatus.Active;
            }
            else if (projectModel.StartDate != null && projectModel.CompletionDate != null)
            {
                projectModel.Status = ProjectStatus.Completed;
            }
            else
            {
                projectModel.Status = ProjectStatus.NotStarted;
            }
            return GetMappedProject(await _projectRepository.UpdateProject(projectModel));
        }

        public async Task<Project> UpdateProjectPatch(int projectId, JsonPatchDocument<ProjectDto> project)
        {
            var result = GetMappedProject(await _projectRepository.GetProject(projectId));
            if (result != null)
            {
                await _projectRepository.UpdateProjectPatch(projectId, project);
                return result;
            }
            return null;
        }

        #region private

        private Project GetMappedProject(ProjectDto projectDto)
        {
            return new Project()
            {
                Name = projectDto.Name,
                StartDate = projectDto.StartDate,
                CompletionDate = projectDto.CompletionDate,
                Priority = projectDto.Priority
            };
        }

        private ProjectDto GetMappedProjectDto(Project project)
        {
            return new ProjectDto()
            {
                Name = project.Name,
                StartDate = project.StartDate,
                CompletionDate = project.CompletionDate,
                Priority = project.Priority,
            };
        }
        #endregion
    }
}
