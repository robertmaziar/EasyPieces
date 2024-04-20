using EasyPieces.Builders.Interfaces;
using Microsoft.Extensions.Logging;

namespace EasyPieces.Builders
{
    public class WorkflowBuilder
    {
        private ILogger? _logger; 
        private List<WorkflowTask> _tasks;

        public WorkflowBuilder() 
        {
            _tasks = new List<WorkflowTask>();    
        }

        public WorkflowBuilder WithLogger(ILogger logger)
        {
            _logger = logger;

            return this;
        }

        public WorkflowBuilder WithTask(string name, IWorkflowTaskCommand command)
        {
            _tasks.Add(new WorkflowTask(name, command));
            
            return this;
        }

        public async Task<Task> RunAsync()
        {
            foreach (var task in _tasks)
            {
                await task.RunAsync(_logger);
            }

            return Task.CompletedTask;
        }
    }
}
