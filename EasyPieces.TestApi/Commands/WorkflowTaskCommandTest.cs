using EasyPieces.Builders.Interfaces;

namespace EasyPieces.TestApi.Commands
{
    public class WorkflowTaskCommandTest : IWorkflowTaskCommand
    {
        public dynamic? Parameters { get; set; }

        public WorkflowTaskCommandTest() { }

        public WorkflowTaskCommandTest(dynamic parameters)
        {
            Parameters = parameters;
        }

        public async Task ExecuteAsync()
        {
            // Simulating asynchronous operation
            await Task.Delay(Parameters == null ? 1000 : Parameters.MillisecondsDelay);
        }
    }
}
