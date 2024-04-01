
namespace EasyPieces.Services
{
    public interface ISqlDataAccess
    {
        Task<IEnumerable<T>> LoadData<T, U, V, W, X>(string storedProcedure, Func<T, U, V, W, T> map, X parameters, string connectionId = "DefaultConnection");
        Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "DefaultConnection");
        Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection");
        int SaveDataScalar<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection");
    }
}