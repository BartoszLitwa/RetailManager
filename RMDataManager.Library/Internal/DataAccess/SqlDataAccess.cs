using Dapper;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace RMDataManager.Library.Internal.DataAccess
{
    internal class SqlDataAccess
    {
        public string GetConnectionString(string name)
        {
            return ConfigurationManager.ConnectionStrings[name].ConnectionString;
        }

        public async Task<List<T>> LoadData<T, U>(string storedProcedure, U parameters, string connectionStringName)
        {
            string connectinString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectinString))
            {
                List<T> rows = (await connection.QueryAsync<T>(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure)).ToList();

                return rows;
            }
        }

        public async Task SaveData<T>(string storedProcedure, T parameters, string connectionStringName)
        {
            string connectinString = GetConnectionString(connectionStringName);

            using (IDbConnection connection = new SqlConnection(connectinString))
            {
                _ = await connection.ExecuteAsync(storedProcedure, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }
    }
}
