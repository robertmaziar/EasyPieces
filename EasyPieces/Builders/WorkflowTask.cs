using EasyPieces.Builders.Interfaces;

namespace EasyPieces.Builders
{
    /// <summary>
    ///   /// <summary>
    /// Incomplete implementation
    /// </summary>
    /// </summary>
    public class WorkflowTask : IWorkflowTask
    {
        private readonly string _name;
        private readonly Func<Task>? _asyncAction;
        private readonly Action? _syncAction;

        public WorkflowTask(string name, Func<Task> action)
        {
            _name = name;
            _asyncAction = action;
        }

        public WorkflowTask(string name, Action action)
        {
            _name = name;
            _syncAction = action;
        }

        public async Task Execute()
        {
            try
            {
                Console.WriteLine($"Executing task: {_name}");

                // Execute asynchronous action if provided
                // otherwise, execute synchronous action if provided
                if (_asyncAction != null)
                {
                    await _asyncAction.Invoke();
                }
                else if (_syncAction != null)
                {
                    _syncAction.Invoke();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");

                throw;
            }
        }
    }
}
