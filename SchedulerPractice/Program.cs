using Hangfire;
using Hangfire.Common;
using Hangfire.Logging;
using Hangfire.Logging.LogProviders;
using Hangfire.SqlServer;
using Newtonsoft.Json;
using System;
using System.Linq.Expressions;
using System.Web;

namespace SchedulerPractice
{
    class Program
    {
        static void Main(string[] args)
        {

            //Configuration();
            // Jobs
            using (new FakeHttpContext.FakeHttpContext())
            {
                var currentContext = HttpContext.Current;
                using (var server = new BackgroundJobServer(SetOptions(), new SqlServerStorage("HangfireConnection")))
                {
                    Console.WriteLine("Hangfire Server started. Press any key to exit...");
                    //    //BackgroundMethods();
                    //    //DelayedBackgroubdJobs();
                    //    RemoveRecurringJobs();
                    AddRecurringJobs();

                    Console.ReadKey();
                    //string consoleInput = default;
                    //do
                    //{
                    //    consoleInput = Console.ReadLine();
                    //}
                    //while (consoleInput != "q");
                }
            }
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
            //.UseSqlServerStorage("HangfireConnection2")
            //.UseSqlServerStorage("HangfireConnection3");
            LogProvider.SetCurrentLogProvider(null);
        }

        private static void BackgroundMethods()
        {
            IBackgroundJobClient backgroundJobClient = new BackgroundJobClient();
            backgroundJobClient.Enqueue(() => Console.WriteLine("Instant Background Methods"));
        }

        private static void DelayedBackgroubdJobs()
        {
            BackgroundJob.Schedule(() => Console.WriteLine("Delayed Background Methods"), TimeSpan.FromMilliseconds(5000));
        }

        private static void AddRecurringJobs()
        {
            //LogProvider.SetCurrentLogProvider(new ColouredConsoleLogProvider());
            //RecurringJob.AddOrUpdate("ev-min-recur", () => Console.WriteLine("Recurring Background Methods"), Cron.Minutely);
            var jobManager = new RecurringJobManager(new SqlServerStorage("HangfireConnection"));
            Action<HttpContext> expression = PerformJob;
            var job = new Job(expression.Method, HttpContext.Current);

            jobManager.AddOrUpdate("recurring-job-minute",
                job,
                Cron.Minutely());
            jobManager.Trigger("recurring-job-minute");
        }

        private static void RemoveRecurringJobs()
        {
            RecurringJob.RemoveIfExists("Console.Write");
            RecurringJob.RemoveIfExists("ev-min-recur");
        }

        public static void PerformJob(HttpContext httpContext)
        {
            var context = httpContext;
            Console.WriteLine("Recurring Background Methods");
        }
    }
}
