using System.Data.SqlClient;
using SchedulerPractice.ConnectionManipulator.Interfaces;
using SchedulerPractice.ErrorHandler;

namespace SchedulerPractice.ConnectionManipulator.Services
{
    public class MsSqlConnectionStringBuilder : IConnectionStringBuilder
    {
        private static IConnectionStringBuilder _instance;
        private static readonly object _lockObject = new object();
        public static IConnectionStringBuilder Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new MsSqlConnectionStringBuilder();
                        }
                    }
                }
                return _instance;
            }
        }
        private MsSqlConnectionStringBuilder()
        {

        }
        public string CreateConnectionString(IDatabaseConnectionServiceModel databaseConnectionServiceModel)
        {
            if (string.IsNullOrWhiteSpace(databaseConnectionServiceModel.ServerInstance))
                throw new SmartResponseException("Server Instance was not provided.", ResponseStatusCode.PreconditionFailed);
            if (!databaseConnectionServiceModel.HasIntegratedSecurity)
            {
                if (string.IsNullOrWhiteSpace(databaseConnectionServiceModel.Username))
                {
                    throw new SmartResponseException("Username was not provided.", ResponseStatusCode.PreconditionFailed);
                }
                if (string.IsNullOrWhiteSpace(databaseConnectionServiceModel.Password))
                {
                    throw new SmartResponseException("Password was not provided.", ResponseStatusCode.PreconditionFailed);
                }
            }
            return new SqlConnectionStringBuilder
            {
                DataSource = databaseConnectionServiceModel.ServerInstance,
                InitialCatalog = databaseConnectionServiceModel.DatabaseName,
                IntegratedSecurity = databaseConnectionServiceModel.HasIntegratedSecurity,
                UserID = databaseConnectionServiceModel.Username,
                Password = databaseConnectionServiceModel.Password
            }.ToString();
        }
    }
}
