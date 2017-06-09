using Abp.Runtime.Validation;
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
        public async void Should_Get_All_Tasks()
        {
            var output = await _taskAppService.GetAll(new GetAllTasksInput());

            output.Count.ShouldBe(2);
            output.Count(o => o.AssignedPersonName != null).ShouldBe(1);
        }

        [Fact]
        public async void Should_Get_Filtered_Tasks()
        {
            //Act
            var response = await _taskAppService.GetAll(new GetAllTasksInput { State = TaskState.Open });

            //Assert
            response.ShouldAllBe(t => t.State == TaskState.Open);

            var tasksInDatabase = UsingDbContextAsync(async dbContext =>
            {
                return await dbContext.Tasks
                .Where(o => o.State == TaskState.Open)
                .ToListAsync();
            });

            //var document = new HtmlParser().Parse(response);
        }

        [Fact]
        public async System.Threading.Tasks.Task Should_Create_New_Task_With_Title()
        {
            await _taskAppService.Create(new CreateTaskInput
            {
                Title = "Newly created task #1"
            });

            var task = await UsingDbContext(context => context.Tasks.FirstOrDefaultAsync(o => o.Title == "Newly created task #1"));
            task.ShouldNotBeNull();
        }


        [Fact]
        public async System.Threading.Tasks.Task Should_Create_New_Task_With_Title_And_Assigned_Person()
        {
            var neo = UsingDbContext(context => context.People.Single(o => o.Name == "Neo"));
            await _taskAppService.Create(new CreateTaskInput
            {
                Title = "Newly created task #1",
                AssignedPersonId = neo.Id
            });

            var task = await UsingDbContext(context => context.Tasks.FirstOrDefaultAsync(o => o.Title == "Newly created task #1"));

            task.ShouldNotBeNull();
            task.AssignedPersonId.ShouldBe(neo.Id);
        }

        [Fact]
        public async System.Threading.Tasks.Task Shoule_Not_Create_New_Task_Without_Title()
        {
            await Assert.ThrowsAsync<AbpValidationException>(
                async () =>
                {
                    await _taskAppService.Create(new CreateTaskInput()
                    {
                        Title = null
                    });
                });
        }
    }
}
