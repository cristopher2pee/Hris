
using Hris.Business.Extensions;
using Hris.Business.Models;
using Hris.Data.Models.Leave;
using QuestPDF.Fluent;
using QuestPDF.Helpers;
using QuestPDF.Infrastructure;

namespace Hris.Business.Service.Common
{
    public class PdfService
    {
        public byte[] GenerateLeaveReportPdf(string title, IEnumerable<IGrouping<Guid, LeaveApplication>> d)
        {
            void ComposeTable(IContainer container)
            {
                container.Border(1)
                .Table(table =>
                {
                    table.ColumnsDefinition(columns =>
                    {
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                        columns.RelativeColumn();
                    });

                    table.Header(header =>
                    {
                        header.Cell().Border(1).AlignCenter().Text("Employee").Bold();
                        header.Cell().Border(1).AlignCenter().Text("Leave Type").Bold();
                        header.Cell().Border(1).AlignCenter().Text("From Date").Bold();
                        header.Cell().Border(1).AlignCenter().Text("To Date").Bold();
                        header.Cell().Border(1).AlignCenter().Text("Paid").Bold();
                        header.Cell().Border(1).AlignCenter().Text("Days").Bold();
                        header.Cell().Border(1).AlignCenter().Text("Total").Bold();
                    });

                    var data = d.Select(d =>
                    {
                        var e = d.First().Employee;
                        var p = d.Where(l => l.LeaveType.IsPaid);
                        var np = d.Where(l => !l.LeaveType.IsPaid);

                        return new ScheduledLeaveReport
                        {
                            Employee = $"{e.Lastname}, {e.Firstname}",
                            TotalPaid = p.Sum(l => l.Days),
                            CountPaid = p.Count(),
                            TotalNonPaid = np.Sum(l => l.Days),
                            CountNonPaid = np.Count(),
                            Requests = d.OrderBy(a => a.LeaveType.IsPaid).Select(r => new ScheduledLeaveApplication
                            {
                                From = r.From.ConvertToTimezone().ToShortDateString(),
                                To = r.To.ConvertToTimezone().ToShortDateString(),
                                Days = r.Days,
                                LeaveType = r.LeaveType.Name,
                                Paid = r.LeaveType.IsPaid
                            }),
                        };
                    });

                    foreach (var i in data)
                    {
                        table.Cell().RowSpan((uint)i.Requests.Count()).Border(1).AlignCenter().Text(i.Employee);
                        var hasTotal = false;
                        foreach (var j in i.Requests)
                        {
                            table.Cell().Border(1).AlignCenter().Text(j.LeaveType);
                            table.Cell().Border(1).AlignCenter().Text(j.From);
                            table.Cell().Border(1).AlignCenter().Text(j.To);
                            table.Cell().Border(1).AlignCenter().Text(j.Paid);
                            table.Cell().Border(1).AlignCenter().Text(j.Days);

                            if (!hasTotal)
                            {
                                table.Cell().RowSpan((uint)i.Requests.Count()).Border(1).AlignCenter().Text($"Paid: {i.TotalPaid}\nNon-paid: {i.TotalNonPaid}");
                                hasTotal = true;
                            }
                        }

                    }
                });
            }

            return Document.Create(container =>
            {
                container.Page(page =>
                {
                    page.Size(PageSizes.A4);
                    page.Margin(1, Unit.Centimetre);

                    page.Header()
                        .Text(title)
                        .SemiBold();


                    page.Content()
                        .PaddingVertical(1, Unit.Centimetre)
                        .Column(x => ComposeTable(x.Item()));

                    page.Footer()
                        .AlignCenter()
                        .Text(x =>
                        {
                            x.Span("Page ");
                            x.CurrentPageNumber();
                        });
                });
            })
            .GeneratePdf();
        }
    }
}
