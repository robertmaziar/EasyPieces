using EasyPieces.Builders.Interfaces;

namespace EasyPieces.Builders
{
    /// <summary>
    /// Incomplete implementation
    /// </summary>
    public class WorkflowBuilder
    {
        private List<WorkflowTask> _tasks;

        public WorkflowBuilder() 
        {
            _tasks = new List<WorkflowTask>();    
        }    

        public WorkflowBuilder WithTask(WorkflowTask task)
        {
            _tasks.Add(task);

            return this;
        }

        public List<WorkflowTask> Build()
        {
            return _tasks;
        }
    }

    public static class WorkflowTaskListExtensions
    {
        public static async Task<Task> ExecuteAsync(this List<WorkflowTask> tasks)
        {
            foreach (IWorkflowTask task in tasks)
            {
                await task.Execute();
            }

            return Task.CompletedTask;
        }
    }
}
