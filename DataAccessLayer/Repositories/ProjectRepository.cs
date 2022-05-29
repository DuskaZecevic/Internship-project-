using WebApiCommon.Enums;
using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class ProjectRepository : IProjectRepository
    {
        public readonly TaskDbContext _taskDbContext;
        public ProjectRepository(TaskDbContext taskDbContext)
        {
            _taskDbContext = taskDbContext;
        }

        public async Task<ProjectDto> AddProject(ProjectDto project)
        {
            await _taskDbContext.Projects.AddAsync(project);
            await _taskDbContext.SaveChangesAsync();
            return project;
        }

        public async Task<ProjectDto> DeleteProject(ProjectDto project)
        {
           _taskDbContext.Projects.Remove(project);
            await _taskDbContext.SaveChangesAsync();
            return project;
        }

       /* public Task<IEnumerable<TaskDto>> FindAllTasks(int projectId)
        {
            throw new NotImplementedException(); //zavrsi
        }*/

        public async Task<IEnumerable<ProjectDto>> GetAllProjects()
        {
            return await _taskDbContext.Projects.ToListAsync();
        }

        public async Task<ProjectDto> GetProject(int projectId)
        {
            return await _taskDbContext.Projects.FirstOrDefaultAsync(t => t.Id == projectId);
        }

        public async Task<ProjectDto> GetProjectByName(string name)
        {
            return await _taskDbContext.Projects.FirstOrDefaultAsync(t => t.Name == name);
        }

        public async Task<ProjectDto> GetProjectByNameAndId(string name, int id)
        {
            return await _taskDbContext.Projects.FirstOrDefaultAsync(t => t.Name == name && t.Id != id);
        }

        public Task<IEnumerable<ProjectDto>> Search(int projectId, int priority, ProjectStatus projectStatus, string sort)
        {
            throw new NotImplementedException(); //zavrsi 
        }

        public async Task<ProjectDto> UpdateProject(ProjectDto project)
        {
            var result = await _taskDbContext.Projects.FirstOrDefaultAsync(t => t.Id == project.Id);

            result.Name = project.Name;
            result.StartDate = project.StartDate;
            result.CompletionDate = project.CompletionDate;
            result.Priority = project.Priority;
            result.Status = project.Status;

            await _taskDbContext.SaveChangesAsync();
            return result;
        }

        public async Task<ProjectDto> UpdateProjectPatch(int projectId, JsonPatchDocument<ProjectDto> project)
        {
            var result = await _taskDbContext.Projects.FirstOrDefaultAsync(t => t.Id == projectId);
            project.ApplyTo(result);
            await _taskDbContext.SaveChangesAsync();
            return result;
        }
    }
}
