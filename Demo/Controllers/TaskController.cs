using Demo.Models;
using Demo.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TaskController : ControllerBase
    {
        private readonly ITaskServices _taskServices;

        public TaskController(ITaskServices taskServices)
        {
            _taskServices = taskServices;   
        }
        [HttpGet]
        public IEnumerable<TasksModel> GetAll()
        {
            return _taskServices.GetAll().AsEnumerable();  
        }
         
        [HttpPost]
        public TasksModel Create(TasksModel tasksModel)
        {
            var rs = new TasksModel
            {
                Id = Guid.NewGuid(),
                Title = tasksModel.Title,
                IsCompleted = tasksModel.IsCompleted,
            };
            return _taskServices.Add(rs);
        }
        [HttpPut]
        public IActionResult Edit(Guid id, TasksModel tasksModel)
        {
            var rs = _taskServices.GetOne(id);
            if (rs == null) return NotFound();
            rs.Title = tasksModel.Title;
            rs.IsCompleted = tasksModel.IsCompleted;
            return new JsonResult(_taskServices.Update(rs));
        }
        [HttpDelete]
        public IActionResult Delete(Guid id, TasksModel tasksModel)
        {
            var rs = _taskServices.GetOne(id);
            if(rs == null) return NotFound();   
            _taskServices.Delete(id);
            return Ok();
        }

        [HttpPost]
        [Route("multiple")]
        public List<TasksModel> AddMul(List<TasksModel> models)
        {
            var rs = new List<TasksModel>();        
            foreach (var model in models)
            {
                rs.Add(new TasksModel
                {
                    Id = Guid.NewGuid(),
                    Title = model.Title,    
                    IsCompleted = model.IsCompleted 
                });
            }
            return _taskServices.Add(models);
        }
       
    }
}
