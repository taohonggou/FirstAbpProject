using Acme.SimpleTaskApp.Tasks;
using Acme.SimpleTaskApp.Web.Controllers;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Acme.SimpleTaskApp.Web.Tests.Controllers
{
    public class TasksController_Tests:SimpleTaskAppWebTestBase
    {
        [Fact]
        public async System.Threading.Tasks.Task Should_Get_Tasks_By_State()
        {
            var response = await GetResponseAsStringAsync(
                GetUrl<TasksController>(nameof(TasksController.Index),new {State=TaskState.Open })
                );

            response.ShouldNotBeNullOrWhiteSpace();
        }
    }
}
