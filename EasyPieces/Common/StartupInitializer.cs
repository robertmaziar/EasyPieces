namespace EasyPieces.Common
{
    public abstract class StartupInitializer<T>
    {
        public abstract IEnumerable<T> GetData();
        public abstract IEnumerable<T> PopulateData(string connectionString);
    }
}
