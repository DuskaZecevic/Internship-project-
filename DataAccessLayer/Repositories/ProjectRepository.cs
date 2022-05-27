using DataAccessLayer.Interfaces;
using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.Text;
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
        public Task<ProjectDto> AddProject(ProjectDto project)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDto> DeleteProject(int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProjectDto>> GetAllProjects()
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDto> GetProject(int projectId)
        {
            throw new NotImplementedException();
        }

        public Task<ProjectDto> UpdateProject(ProjectDto project)
        {
            throw new NotImplementedException();
        }
    }
}
