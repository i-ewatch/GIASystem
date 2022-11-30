using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NModbus;
using RestSharp;
using Serilog;
using System;
using System.Collections.Generic;

namespace GIASystem.Protocols.API
{
    public class GIAElectricProtocol : GIAElectricData
    {
        public override void DataAPIReader()
        {
            try
            {
                var option = new RestClientOptions($"{GIAElectricLocation}")
                {
                    MaxTimeout = APItime
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync(requsest);
                response.Wait();
                if (response != null)
                {
                    JObject jsondata = JsonConvert.DeserializeObject<JObject>(response.Result.Content);
                    if (jsondata != null)
                    {
                        JArray jsonArraydata = JsonConvert.DeserializeObject<JArray>(jsondata["data"].ToString());
                        PriceRate = Convert.ToDecimal(jsonArraydata[0]["settings"]["pms"]["priceRate"].ToString());
                        Hour_Total_kWh = Convert.ToDecimal(jsonArraydata[0]["settings"]["pms"]["summary"]["hourOffset"].ToString());
                        Month_Total_kWh = Convert.ToDecimal(jsonArraydata[0]["settings"]["pms"]["summary"]["monthOffset"].ToString());
                        Day_Total_kWh = Convert.ToDecimal(jsonArraydata[0]["settings"]["pms"]["summary"]["dayOffset"].ToString());
                        List<GroupkWh> groupkWhs = new List<GroupkWh>();
                        foreach (var groupitem in (JArray)jsonArraydata[0]["settings"]["pms"]["group"])
                        {
                            GroupkWh group = new GroupkWh();
                            group.Name = groupitem["alias"].ToString();
                            group.Hour_Total_kWh = Convert.ToDecimal(groupitem["summary"]["hourOffset"].ToString());
                            group.Month_Total_kWh = Convert.ToDecimal(groupitem["summary"]["monthOffset"].ToString());
                            group.Day_Total_kWh = Convert.ToDecimal(groupitem["summary"]["dayOffset"].ToString());
                            foreach (var item in (JArray)groupitem["cts"])
                            {
                                ItemkWh itemkWh = new ItemkWh();
                                itemkWh.Name = item["alias"].ToString();
                                itemkWh.Hour_Total_kWh = Convert.ToDecimal(item["summary"]["hourOffset"].ToString());
                                itemkWh.Month_Total_kWh = Convert.ToDecimal(item["summary"]["monthOffset"].ToString());
                                itemkWh.Day_Total_kWh = Convert.ToDecimal(item["summary"]["dayOffset"].ToString());
                                group.ItemkWhs.Add(itemkWh);
                            }
                            groupkWhs.Add(group);
                        }
                        GroupkWhs = groupkWhs;
                        ConnectFlag = true;
                    }
                    else
                    {
                        ConnectFlag = false;
                    }
                }
            }
            catch (Exception ex)
            {
                ConnectFlag = false;
                Log.Error(ex, "GIA 電表API通訊錯誤");
            }
        }

        public override void DataReader(IModbusMaster master) { }
    }
}
