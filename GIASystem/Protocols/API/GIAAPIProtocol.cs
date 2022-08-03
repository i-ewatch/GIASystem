using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NModbus;
using RestSharp;
using Serilog;
using System;

namespace GIASystem.Protocols.API
{
    public class GIAAPIProtocol : GIAAPIData
    {
        public override void DataAPIReader()
        {
            try
            {
                var option = new RestClientOptions($"{GIALocation}")
                {
                    MaxTimeout = APItime
                };
                clinet = new RestClient(option);
                var requsest = new RestRequest("", Method.Get);
                var response = clinet.ExecuteGetAsync<GIAAPIValue>(requsest);
                response.Wait();
                if (response != null)
                {
                    JObject jsondata = JsonConvert.DeserializeObject<JObject>(response.Result.Content);
                    if (jsondata != null)
                    {
                        JArray jsonArraydata = JsonConvert.DeserializeObject<JArray>(jsondata["data"].ToString());
                        GIAAPIValue Value = JsonConvert.DeserializeObject<GIAAPIValue>(jsonArraydata[0]["sensors"].ToString());
                        GIAAPIValue = Value;
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
                Log.Error(ex, "GIA API通訊錯誤");
            }
        }

        public override void DataReader(IModbusMaster master) { }
    }
}
