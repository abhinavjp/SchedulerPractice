using SchedulerPractice.ConnectionManipulator.Interfaces;
using SchedulerPractice.ConnectionManipulator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchedulerPractice.ConnectionManipulator.Services
{
    public static class ConnectionManipulatorFactory
    {
        public static IConnectionStringBuilder GetConnectionStringBuilder(ConnectionStringType connectionStringType)
        {
            switch (connectionStringType)
            {
                case ConnectionStringType.MSSQL:
                    return MsSqlConnectionStringBuilder.Instance;
                default:
                    throw new InvalidOperationException("Invalid Connection String Type!");
            }
        }
    }
}
