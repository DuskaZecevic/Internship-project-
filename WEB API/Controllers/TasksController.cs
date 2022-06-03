using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using DataAccessLayer.Model;
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
        public async Task<ActionResult> GetAllTasksAsync()
        {
            try
            {
                return Ok(await _taskServices.GetAllTasksAsync());
                    
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, $"An error has occurred$: {ex.Message}");
            }
            
        }
        [HttpGet("Get/{id:int}")]
        public async Task<ActionResult<ProjectTask>> GetTaskAsync(int id)
        {
            try
            {
                var resultat = await _taskServices.GetTaskAsync(id);
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
        public async Task<ActionResult<ProjectTask>> CreateTaskAsync(ProjectTask projectTask)
        {
            try
            {
                

                if (projectTask == null)
                {
                    return BadRequest();
                }
                //var ProjectOfTask = _taskServices.GetProject(projectTask.ProjectId);
                //if (ProjectOfTask == null)
                //{
                //    return NotFound($"Project with Id = {projectTask.ProjectId} not found");
                //}
                var createdTask = await  _taskServices.AddTaskAsync(projectTask);
                //if (createdTask == null)
                //{
                 //   ModelState.AddModelError("TaskStatus", "Task status error. If project is done status must be completed. If project is not started status cannot be completed");
                 //   return BadRequest(ModelState);
                //}
                return Created("TaskCreated", createdTask);
                
                
            }

            catch(System.Exception ex)
            {
                return StatusCode(500, $"An error has occurred$: {ex.Message}");
            }
        }

        [HttpPut("Update/{Id:int}")]
        public async Task<ActionResult<ProjectTask>> UpdateAsync(int Id, BusinessLayer.Entities.ProjectTask projectTask)
        {
            try
            {
                var ProjectOfTask = _taskServices.GetProject(projectTask.ProjectId);

                var taskToUpdate = _taskServices.GetTaskAsync(Id).Result;

                if (ProjectOfTask == null)
                {
                    return NotFound($"Project with Id = {projectTask.ProjectId} not found");
                }
                else if (taskToUpdate == null)
                {
                    return NotFound($"Task with Id = {Id} not found");
                }

                var UpdatedTask = await _taskServices.UpdateTaskAsync(Id, projectTask);

                if (UpdatedTask == null)
                {
                    ModelState.AddModelError("TaskStatus", "Task status error. If project is done status must be 'done'. If project is not started status must be 'toDo'");
                    return BadRequest(ModelState);
                }

                return UpdatedTask;
                
            }
            catch (System.Exception)
            {

                return StatusCode(500, "An error has occurred");

            }
            

        }

        [HttpDelete("DeleteTasks/{Id:int}")]
        public async Task<ActionResult<ProjectTask>> DeleteTaskAsync (int Id)
        {
            try
            {
                var TaskToDelete = await _taskServices.GetTaskAsync(Id);
                if (TaskToDelete == null)
                {
                  return StatusCode(404, "Not found");
                }
                var DeleteThisTask = await _taskServices.DeleteTaskAsync(Id);
                return Ok(DeleteThisTask);
            }
            catch (System.Exception)
            {

                return StatusCode(500, "An error has occurred");
            }
        }
        /* [HttpGet("{id:int}/Tasks")]
        public async Task<ActionResult<IEnumerable<DataAccessLayer.Model.TaskDto>>> FindAllTasksAsync(int id)
        {
            try
            {
                var result = await _taskServices.FindAllTasksAsync(id);


                if (result.Any())
                {
                    return Ok(result);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (System.Exception)
            {

                return StatusCode(500, "An error has occurred");
            }
        }*/



    }
}
