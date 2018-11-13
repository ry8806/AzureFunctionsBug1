using EfLibrary;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using System;

namespace FunctionsBug1
{
    public static class TimerFunction1
    {
        [FunctionName("Function1")]
        public static void Run([TimerTrigger("*/30 * * * * *")]TimerInfo myTimer, ILogger log)
        {
            // Error about TContext here - same DbContext works fine in ASP.NET Core web app
            var dbContext = FunctionDiConfigurator.GetService<ApplicationDbContext>();

            log.LogInformation($"C# Timer trigger function executed at: {DateTime.Now}");
        }
    }
}
