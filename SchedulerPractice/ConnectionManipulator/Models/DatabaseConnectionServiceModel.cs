using SchedulerPractice.ConnectionManipulator.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerPractice.ConnectionManipulator.Models
{
    internal class DatabaseConnectionServiceModel: IDatabaseConnectionServiceModel
    {
        public string DatabaseName { get; set; }
        public string ServerInstance { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool HasIntegratedSecurity { get; set; }
    }
}
