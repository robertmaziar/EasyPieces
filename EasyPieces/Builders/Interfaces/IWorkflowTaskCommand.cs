namespace EasyPieces.Builders.Interfaces
{
    public interface IWorkflowTaskCommand
    {
        public dynamic? Parameters { get; set; }

        Task ExecuteAsync();
    }
}
