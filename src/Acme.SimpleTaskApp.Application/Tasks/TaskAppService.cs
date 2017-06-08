using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Acme.SimpleTaskApp.Tasks.Dto;
using Abp.Domain.Repositories;
using Abp.Collections.Extensions;
using System.Linq;

namespace Acme.SimpleTaskApp.Tasks
{
    public class TaskAppService : SimpleTaskAppAppServiceBase, ITaskAppService
    {
        private readonly IRepository<Task> _taskRepository;

        public TaskAppService(IRepository<Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public  List<TaskListDto> GetAll(GetAllTasksInput input)
        {
            var tasks =  _taskRepository
                .GetAll()
                .WhereIf(input.State.HasValue, o => o.State == input.State.Value)
                .OrderByDescending(o => o.CreationTime)
                .ToList();

            //return new ListResultOutput<TaskListDto>(
            //    ObjectMapper.Map<List<TaskListDto>>(tasks)
            //);

            return new List<TaskListDto>(ObjectMapper.Map<List<TaskListDto>>(tasks));
            //{
            //    //ObjectMapper.Map<List<TaskListDto>>(tasks)
            //    ObjectMapper.Map<List<TaskListDto>>(tasks)
            //};

        }
    }
}
