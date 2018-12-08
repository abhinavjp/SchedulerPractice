using SchedulerPractice.ConnectionManipulator.Interfaces;
using SchedulerPractice.ConnectionManipulator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerPractice.ConnectionManipulator.Services
{
    public class DatabaseConnectionAdapter
    {
        private readonly IDatabaseConnectionServiceModel _databaseConnection;
        public IDatabaseConnectionServiceModel DatabaseConnection => _databaseConnection;
        public ConnectionStringType ConnectionStringType { get; set; }
        public DatabaseConnectionAdapter(IDatabaseConnectionServiceModel databaseConnection)
        {
            _databaseConnection = databaseConnection;
        }
        public bool IsConnectionSuccessful { get; set; }
    }


}
