using Acme.SimpleTaskApp.Tasks;
using Acme.SimpleTaskApp.Tasks.Dto;
using Acme.SimpleTaskApp.Web.Models.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Acme.SimpleTaskApp.Persons;
using System.Linq;
using Abp.Application.Services.Dto;
using Acme.SimpleTaskApp.Web.Models.People;

namespace Acme.SimpleTaskApp.Web.Controllers
{
    public class TasksController : SimpleTaskAppControllerBase
    {
        private readonly ITaskAppService _taskAppService;
        private readonly ILookupAppService _lookupAppService;

        public TasksController(ITaskAppService taskAppService, ILookupAppService lookupAppService)
        {
            _taskAppService = taskAppService;
            _lookupAppService = lookupAppService;
        }

        public async Task<IActionResult> Index(GetAllTasksInput input)
        {
            var output = await _taskAppService.GetAll(input);
            var model = new IndexViewModel(output)
            {
                SelectedTaskState = input.State
            };
            return View(model);
        }

        public async Task<IActionResult> Create()
        {
            var peopleSelectListItem = (await _lookupAppService.GetPerpleComboboxItems()).Select(p => p.ToSelectListItem()).ToList();

            peopleSelectListItem.Add(new Microsoft.AspNetCore.Mvc.Rendering.SelectListItem() { Value = string.Empty, Text = L("Unassigned"), Selected = true });

            return View(new CreateTaskViewModel(peopleSelectListItem));
        }
    }
}