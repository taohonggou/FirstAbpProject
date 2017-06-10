using Acme.SimpleTaskApp.Tasks;
using Acme.SimpleTaskApp.Tasks.Dto;
using Acme.SimpleTaskApp.Web.Models.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Acme.SimpleTaskApp.Persons;
using System.Linq;
using Abp.Application.Services.Dto;
using Acme.SimpleTaskApp.Web.Models.People;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            var peopleSelectListItem=await GeneratePeopleSelectListItem(string.Empty);

            return View(new CreateTaskViewModel(peopleSelectListItem));
        }

        public async Task<IActionResult> Edit(EditTaskInput input)
        {
            if (input == null || !input.Id.HasValue)
            {
                return RedirectToAction("Index");
            }

            var task =await  _taskAppService.Get(input.Id.Value);
            if(task==null)
            {
                return RedirectToAction("Index");
            }
            var peopleSelectListItem = await GeneratePeopleSelectListItem(task.AssignedPersonId.HasValue? task.AssignedPersonId.ToString():string.Empty);

            return View(new EditViewModel(peopleSelectListItem, task));
        }

        private async Task<List<SelectListItem>> GeneratePeopleSelectListItem(string selectedValue)
        {
            var peopleSelectListItem = (await _lookupAppService.GetPerpleComboboxItems()).Select(p => p.ToSelectListItem()).ToList();

            peopleSelectListItem.Add(new SelectListItem() { Value = string.Empty, Text = L("Unassigned")});

            var selectedItem= peopleSelectListItem.Where(o => o.Value == selectedValue).FirstOrDefault();
            if(selectedItem!=null)
            {
                selectedItem.Selected = true;
            }
            return peopleSelectListItem;
        }
    }
}