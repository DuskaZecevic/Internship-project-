using BusinessLayer.Interfaces;
using DataAccessLayer.Model;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using BusinessLayer.Entities;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProjectController : ControllerBase
    {
        private readonly IProjectService _projectServices;
        public ProjectController(IProjectService projectServices)
        {
            _projectServices = projectServices;
        }
        [HttpGet("Get")]
        public async Task<ActionResult<IEnumerable<Project>>> GetAllProjectsAsync()
        {
            try
            {
                return Ok(await _projectServices.GetAllProjectsAsync());
            }
            catch (System.Exception)
            {

                return StatusCode(500, "An error has occurred");
            }
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Project>> GetProjectAsync(int id)
        {
            try
            {
                var result = await _projectServices.GetProjectAsync(id);
                if (result == null)
                {
                    return NotFound();
                }
                return result;
            }
            catch (System.Exception)
            {

                return StatusCode(500, "An error has occurred");
            }
        }
        [HttpPost("Create")]
        public async Task<ActionResult<Project>> CreateProjectAsync(Project project)
        {
            try
            {
                if (project == null)
                {
                    return BadRequest();
                }

                var createdProject = await _projectServices.AddProjectAsync(project);
                return createdProject;

            }
            catch (System.Exception)
            {
                return StatusCode(500, "An error has occurred");
            }
        }
        [HttpPut("Update/{id}")]
        public async Task<ActionResult<Project>> UpdateProjectAsync(int id, Project project)
        {
            try
            {
                var projectToUpdate = await _projectServices.GetProjectAsync(id);
                if (projectToUpdate == null)
                {
                    return NotFound($"Project with Id = {id} not found");
                }
                return await _projectServices.UpdateProject(id, project);
            }
            catch (System.Exception)
            {

                return StatusCode(500, "An error has occurred");
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<ActionResult<Project>> DeleteProjectAsync(int id)
        {
            try
            {
                var projectToDelete = await _projectServices.GetProjectAsync(id);
                if (projectToDelete == null)
                {
                    return NotFound("Project cannot be found");
                }
                var result =  await _projectServices.DeleteProjectAsync(id);

                
                return result;
            }
            catch (System.Exception)
            {

                return StatusCode(500, "An error has occurred");
            }
        }

        [HttpPatch("{id:int}")]
        public async Task<ActionResult<ProjectDto>> PatchAsync(int id, JsonPatchDocument<ProjectDto> patchEntity)
        {

            try
            {
                return Ok(await _projectServices.UpdateProjectPatch(id, patchEntity));
            }

            catch
            {
                return StatusCode(500, "An error has occurred");
            }


        }
    }
}
