using Newtonsoft.Json;
using NModbus;
using RestSharp;
using Serilog;
using System;
using System.Linq;

namespace GIASystem.Protocols.API
{
    public class WeatherProtocol : WeatherData
    {
        public override void DataAPIReader()
        {
            switch (WeatherIndex)
            {
                case 0:
                    {
                        try
                        {
                            if (GateWaySetting.GateWays[0].DistrictName != "")
                            {
                                var Taiwan_DistricsSetting = Taiwan_DistricsSettings.SingleOrDefault(g => g.CityName == GateWaySetting.GateWays[0].LocationName);
                                if (Taiwan_DistricsSetting.dataid != "")
                                {
                                    var option = new RestClientOptions($"http://ewatchcwpfunctionapi.azurewebsites.net/api/EwatchCwpFunctionApi?" + $"resource_id={Taiwan_DistricsSetting.dataid}&geocode={GateWaySetting.GateWays[0].DistrictName}")
                                    {
                                        MaxTimeout = APItime
                                    };
                                    clinet = new RestClient(option);
                                    var requsest = new RestRequest("", Method.Get);
                                    var response = clinet.ExecuteGetAsync<EwatchWeather>(requsest);
                                    response.Wait();
                                    if (response != null)
                                    {
                                        EwatchWeather = JsonConvert.DeserializeObject<EwatchWeather>(response.Result.Content);
                                        ConnectFlag = true;
                                    }
                                    else
                                    {
                                        ConnectFlag = false;
                                    }
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
                            Log.Error(ex, "新茂天氣資訊錯誤");
                        }
                    }
                    break;
                case 1:
                    {
                        try
                        {
                            var gIA_DistricsSetting = GIA_DistricsSetting.data.SingleOrDefault(g => g.alias == GateWaySetting.GateWays[0].DistrictName);
                            if (gIA_DistricsSetting != null)
                            {
                                var option = new RestClientOptions($"https://api.ecobear.tw/gia/78ga87outdoor/query.php?" + $"uuid={gIA_DistricsSetting.uuid}")
                                {
                                    MaxTimeout = APItime
                                };
                                clinet = new RestClient(option);
                                var requsest = new RestRequest("", Method.Get);
                                var response = clinet.ExecuteGetAsync<GIAWeatherData>(requsest);
                                response.Wait();
                                if (response != null)
                                {
                                    GIAWeatherData = JsonConvert.DeserializeObject<GIAWeatherData>(response.Result.Content);
                                    ConnectFlag = true;
                                }
                                else
                                {
                                    ConnectFlag = false;
                                }
                            }
                            else
                            {
                                ConnectFlag = false;
                            }
                        }
                        catch (Exception ex)
                        {
                            ConnectFlag = false;
                            Log.Error(ex, "欣寶天氣資訊錯誤");
                        }
                    }
                    break;
            }
        }

        public override void DataReader(IModbusMaster master) { }
    }
}
