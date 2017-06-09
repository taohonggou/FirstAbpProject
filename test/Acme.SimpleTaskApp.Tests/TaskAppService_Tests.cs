using Acme.SimpleTaskApp.Tasks;
using Acme.SimpleTaskApp.Tasks.Dto;
using Microsoft.EntityFrameworkCore;
using Shouldly;
using System.Linq;
using Xunit;

namespace Acme.SimpleTaskApp.Tests
{
    public class TaskAppService_Tests : SimpleTaskAppTestBase
    {
        private readonly ITaskAppService _taskAppService;

        public TaskAppService_Tests()
        {
            _taskAppService = Resolve<ITaskAppService>();
        }

        [Fact]
        public async void  Should_Get_All_Tasks()
        {
            var output =await  _taskAppService.GetAll(new Tasks.Dto.GetAllTasksInput());

            output.Count.ShouldBe(2);
        }

        [Fact]
        public async void Should_Get_Filtered_Tasks()
        {
            //Act
            var response = await   _taskAppService.GetAll(new GetAllTasksInput { State = TaskState.Open });

            //Assert
            response.ShouldAllBe(t => t.State == TaskState.Open);

            var tasksInDatabase = UsingDbContextAsync(async dbContext => {
                return await dbContext.Tasks
                .Where(o => o.State == TaskState.Open)
                .ToListAsync();
            });

            //var document = new HtmlParser().Parse(response);
        }

    }
}
