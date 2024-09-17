using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Motus_DataAccessLayer.Services
{
    public abstract class BaseService
    {
        protected string _connectionString;
        protected BaseService(IConfiguration config, string dbName)
        {
            _connectionString = config.GetConnectionString(dbName);
        }
        protected SqlCommand CreateCommand(string query, bool isProcedure = false, Dictionary<string, object?>? parameters = null)
        {
            SqlCommand command = new SqlCommand();
            command.Connection = new SqlConnection(_connectionString);
            command.CommandText = query;
            command.CommandType = (isProcedure) ? System.Data.CommandType.StoredProcedure : System.Data.CommandType.Text;
            foreach (KeyValuePair<string, object?> kvp in parameters)
            {
                command.Parameters.AddWithValue(kvp.Key, kvp.Value ?? DBNull.Value);
            }
            return command;
        }
    }
}
