﻿using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using Abp.Timing;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Acme.SimpleTaskApp.Persons;

namespace Acme.SimpleTaskApp.Tasks
{
    [Table("AppTasks")]
    public class Task : Entity, IHasCreationTime
    {
        public const int MaxTitleLength = 100;
        public const int MaxDescriptionLength = 64 * 1024;//64KB

        [Required]
        [MaxLength(MaxTitleLength)]
        public string Title { get; set; }
        [MaxLength(MaxDescriptionLength)]
        public string Description { get; set; }

        public DateTime CreationTime { get; set; }

        public TaskState State { get; set; }

        [ForeignKey(nameof(AssignedPersonId))]
        public Person AssignedPerson { get; set; }

        public Guid? AssignedPersonId { get; set; }

        public Task()
        {
            CreationTime = Clock.Now;
            State = TaskState.Open;
        }

        public Task(string title,string description=null):this()
        {
            Title = title;
            Description = description;
        }

        public Task(string title, string description = null,Guid? assignedPersonId=null) : this(title, description)
        {
            AssignedPersonId = assignedPersonId;
        }
    }

    public enum TaskState
    {
        Open=0,
        Completed=1
    }
}
