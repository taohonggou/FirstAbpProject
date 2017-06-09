using Acme.SimpleTaskApp.Tasks;
using Acme.SimpleTaskApp.Tasks.Dto;
using Acme.SimpleTaskApp.Web.Models.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Acme.SimpleTaskApp.Web.Controllers
{
    public class TasksController : SimpleTaskAppControllerBase
    {
        private readonly ITaskAppService _taskAppService;

        public TasksController(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }

        public IActionResult Index(GetAllTasksInput input)
        {
            var output = _taskAppService.GetAll(input);
            var model = new IndexViewModel(output)
            {
                SelectedTaskState=input.State
            };
            return View(model);
        }
    }
}