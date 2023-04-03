using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations.Schema;
using TaskReturn.DataBase;
using TaskReturn.Model;
using TaskReturn.Request;

namespace TaskReturn.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TasksController : ControllerBase
    {
        private readonly TaskDBContext mTaskDBContext;

        public TasksController(TaskDBContext taskDBContext)
        {
            mTaskDBContext = taskDBContext;
        }
        
        [HttpPost]
        public async Task<string>CreateTask([FromBody]TaskRequest taskRequest)
        {
            Tasks tasks = new Tasks()
            {
                ID = taskRequest.ID,
                Name = taskRequest.Name,
                CreatedDate = taskRequest.CreatedDate,
                ModifiedDate = taskRequest.ModifiedDate,
                Status = taskRequest.Status = 0,
                TimeTaken = taskRequest.TimeTaken = null,
            };
            mTaskDBContext.Task.Add(tasks);
            await mTaskDBContext.SaveChangesAsync();
            return $"Created-{tasks.ID}";
        }

        [HttpPut]
        public async Task<string> UpdateTask(int id)
        {
            Tasks tasks = mTaskDBContext.Task.Where(x => x.ID == id && x.Status==0).FirstOrDefault();
            {
                tasks.Name = tasks.Name;
                tasks.CreatedDate= tasks.CreatedDate;  
                tasks.ModifiedDate = DateTime.UtcNow;
                tasks.TimeTaken = Convert.ToString(tasks.ModifiedDate - tasks.CreatedDate);
                tasks.Status = 1;
            }
            mTaskDBContext.Task.Update(tasks);
            await mTaskDBContext.SaveChangesAsync();
            return $"Updated-{tasks.ID}";
        }
    }
}
