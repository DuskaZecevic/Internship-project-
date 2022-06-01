﻿using BusinessLayer.Entities;
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
                var result = await _taskServices.GetAllTasksAsync();
                return Ok(result);
                    
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, $"An error has occurred$: {ex.Message}");
            }
            
        }
        [HttpGet("Get/{id:int}")]
        public async Task<ActionResult<DataAccessLayer.Model.TaskDto>> GetTaskAsync(int id)
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
        public async Task<ActionResult<TaskDto>> CreateTaskAsync(TaskDto projectTask)
        {
            try
            {
                

                if (projectTask == null)
                {
                    return BadRequest();
                }
                var createdTask = await  _taskServices.AddTaskAsync(projectTask);
                return createdTask;
               
            }

            catch(System.Exception ex)
            {
                return StatusCode(500, $"An error has occurred$: {ex.Message}");
            }
        }

        [HttpPut("Update/{Id:int}")]
        public async Task<ActionResult<DataAccessLayer.Model.TaskDto>> UpdateAsync(int Id, ProjectTask projectTask)
        {
            try
            {
                
                var taskToUpdate = _taskServices.GetTaskAsync(Id).Result;
                if (taskToUpdate == null)
                {
                    return StatusCode(404, "Not found");
                }
                var UpdateTask = await _taskServices.UpdateTaskAsync(Id, projectTask);
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

        [HttpDelete("DeleteTasks/{Id:int}")]
        public async Task<ActionResult<TaskDto>> DeleteTaskAsync (int Id)
        {
            try
            {
                var TaskToDelete = await _taskServices.GetTaskAsync(Id);
                if (TaskToDelete == null)
                {
                  return StatusCode(404, "Not found");
                }
                var DeleteThisTask = await _taskServices.DeleteTaskAsync(TaskToDelete);
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
