using BusinessLayer.Entities;
using BusinessLayer.Interfaces;
using DataAccessLayer.Model;
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
        private readonly ITaskServices _taskServices;
        public TasksController(ITaskServices taskServices)
        {
            _taskServices = taskServices;
        }
        [HttpGet("Get")]
        public async Task<ActionResult> Get()
        {
            try
            {
                return Ok();
                    
            }
            catch (System.Exception ex)
            {

                return StatusCode(500, $"An error has occurred$: {ex.Message}");
            }
            
        }

        [HttpPost("Create")]
        public IActionResult CreateTask([FromBody]  ProjectTask projectTask)
        {
            

            return Ok();
        }

        [HttpPut("Update/{Id}")]
        public IActionResult Update([FromBody] TaskDto dto)
        {
            try
            {
                
            }
            catch (System.Exception)
            {

                return StatusCode(500, "An error has occurred");

            }
            return Ok();

        }

        [HttpDelete("DeleteTasks/{Id}")]
        public IActionResult TaskDto (int Id)
        {
            return Ok();
        }

        
            
    }
}
