using System;

namespace GIASystem.Protocols.API
{
    public abstract class WeatherData : AbsProtocol
    {
        public EwatchWeather EwatchWeather { get; set; } = new EwatchWeather();
        public GIAWeatherData GIAWeatherData { get; set; } = new GIAWeatherData();
    }
    #region 新茂天氣資訊
    public class EwatchWeather
    {
        /// <summary>
        /// 時間格式
        /// </summary>
        public DateTime ttimen { get; set; }
        /// <summary>
        /// 時間字串
        /// </summary>
        public string ttime { get; set; }
        /// <summary>
        /// 縣市代碼
        /// </summary>
        public string resource_id { get; set; }
        /// <summary>
        /// 鄉區代碼
        /// </summary>
        public string geocode { get; set; }
        public double pop12h { get; set; }
        /// <summary>
        /// 天氣資訊
        /// </summary>
        public string wx { get; set; }
        /// <summary>
        /// 天氣資訊代碼
        /// </summary>
        public int wx_Code { get; set; }
        public double at { get; set; }
        /// <summary>
        /// 溫度
        /// </summary>
        public double t { get; set; }
        /// <summary>
        /// 相對溼度
        /// </summary>
        public double rh { get; set; }
        public double ci { get; set; }
        /// <summary>
        /// 天氣描述
        /// </summary>
        public string weatherDescription { get; set; }
        public double pop6h { get; set; }
        public double ws { get; set; }
        public string wd { get; set; }
        public double td { get; set; }
    }
    #endregion

    #region 欣寶天氣資訊
    public class GIAWeatherData
    {
        public GIAweatherData data { get; set; }
        public string ret { get; set; }
        public string retDescription { get; set; }
    }

    public class GIAweatherData
    {
        public int tick { get; set; }
        public string alias { get; set; }
        public string uuid { get; set; }
        public string engName { get; set; }
        public string County { get; set; }
        public string MajorPollutant { get; set; }
        public string Status { get; set; }
        public string pm25 { get; set; }
        public string pm10 { get; set; }
        public string temperature { get; set; }
        public string humidity { get; set; }
        public string co { get; set; }
        public string iaq { get; set; }
        public string o3 { get; set; }
        public string so2 { get; set; }
        public string no2 { get; set; }
        public string windSpeed { get; set; }
        public string windDirec { get; set; }
        public string pressure { get; set; }
        public string attribution { get; set; }
    }
    #endregion
}
