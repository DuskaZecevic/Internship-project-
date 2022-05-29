
using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly ITaskService _taskServices;
        public TasksController(ITaskService taskServices)
        {
            _taskServices = taskServices;
        }
        [HttpGet("Get")]
        public async Task<ActionResult> GetAllTasks()
        {
            try
            {
                var result = await _taskServices.GetAllTasks();
                return Ok(result);
                    
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, $"An error has occurred$: {ex.Message}");
            }
            
        }
        [HttpGet("Get/{id:int}")]
        public async Task<ActionResult<DataAccessLayer.Model.TaskDto>> GetTask(int id)
        {
            try
            {
                var resultat = await _taskServices.GetTask(id);
                if(resultat == null)
                {
                    return StatusCode(404, "Not found");
                }
                return Ok(resultat);

            }
            catch (System.Exception ex)
            {

                return StatusCode(500, $"An error has occurred$: {ex.Message}");
            }

        }

        [HttpPost("Create")]
        public async Task<ActionResult<DataAccessLayer.Model.TaskDto>> CreateTask(ProjectTask projectTask)
        {
            try
            {
                

                if (projectTask == null)
                {
                    return BadRequest();
                }
                var ProjectOfTask = _taskServices.GetProject(projectTask.ProjectId);
                if (ProjectOfTask == null)
                {
                    return StatusCode(404, "Not found");
                }
                var createdTask = await _taskServices.AddTask(projectTask);
                if (createdTask == null)
                {
                    return BadRequest();
                }
                return CreatedAtAction(nameof(GetTask), new { id = createdTask.Id }, createdTask);
            }
            catch(System.Exception ex)
            {
                return StatusCode(500, $"An error has occurred$: {ex.Message}");
            }
        }

        [HttpPut("Update/{id:int}")]
        public async Task<ActionResult<DataAccessLayer.Model.TaskDto>> Update(int id, ProjectTask projectTask)
        {
            try
            {
                var ProjectOfTask = _taskServices.GetProject(projectTask.ProjectId);
                var taskToUpdate = _taskServices.GetTask(id).Result;
                if(ProjectOfTask == null)
                {
                    return StatusCode(404, "Not found");
                }
                else if (taskToUpdate == null)
                {
                    return StatusCode(404, "Not found");
                }
                var UpdateTask = await _taskServices.UpdateTask(id, projectTask);
                if(UpdateTask == null)
                {
                    return BadRequest();
                }
                return Ok( UpdateTask);
            }
            catch (System.Exception)
            {

                return StatusCode(500, "An error has occurred");

            }
            

        }

        [HttpDelete("DeleteTasks/{id:int}")]
        public async Task<ActionResult<DataAccessLayer.Model.TaskDto>> DeleteTask (int Id)
        {
            try
            {
                var TaskToDelete = await _taskServices.GetTask(Id);
                if (TaskToDelete == null)
                {
                  return StatusCode(404, "Not found");
                }
                var DeleteThisTask = await _taskServices.DeleteTask(TaskToDelete);
                return Ok(DeleteThisTask);
            }
            catch (System.Exception)
            {

                return StatusCode(500, "An error has occurred");
            }
        }

        
          
    }
}
