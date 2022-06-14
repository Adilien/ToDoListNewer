using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ToDoList.Server.Data;
using ToDoList.Shared;

namespace ToDoList.Server.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ToDoListController : ControllerBase
    {
        private readonly DataContext _dataContext;
        public ToDoListController (DataContext context)
        {
            _dataContext = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetAllUserTasks()
        {
            var userTasks = await _dataContext.UserTasks.ToListAsync();
            return Ok(userTasks);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<IEnumerable<UserTask>>> GetSingleUserTask(int id)
        {
            var userTask = await _dataContext.UserTasks.FirstOrDefaultAsync(x => x.Id == id);

            if (userTask == null)
                return NotFound("This task does not exist. Sorry!");

            return Ok(userTask);
        }

        [HttpPost]
        [Route("create")]
        public async Task<ActionResult<UserTask>> CreateUserTask(UserTask userTask)
        {
            _dataContext.UserTasks.Add(userTask);
            await _dataContext.SaveChangesAsync();

            return Ok(await GetDbUserTasks());
        }

        [HttpPut]
        [Route("update/{id}")]
        public async Task<ActionResult<UserTask>> UpdateUserTask(UserTask userTask, int id)
        {
            var dbUserTask = await _dataContext.UserTasks.FirstOrDefaultAsync(x => x.Id == id);

            if (dbUserTask == null)
                return NotFound("Sorry, no task found!");

            dbUserTask.Text = userTask.Text;

            await _dataContext.SaveChangesAsync();

            return Ok(await GetDbUserTasks());
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult<UserTask>> DeleteUserTask(int id)
        {
            var dbUserTask = await _dataContext.UserTasks.FirstOrDefaultAsync(x => x.Id == id);

            if (dbUserTask == null)
                return NotFound("Sorry, no task found!");

            _dataContext.Remove(dbUserTask);
            await _dataContext.SaveChangesAsync();

            return Ok(await GetDbUserTasks());
        }

        private async Task<List<UserTask>> GetDbUserTasks()
        {
            return await _dataContext.UserTasks.ToListAsync();
        }
    }
}