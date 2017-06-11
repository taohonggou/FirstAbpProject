using Abp.Application.Services;
using Acme.SimpleTaskApp.Tasks.Dto;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Acme.SimpleTaskApp.Tasks
{
    public interface ITaskAppService : IApplicationService
    {
        Task<List<TaskListDto>> GetAll(GetAllTasksInput input);

        System.Threading.Tasks.Task Create(CreateTaskInput input);

        Task<bool> Delete(DeleteTaskInput  input);

        Task<TaskDto> Get(int id);

        System.Threading.Tasks.Task Edit();
    }
}
