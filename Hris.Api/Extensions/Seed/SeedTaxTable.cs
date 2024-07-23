using Hris.Data.DataContext;
using Hris.Data.Models.Employee;
using Hris.Data.Models.Payroll;
using Microsoft.AspNetCore.Identity;

namespace Hris.Api.Extensions.Seed
{
    public static class SeedTaxTableExtension
    {
        public static WebApplication SeedTaxTable(this WebApplication application)
        {
            using (var scope = application.Services.CreateScope())
            {

                //        Daily = 1,
                //Weekly = 2,
                //SemiMonthly = 3,
                //Monthly = 4,
                //Anually = 5

                using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    var listTaxTables = new List<TaxTable>();
                    
                    //Semi-Monthly
                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.SemiMonthly,
                        Code = "SM1",
                        RangeFrom = 0,
                        RangeTo = 10416.00m,
                        FixRate = 0,
                        TaxRate = 0,
                        ExcessOver = 0
                    });
                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.SemiMonthly,
                        Code = "SM2",
                        RangeFrom = 10417.00m,
                        RangeTo = 16666.00m,
                        FixRate = 0,
                        TaxRate = 0.15m,
                        ExcessOver = 10417.00m
                    });

                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.SemiMonthly,
                        Code = "SM3",
                        RangeFrom = 16667.00m,
                        RangeTo = 33332.00m,
                        FixRate = 937.50m,
                        TaxRate = 0.20m,
                        ExcessOver = 16667.00m
                    });

                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.SemiMonthly,
                        Code = "SM4",
                        RangeFrom = 33333.00m,
                        RangeTo = 83332.00m,
                        FixRate = 4270.70m,
                        TaxRate = 0.25m,
                        ExcessOver = 33333.00m
                    });

                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.SemiMonthly,
                        Code = "SM5",
                        RangeFrom = 83333.00m,
                        RangeTo = 333332.00m,
                        FixRate = 16770.70m,
                        TaxRate = 0.30m,
                        ExcessOver = 83333.00m
                    });

                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.SemiMonthly,
                        Code = "SM6",
                        RangeFrom = 333333.00m,
                        RangeTo = 10000000.00m,
                        FixRate = 91770.70m,
                        TaxRate = 0.35m,
                        ExcessOver = 333333.00m
                    });

                    //Monthly
                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.Monthly,
                        Code = "M1",
                        RangeFrom = 0,
                        RangeTo = 20833.00m,
                        FixRate = 0,
                        TaxRate = 0,
                        ExcessOver = 0
                    });

                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.Monthly,
                        Code = "M2",
                        RangeFrom = 20834.00m,
                        RangeTo = 33332.00m,
                        FixRate = 0,
                        TaxRate = 0.15m,
                        ExcessOver = 20834.00m
                    });

                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.Monthly,
                        Code = "M3",
                        RangeFrom = 33333.00m,
                        RangeTo = 66666.00m,
                        FixRate = 1875.00m,
                        TaxRate = 0.20m,
                        ExcessOver = 33333.00m
                    });

                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.Monthly,
                        Code = "M4",
                        RangeFrom = 66667.00m,
                        RangeTo = 166666.00m,
                        FixRate = 8541.80m,
                        TaxRate = 0.25m,
                        ExcessOver = 66667.00m
                    });

                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.Monthly,
                        Code = "M5",
                        RangeFrom = 166667.00m,
                        RangeTo = 666666.00m,
                        FixRate = 33541.80m,
                        TaxRate = 0.30m,
                        ExcessOver = 166667.00m
                    });

                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.Monthly,
                        Code = "M6",
                        RangeFrom = 666667.00m,
                        RangeTo = 10000000.00m,
                        FixRate = 183541.80m,
                        TaxRate = 0.35m,
                        ExcessOver = 666667.00m
                    });

                    //Annual
                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.Anually,
                        Code = "A1",
                        RangeFrom = 0,
                        RangeTo = 250000.00m,
                        FixRate = 0,
                        TaxRate = 0,
                        ExcessOver = 0
                    });

                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.Anually,
                        Code = "A2",
                        RangeFrom = 250001.00m,
                        RangeTo = 400000.00m,
                        FixRate = 0,
                        TaxRate = 0.15m,
                        ExcessOver = 250001.00m
                    });

                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.Anually,
                        Code = "A3",
                        RangeFrom = 400001.00m,
                        RangeTo = 800000.00m,
                        FixRate = 22500.00m,
                        TaxRate = 0.20m,
                        ExcessOver = 400001.00m
                    });

                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.Anually,
                        Code = "A4",
                        RangeFrom = 800001.00m,
                        RangeTo = 2000000.00m,
                        FixRate = 102500.00m,
                        TaxRate = 0.25m,
                        ExcessOver = 800001.00m
                    });

                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.Anually,
                        Code = "A5",
                        RangeFrom = 2000001.00m,
                        RangeTo = 8000000.00m,
                        FixRate = 402500.00m,
                        TaxRate = 0.30m,
                        ExcessOver = 2000001.00m
                    });

                    listTaxTables.Add(new TaxTable
                    {
                        TaxPeriodType = Data.Models.Enum.TaxPeriodType.Anually,
                        Code = "A6",
                        RangeFrom = 8000001.00m,
                        RangeTo = 20000000.00m,
                        FixRate = 2202500.00m,
                        TaxRate = 0.35m,
                        ExcessOver = 8000001.00m
                    });

                    foreach(var item in listTaxTables)
                    {
                        var isExist = appContext.TaxTable.Where(f => f.Code.Equals(item.Code) && f.TaxPeriodType.Equals(item.TaxPeriodType)).Any();
                        if(!isExist)
                            appContext.TaxTable.Add(item);
                    };

                    appContext.SaveChanges();

                }
            }

            return application;
        }
    }
}
