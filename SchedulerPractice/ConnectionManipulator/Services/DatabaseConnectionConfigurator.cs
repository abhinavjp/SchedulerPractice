using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace SchedulerPractice.ConnectionManipulator.Services
{
    public static class DatabaseConnectionConfigurator
    {
        public static IDbConnection InitializeConnection(DatabaseConnectionAdapter adapter)
        {
            var connectionString = DatabaseConnectionUtils.CreateConnectionString(adapter.DatabaseConnection, adapter.ConnectionStringType);
            IDbConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }

        public static void PerformDbInteraction(Action<IDbConnection> action, DatabaseConnectionAdapter adapter)
        {
            using (var connection = InitializeConnection(adapter))
            {
                action?.Invoke(connection);
            }
        }

        public static IDbCommand PerformCommand(DatabaseConnectionAdapter adapter)
        {
            IDbCommand dbCommand = null;
            PerformDbInteraction(con =>
            {
                dbCommand = con.CreateCommand();
            }, adapter);
            return dbCommand;
        }
    }
}
