using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Task.Models;

namespace Task.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        private static List<ModelTask> modelTasks = new List<ModelTask>();

        [HttpGet]
        public ActionResult<List<ModelTask>> SearchTask()
        {
            return Ok(modelTasks);
        }

        [HttpPost]
        public ActionResult<ModelTask> AddTask(ModelTask newTask)
        {
            if (newTask.Description.Length < 10)
            {
                return BadRequest("A descrição deve ter pelo menos 10 caracteres.");
            }

            newTask.Id = modelTasks.Count > 0 ? modelTasks[modelTasks.Count - 1].Id + 1 : 1;
            modelTasks.Add(newTask);
            return Ok(modelTasks);
        }


        [HttpDelete("{id}")]
        public ActionResult<ModelTask> DeleteTask(int id)
        {
            var task = modelTasks.FirstOrDefault(t => t.Id == id);
            if (task == null)
            {
                return NotFound();
            }

            modelTasks.Remove(task);
            return Ok(task);
        }


    }
}
