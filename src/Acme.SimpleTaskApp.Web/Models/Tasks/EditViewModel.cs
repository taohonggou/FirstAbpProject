using Acme.SimpleTaskApp.Tasks;
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

        public List<SelectListItem> State
        {
            get
            {
                var list= new List<SelectListItem>();
                list.AddRange(
                    Enum.GetValues(typeof(TaskState))
                    .Cast<TaskState>()
                    .Select(o=> new SelectListItem
                    {
                        Text=o.ToString(),
                        Value=((int)o).ToString(),
                        Selected=o==Task.State
                    })
                    );
                return list;
            }
        }



        public EditViewModel(List<SelectListItem> people, TaskDto task)
        {
            People = people;
            Task = task;
        }
    }
}
