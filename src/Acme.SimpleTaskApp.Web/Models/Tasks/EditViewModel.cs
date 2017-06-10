using Acme.SimpleTaskApp.Tasks.Dto;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Web.Models.Tasks
{
    public class EditViewModel
    {
        public List<SelectListItem> People { get; set; }

        public TaskDto Task { get; set; }

        public EditViewModel(List<SelectListItem> people, TaskDto task)
        {
            People = people;
            Task = task;
        }
    }
}
