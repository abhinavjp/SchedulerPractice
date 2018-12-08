using SchedulerPractice.ConnectionManipulator.Interfaces;
using SchedulerPractice.ConnectionManipulator.Models;

namespace SchedulerPractice.ConnectionManipulator.Services
{
    internal static class DatabaseConnectionUtils
    {
        public static string CreateConnectionString(IDatabaseConnectionServiceModel connectionCredentails, ConnectionStringType connectionStringType)
        {
            var connectionStringBuilder = ConnectionManipulatorFactory.GetConnectionStringBuilder(connectionStringType);
            return connectionStringBuilder.CreateConnectionString(connectionCredentails);
        }
    }
}
