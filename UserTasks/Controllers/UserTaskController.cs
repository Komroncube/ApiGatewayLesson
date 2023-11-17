using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UserTasks.Models;

namespace UserTasks.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserTaskController : ControllerBase
    {
        private readonly ToDoAppContext dbContext;

        public UserTaskController(ToDoAppContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public async ValueTask<IActionResult> GetTasks()
        {
            var tasks = await dbContext.Usertasks.ToListAsync();
            return Ok(tasks);
        }
        [HttpPatch]
        public async ValueTask<IActionResult> UpdateTask(int id, UserTaskDto taskDto)
        {
            try
            {
                var task = await dbContext.Usertasks.FirstOrDefaultAsync(x => x.Id == id);
                if (task is null)
                {
                    return BadRequest(taskDto);
                }
                task.Tasktitle = taskDto.TaskTitle;
                task.Taskdescription = taskDto.TaskDescription;
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
        [HttpDelete]
        public async ValueTask<IActionResult> DeleteTask(int id)
        {
            try
            {
                var task = await dbContext.Usertasks.FirstOrDefaultAsync(x => x.Id == id);
                dbContext.Remove(task);
                await dbContext.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
