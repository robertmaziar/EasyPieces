using EasyPieces.Builders.Interfaces;
using EasyPieces.Builders;
using EasyPieces.TestApi.Commands;
using Microsoft.AspNetCore.Mvc;

namespace EasyPieces.TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkflowController : ControllerBase
    {
        private readonly ILogger<WorkflowController> _logger;

        public WorkflowController(ILogger<WorkflowController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> TestWorkflowAsync()
        {
            try
            {
                IWorkflowTaskCommand taskCommand1 = new WorkflowTaskCommandTest();
                IWorkflowTaskCommand taskCommand2 = new WorkflowTaskCommandTest(new { MillisecondsDelay = 100 });

                var workflow = new WorkflowBuilder()
                .WithTask("Task One", taskCommand1)
                .WithTask("Task Two", taskCommand2)
                .WithLogger(_logger)
                .RunAsync();

                var result = await workflow;

                if (result.IsCompletedSuccessfully)
                    return Ok(result);
                else
                    return BadRequest(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);

                throw;
            }
        }
    }
}
