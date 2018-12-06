using Hangfire;
using Hangfire.Logging;
using System;

namespace SchedulerPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            Configuration();
            // Jobs
            using (var server = new BackgroundJobServer(SetOptions()))
            {
                Console.WriteLine("Hangfire Server started. Press any key to exit...");
                BackgroundMethods();
                DelayedBackgroubdJobs();
                RemoveRecurringJobs();
                AddRecurringJobs();
                Console.ReadKey();
            }

            Console.ReadKey();
        }

        private static BackgroundJobServerOptions SetOptions()
        {
            return new BackgroundJobServerOptions
            {
                SchedulePollingInterval = TimeSpan.FromSeconds(1)                
            };
        }

        private static void Configuration()
        {
            GlobalConfiguration.Configuration
                  .UseColouredConsoleLogProvider()
                  .UseSqlServerStorage("HangfireConnection");
            LogProvider.SetCurrentLogProvider(null);
        }

        private static void BackgroundMethods()
        {
            BackgroundJob.Enqueue(() => Console.WriteLine("Instant Background Methods"));
        }

        private static void DelayedBackgroubdJobs()
        {
            BackgroundJob.Schedule(() => Console.WriteLine("Delayed Background Methods"), TimeSpan.FromMilliseconds(5000));
        }

        private static void AddRecurringJobs()
        {
            RecurringJob.AddOrUpdate("ev-min-recur", () => Console.WriteLine("Recurring Background Methods"), Cron.Minutely);
        }

        private static void RemoveRecurringJobs()
        {
            RecurringJob.RemoveIfExists("Console.Write");
        }
    }
}
