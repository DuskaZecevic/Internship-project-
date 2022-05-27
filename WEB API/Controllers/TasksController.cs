using DataAccessLayer.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace WEB_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskDbContext _dbContext;
        public TasksController(TaskDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        [HttpGet("Get tasks")]
        public IActionResult Get()
        {
            try
            {
                var tasks = _dbContext.Tasks.ToList();
                if (tasks.Count == 0)
                {
                    return StatusCode(404, "No user found");
                }
                return Ok(tasks);
                    
            }
            catch (System.Exception)
            {

                return StatusCode(500, "An error has occurred");
            }
            
        }

        [HttpPost("CreateTasks")]
        public IActionResult CreateTask([FromBody] TaskDto dto)
        {
            

            return Ok();
        }

        [HttpPut("UpdateTasks")]
        public IActionResult Update([FromBody] TaskDto dto)
        {
            try
            {
                
            }
            catch (System.Exception)
            {

                return StatusCode(500, "An error has occurred");

            }
            var tasks = _dbContext.Tasks.ToList();
            return Ok(tasks);

        }

        [HttpDelete("DeleteTasks/{Id}")]
        public IActionResult Delete(int Id)
        {
            return Ok();
        }

        
            
    }
}
