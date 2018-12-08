using System;
using System.Collections.Generic;
using System.Text;

namespace SchedulerPractice.ConnectionManipulator.Interfaces
{
    public interface IDatabaseConnectionServiceModel
    {
        string DatabaseName { get; set; }
        string ServerInstance { get; set; }
        string Username { get; set; }
        string Password { get; set; }
        bool HasIntegratedSecurity { get; set; }
    }
}
