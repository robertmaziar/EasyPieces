using Dapper;
using Microsoft.Extensions.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace EasyPieces.Services
{
    public class SqlDataAccess : ISqlDataAccess
    {
        readonly IConfiguration _configuration;

        public SqlDataAccess(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<IEnumerable<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionId = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

            return await connection.QueryAsync<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task<IEnumerable<T>> LoadData<T, U, V, W, X>(string storedProcedure, Func<T, U, V, W, T> map, X parameters, string connectionId = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

            return await connection.QueryAsync(storedProcedure, map, parameters, commandType: CommandType.StoredProcedure);
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

            await connection.ExecuteAsync(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }

        public int SaveDataScalar<T>(string storedProcedure, T parameters, string connectionId = "DefaultConnection")
        {
            using IDbConnection connection = new SqlConnection(_configuration.GetConnectionString(connectionId));

            return connection.ExecuteScalar<int>(storedProcedure, parameters, commandType: CommandType.StoredProcedure);
        }
    }
}
