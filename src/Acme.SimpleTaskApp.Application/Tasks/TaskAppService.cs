using Abp.Domain.Repositories;
using Abp.Linq.Extensions;
using Acme.SimpleTaskApp.Tasks.Dto;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System;
using Abp.UI;

namespace Acme.SimpleTaskApp.Tasks
{
    public class TaskAppService : SimpleTaskAppAppServiceBase, ITaskAppService
    {
        private readonly IRepository<Task> _taskRepository;

        public TaskAppService(IRepository<Task> taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public async  System.Threading.Tasks.Task Create(CreateTaskInput input)
        {
            var task = ObjectMapper.Map<Task>(input);
            await  _taskRepository.InsertAsync(task);
        }

        
        public async  Task<bool> Delete(DeleteTaskInput input)
        {
            var task=await _taskRepository.FirstOrDefaultAsync(input.Id);
            if(task==null)
                throw new UserFriendlyException("异常", "任务id不存在");

            await _taskRepository.DeleteAsync(task);
            return true;
        }

        public async  Task<TaskDto> Get(int id)
        {
            var task=await  _taskRepository.FirstOrDefaultAsync(id);
            return ObjectMapper.Map<TaskDto>(task);
        }

        public async Task<List<TaskListDto>> GetAll(GetAllTasksInput input)
        {
            var tasks = await _taskRepository
                .GetAll()
                .Include(t=>t.AssignedPerson)
                .WhereIf(input.State.HasValue, o => o.State == input.State.Value)
                .OrderByDescending(o => o.CreationTime)
                .ToListAsync();

            return new List<TaskListDto>(ObjectMapper.Map<List<TaskListDto>>(tasks));
        }
    }
}
