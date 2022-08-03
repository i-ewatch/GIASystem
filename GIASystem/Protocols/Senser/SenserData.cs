namespace GIASystem.Protocols.Senser
{
    public abstract class SenserData : AbsProtocol
    {
        /// <summary>
        /// 溫度
        /// </summary>
        public float Temperature { get; set; }
        /// <summary>
        /// 濕度
        /// </summary>
        public float Humidity { get; set; }
        /// <summary>
        /// 超細懸浮微粒
        /// </summary>
        public float PM1 { get; set; }
        /// <summary>
        /// 懸浮微粒
        /// </summary>
        public float PM25 { get; set; }
        /// <summary>
        /// 細懸浮微粒
        /// </summary>
        public float PM10 { get; set; }
        /// <summary>
        /// 二氧化碳
        /// </summary>
        public float CO2 { get; set; }
        /// <summary>
        /// 揮發性有機物
        /// </summary>
        public float TVOC { get; set; }
        /// <summary>
        /// 甲醛
        /// </summary>
        public float HCHO { get; set; }
        /// <summary>
        /// 臭氧
        /// </summary>
        public float O3 { get; set; }
        /// <summary>
        /// 一氧化碳
        /// </summary>
        public float CO { get; set; }
        /// <summary>
        /// 黴菌
        /// </summary>
        public float Mold { get; set; }
        /// <summary>
        /// 室內指數
        /// </summary>
        public float IAQ { get; set; }
    }
}
