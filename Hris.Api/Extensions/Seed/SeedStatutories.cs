

using Hris.Data.DataContext;
using Hris.Data.Models.Statutory;
using Newtonsoft.Json;

namespace Hris.Api.Extensions.Seed
{
    public class SeedStatutories
    {
    }

    public static class SeedStatutoriesExtension
    {
        public static WebApplication SeedPHICTable(this WebApplication application)
        {
            using (var scope = application.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    var phicList = new List<PHICTable>();

                    phicList.Add(new PHICTable
                    {
                        Code = "PHIC_1",
                        RangeFrom = 0,
                        RangeTo = 10000.00m,
                        EEShare = 0.025m,
                        ERShare = 0.025m,
                        Active = true,
                    });

                    phicList.Add(new PHICTable
                    {
                        Code = "PHIC_2",
                        RangeFrom = 10001.00m,
                        RangeTo = 99999.00m,
                        EEShare = 0.025m,
                        ERShare = 0.025m,
                        Active = true,
                    });

                    phicList.Add(new PHICTable
                    {
                        Code = "PHIC_3",
                        RangeFrom = 100000.00m,
                        RangeTo = 1000000.00m,
                        EEShare = 0.025m,
                        ERShare = 0.025m,
                        Active = true,
                    });

                    foreach (var item in phicList)
                    {
                        var exist = appContext.PHICTable.Where(f => f.Code.Equals(item.Code)).Any();
                        if (!exist)
                            appContext.PHICTable.Add(item);
                    }

                    appContext.SaveChanges();
                }
            }
            return application;
        }

        public static WebApplication SeedHDMFTable(this WebApplication application)
        {
            using (var scope = application.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    var list = new List<HDMFTable>();

                    list.Add(new HDMFTable
                    {
                        Code = "HDMF_1",
                        RangeFrom = 0.00m,
                        RangeTo = 1500.00m,
                        HDMFEE = 0.01m,
                        HDMFER = 0.02m,
                        HDMFEEMax = 15,
                        HDMFERMax = 30,
                        Active = true,
                    });

                    list.Add(new HDMFTable
                    {
                        Code = "HDMF_2",
                        RangeFrom = 1500.00m,
                        RangeTo = 1000000.00m,
                        HDMFEE = 0.02m,
                        HDMFER = 0.02m,
                        HDMFEEMax = 200,
                        HDMFERMax = 200,
                        Active = true,
                    });

                    foreach (var item in list)
                    {
                        var exist = appContext.HDMFTable.Where(f => f.Code.Equals(item.Code)).Any();
                        if (!exist)
                            appContext.HDMFTable.Add(item);
                    }

                    appContext.SaveChanges();
                }
            }
            return application;
        }

        public static  WebApplication SeedSSSTable(this WebApplication application)
        {
            using (var scope = application.Services.CreateScope())
            {
                using (var appContext = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>())
                {
                    var list = new List<SSSTable>();

                    var data = "[\r\n    {\r\n        \"Code\": \"SSS_1\",\r\n        \"RangeFrom\": \"0\",\r\n        \"RangeTo\": \"4249.99\",\r\n        \"ER\": \"380\",\r\n        \"EE\": \"180\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_2\",\r\n        \"RangeFrom\": \"4250\",\r\n        \"RangeTo\": \"4749.99\",\r\n        \"ER\": \"427.5\",\r\n        \"EE\": \"202.5\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_3\",\r\n        \"RangeFrom\": \"4750\",\r\n        \"RangeTo\": \"5249.99\",\r\n        \"ER\": \"475\",\r\n        \"EE\": \"225\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_4\",\r\n        \"RangeFrom\": \"5250\",\r\n        \"RangeTo\": \"5749.99\",\r\n        \"ER\": \"522.5\",\r\n        \"EE\": \"247.5\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_5\",\r\n        \"RangeFrom\": \"5750\",\r\n        \"RangeTo\": \"6249.99\",\r\n        \"ER\": \"570\",\r\n        \"EE\": \"270\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_6\",\r\n        \"RangeFrom\": \"6250\",\r\n        \"RangeTo\": \"6749.99\",\r\n        \"ER\": \"617.5\",\r\n        \"EE\": \"292.5\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_7\",\r\n        \"RangeFrom\": \"6750\",\r\n        \"RangeTo\": \"7249.99\",\r\n        \"ER\": \"665\",\r\n        \"EE\": \"315\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_8\",\r\n        \"RangeFrom\": \"7250\",\r\n        \"RangeTo\": \"7749.99\",\r\n        \"ER\": \"712.5\",\r\n        \"EE\": \"337.5\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_9\",\r\n        \"RangeFrom\": \"7750\",\r\n        \"RangeTo\": \"8249.99\",\r\n        \"ER\": \"760\",\r\n        \"EE\": \"360\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_10\",\r\n        \"RangeFrom\": \"8250\",\r\n        \"RangeTo\": \"8749.99\",\r\n        \"ER\": \"807.5\",\r\n        \"EE\": \"382.5\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_11\",\r\n        \"RangeFrom\": \"8750\",\r\n        \"RangeTo\": \"9249.99\",\r\n        \"ER\": \"855\",\r\n        \"EE\": \"405\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_12\",\r\n        \"RangeFrom\": \"9250\",\r\n        \"RangeTo\": \"9749.99\",\r\n        \"ER\": \"902.5\",\r\n        \"EE\": \"427.5\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_13\",\r\n        \"RangeFrom\": \"9750\",\r\n        \"RangeTo\": \"10249.99\",\r\n        \"ER\": \"950\",\r\n        \"EE\": \"450\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_14\",\r\n        \"RangeFrom\": \"10250\",\r\n        \"RangeTo\": \"10749.99\",\r\n        \"ER\": \"997.5\",\r\n        \"EE\": \"472.5\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_15\",\r\n        \"RangeFrom\": \"10750\",\r\n        \"RangeTo\": \"11249.99\",\r\n        \"ER\": \"1,045.00\",\r\n        \"EE\": \"495\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_16\",\r\n        \"RangeFrom\": \"11250\",\r\n        \"RangeTo\": \"11749.99\",\r\n        \"ER\": \"1,092.50\",\r\n        \"EE\": \"517.5\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_17\",\r\n        \"RangeFrom\": \"11750\",\r\n        \"RangeTo\": \"12249.99\",\r\n        \"ER\": \"1,140.00\",\r\n        \"EE\": \"540\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_18\",\r\n        \"RangeFrom\": \"12250\",\r\n        \"RangeTo\": \"12749.99\",\r\n        \"ER\": \"1,187.50\",\r\n        \"EE\": \"562.5\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_19\",\r\n        \"RangeFrom\": \"12750\",\r\n        \"RangeTo\": \"13249.99\",\r\n        \"ER\": \"1,235.00\",\r\n        \"EE\": \"585\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_20\",\r\n        \"RangeFrom\": \"13250\",\r\n        \"RangeTo\": \"13749.99\",\r\n        \"ER\": \"1,282.50\",\r\n        \"EE\": \"607.5\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_21\",\r\n        \"RangeFrom\": \"13750\",\r\n        \"RangeTo\": \"14249.99\",\r\n        \"ER\": \"1,330.00\",\r\n        \"EE\": \"630\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_22\",\r\n        \"RangeFrom\": \"14250\",\r\n        \"RangeTo\": \"14749.99\",\r\n        \"ER\": \"1,377.50\",\r\n        \"EE\": \"652.5\",\r\n        \"EC\": \"10\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_23\",\r\n        \"RangeFrom\": \"14750\",\r\n        \"RangeTo\": \"15249.99\",\r\n        \"ER\": \"1,425.00\",\r\n        \"EE\": \"675\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_24\",\r\n        \"RangeFrom\": \"15250\",\r\n        \"RangeTo\": \"15749.99\",\r\n        \"ER\": \"1,472.50\",\r\n        \"EE\": \"697.5\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_25\",\r\n        \"RangeFrom\": \"15750\",\r\n        \"RangeTo\": \"16249.99\",\r\n        \"ER\": \"1,520.00\",\r\n        \"EE\": \"720\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_26\",\r\n        \"RangeFrom\": \"16250\",\r\n        \"RangeTo\": \"16749.99\",\r\n        \"ER\": \"1,567.50\",\r\n        \"EE\": \"742.5\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_27\",\r\n        \"RangeFrom\": \"16750\",\r\n        \"RangeTo\": \"17249.99\",\r\n        \"ER\": \"1,615.00\",\r\n        \"EE\": \"765\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_28\",\r\n        \"RangeFrom\": \"17250\",\r\n        \"RangeTo\": \"17749.99\",\r\n        \"ER\": \"1,662.50\",\r\n        \"EE\": \"787.5\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_29\",\r\n        \"RangeFrom\": \"17750\",\r\n        \"RangeTo\": \"18249.99\",\r\n        \"ER\": \"1,710.00\",\r\n        \"EE\": \"810\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_30\",\r\n        \"RangeFrom\": \"18250\",\r\n        \"RangeTo\": \"18749.99\",\r\n        \"ER\": \"1,757.50\",\r\n        \"EE\": \"832.5\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_31\",\r\n        \"RangeFrom\": \"18750\",\r\n        \"RangeTo\": \"19249.99\",\r\n        \"ER\": \"1,805.00\",\r\n        \"EE\": \"855\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_32\",\r\n        \"RangeFrom\": \"19250\",\r\n        \"RangeTo\": \"19749.99\",\r\n        \"ER\": \"1,852.50\",\r\n        \"EE\": \"877.5\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_33\",\r\n        \"RangeFrom\": \"19750\",\r\n        \"RangeTo\": \"20249.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_34\",\r\n        \"RangeFrom\": \"20250\",\r\n        \"RangeTo\": \"20749.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_35\",\r\n        \"RangeFrom\": \"20750\",\r\n        \"RangeTo\": \"21249.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_36\",\r\n        \"RangeFrom\": \"21250\",\r\n        \"RangeTo\": \"21749.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_37\",\r\n        \"RangeFrom\": \"21750\",\r\n        \"RangeTo\": \"22249.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_38\",\r\n        \"RangeFrom\": \"22250\",\r\n        \"RangeTo\": \"22749.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_39\",\r\n        \"RangeFrom\": \"22750\",\r\n        \"RangeTo\": \"23249.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_40\",\r\n        \"RangeFrom\": \"23250\",\r\n        \"RangeTo\": \"23749.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_41\",\r\n        \"RangeFrom\": \"23750\",\r\n        \"RangeTo\": \"24249.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_42\",\r\n        \"RangeFrom\": \"24250\",\r\n        \"RangeTo\": \"24749.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_43\",\r\n        \"RangeFrom\": \"24750\",\r\n        \"RangeTo\": \"25249.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_44\",\r\n        \"RangeFrom\": \"25250\",\r\n        \"RangeTo\": \"25749.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_45\",\r\n        \"RangeFrom\": \"25750\",\r\n        \"RangeTo\": \"26249.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_46\",\r\n        \"RangeFrom\": \"26250\",\r\n        \"RangeTo\": \"26749.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_47\",\r\n        \"RangeFrom\": \"26750\",\r\n        \"RangeTo\": \"27249.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_48\",\r\n        \"RangeFrom\": \"27250\",\r\n        \"RangeTo\": \"27749.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_49\",\r\n        \"RangeFrom\": \"27750\",\r\n        \"RangeTo\": \"28249.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_50\",\r\n        \"RangeFrom\": \"28250\",\r\n        \"RangeTo\": \"28749.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_51\",\r\n        \"RangeFrom\": \"28750\",\r\n        \"RangeTo\": \"29249.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_52\",\r\n        \"RangeFrom\": \"29250\",\r\n        \"RangeTo\": \"29749.99\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    },\r\n    {\r\n        \"Code\": \"SSS_53\",\r\n        \"RangeFrom\": \"29750\",\r\n        \"RangeTo\": \"1000000\",\r\n        \"ER\": \"1,900.00\",\r\n        \"EE\": \"900\",\r\n        \"EC\": \"30\"\r\n    }\r\n]";
                    var sstableList = JsonConvert.DeserializeObject<List<SSSTable>>(data);

                    foreach(var item in sstableList)
                    {
                        var exist = appContext.SSSTable.Where(f => f.Code.Equals(item.Code)).Any();
                        if (!exist)
                            appContext.SSSTable.Add(new SSSTable
                            {
                                Code = item.Code,
                                RangeFrom = item.RangeFrom,
                                RangeTo = item.RangeTo,
                                EC = item.EC,
                                ER = item.ER,
                                EE = item.EE,
                                Active = true
                            });
                    }

                    appContext.SaveChanges();
                }
            }
            return application;
        }
    }
}
