using Hris.Business.Extensions;
using Hris.Business.Service.Common;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Graph.Models.Security;

namespace Hris.Business.Service.Leave
{
    public class ScheduledLeaveReportService : BackgroundService
    {
        private readonly ILogger<EmailSender> logger;
        private readonly SmtpService smtpService;

        public ScheduledLeaveReportService(ILogger<EmailSender> logger,
            IServiceScopeFactory factory)
        {
            this.logger = logger;
            this.smtpService = factory.CreateScope().ServiceProvider.GetRequiredService<SmtpService>();
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                var current = DateTime.UtcNow.ConvertToTimezone();
                var start = new DateTime(current.Year, current.Month, 1);
                var end = start.AddMonths(1).AddSeconds(-1);
                var firstHalf = GetNextDate(start, 15);

                this.logger.LogInformation("Scheduled Leave Report - [Current: " + current + ", First Half: " + firstHalf + ", End: " + end + "]");

                if (CompareDates(current, firstHalf))
                    await this.smtpService.SendScheduledLeaveReport(start, firstHalf);
                else if (CompareDates(current, end))
                    await this.smtpService.SendScheduledLeaveReport(firstHalf, end);

                var ts = (GetNextDate(current, current <= firstHalf ? firstHalf.Day : end.Day)).Subtract(current);
                if (ts < TimeSpan.Zero)
                {
                    await Task.Delay(TimeSpan.FromSeconds(1));
                    continue;
                }
                await Task.Delay(ts, stoppingToken);
            }
        }

        private DateTime GetNextDate(DateTime dt, int day)
        {
            if (day >= 1 && day <= 31)
            {
                while (dt.Day != day)
                    dt = dt.AddDays(1);
                return dt.Date.AddDays(1).AddSeconds(-1);
            }
            else
                throw new ArgumentOutOfRangeException();
        }

        private bool CompareDates(DateTime dt1, DateTime dt2)
            => Math.Abs((dt1.Subtract(dt2)).TotalMilliseconds) < 100;

    }
}
