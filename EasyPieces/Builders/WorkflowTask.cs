using EasyPieces.Builders.Interfaces;
using Microsoft.Extensions.Logging;

namespace EasyPieces.Builders
{
    public class WorkflowTask
    {
        public string Name { get; }
        public IWorkflowTaskCommand Command { get; set; }

        public WorkflowTask(string name, IWorkflowTaskCommand command)
        {
            Name = name;
            Command = command;
        }

        public async Task RunAsync(ILogger logger)
        {
            try
            {
                if (logger != null)
                    logger.LogInformation($"Executing task: {Name}");

                await Command.ExecuteAsync();
            }
            catch (Exception ex)
            {
                if (logger != null)
                    logger.LogError($"Executing task: {Name}");

                throw;
            }
        }
    }
}
