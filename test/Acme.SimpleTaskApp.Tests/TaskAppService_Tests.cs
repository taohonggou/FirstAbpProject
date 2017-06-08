using Acme.SimpleTaskApp.Tasks;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Acme.SimpleTaskApp.Tests
{
    public class TaskAppService_Tests : SimpleTaskAppAppServiceBase
    {
        private readonly ITaskAppService _taskAppService;
        
        public TaskAppService_Tests(ITaskAppService taskAppService)
        {
            _taskAppService = taskAppService;
        }

        [Fact]
        public void Should_Get_All_Tasks()
        {
            var output = _taskAppService.GetAll(new Tasks.Dto.GetAllTasksInput());

            output.Count.ShouldBe(2);
        }


    }
}
