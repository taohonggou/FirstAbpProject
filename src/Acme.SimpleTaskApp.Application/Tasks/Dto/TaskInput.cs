using Abp.AutoMapper;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Acme.SimpleTaskApp.Tasks.Dto
{
    public class GetAllTasksInput
    {
        public TaskState? State { get; set; }
    }

    [AutoMapTo(typeof(Task))]
    public class CreateTaskInput
    {
        [Required]
        [MaxLength(Task.MaxTitleLength)]
        public string Title { get; set; }
        [MaxLength(Task.MaxDescriptionLength)]
        public string Description { get; set; }

        public Guid? AssignedPersonId { get; set; }
    }

    public class DeleteTaskInput
    {
        [Range(1,int.MaxValue)]
        public int Id { get; set; }
    }


    public class EditTaskInput
    {
        public int? Id { get; set; }
    }
}
