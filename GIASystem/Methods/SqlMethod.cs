using Dapper;
using GIASystem.Configuration;
using GIASystem.EF_Modules;
using GIASystem.Enums;
using GIASystem.Protocols.ElectricMeter;
using GIASystem.Protocols.Senser;
using MySql.Data.MySqlClient;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace GIASystem.Methods
{
    public class SqlMethod
    {
        /// <summary>
        /// 電表相位角
        /// <para> 0 = R </para>
        /// <para> 1 = S </para>
        /// <para> 2 = T </para>
        /// </summary>
        private PhaseAngleEnumType PhaseAngleEnumType { get; set; }
        /// <summary>
        /// server資料庫連結資訊
        /// </summary>
        public MySqlConnectionStringBuilder Serverscsb { get; set; }
        /// <summary>
        /// MariaDB資料庫連結資訊
        /// </summary>
        public MySqlConnectionStringBuilder myscbs { get; set; }
        /// <summary>
        /// 資料庫JSON
        /// </summary>
        public SqlDBSetting setting { get; set; }
        #region 資料庫連結
        /// <summary>
        /// EF資料庫連結
        /// </summary>
        /// <param name="DataBaseType">資料庫類型</param>
        public void SQLConnect()
        {
            Serverscsb = new MySqlConnectionStringBuilder()
            {
                Server = setting.DataSource,
                Database = "mysql",
                UserID = setting.UserID,
                Password = setting.Password,
                CharacterSet = "utf8"
            };
            myscbs = new MySqlConnectionStringBuilder()
            {
                Database = setting.InitialCatalog,
                Server = setting.DataSource,
                UserID = setting.UserID,
                Password = setting.Password,
                CharacterSet = "utf8"
            };
        }
        #endregion

        #region  檢查資料庫是否存在
        /// <summary>
        /// 檢查資料庫是否存在
        /// </summary>
        /// <returns></returns>
        public bool Check_Datebase()
        {
            bool ExistFlag = false;
            string sql = string.Empty;
            try
            {
                using (var conn = new MySqlConnection(Serverscsb.ConnectionString))
                {
                    sql = $"SHOW DATABASES LIKE '{setting.InitialCatalog}'";
                    var Exist = conn.Query(sql).ToList();
                    if (Exist.Count > 0) { ExistFlag = true; }
                    else { ExistFlag = false; }
                }
            }
            catch (Exception ex) { Log.Error(ex, "無 MariaDB Server"); }
            return ExistFlag;
        }
        #endregion

        #region 電表基本資訊更新 
        /// <summary>
        /// 電表基本資訊更新 
        /// </summary>
        /// <param name="electricIDs"></param>
        public void Insert_ElectricConfig(GroupSetting groupSetting, List<GateWay> gateWay)
        {
            string Checksql = string.Empty;
            string Updatasql = string.Empty;
            string Insertsql = string.Empty;

            using (var conn = new MySqlConnection(myscbs.ConnectionString))
            {
                foreach (var electricitem in groupSetting.ElectricDevices)
                {
                    var gatewaydata = gateWay.SingleOrDefault(g => g.GatewayIndex == electricitem.GatewayIndex);
                    if (gatewaydata != null)
                    {
                        var electricdata = gatewaydata.GateWayElectricIDs.SingleOrDefault(g => g.DeviceID == electricitem.DeviceID);
                        if (electricdata != null)
                        {
                            Checksql = $"SELECT * FROM ElectricConfig WHERE GatewayIndex = {electricitem.GatewayIndex} AND DeviceIndex = {electricitem.DeviceIndex} ";
                            var Exist = conn.Query<ElectricConfig>(Checksql).ToList();
                            if (Exist.Count > 0)
                            {
                                Updatasql = $"UPDATE ElectricConfig SET " +
                                            $"TotalMeterFlag = {electricitem.TotalMeterFlag}, " +
                                            $"DeviceID = {electricitem.DeviceID}, " +
                                            $"ElectricEnumType={electricdata.ElectricEnumType}, " +
                                            $"LoopEnumType={electricitem.LoopEnumType}, " +
                                            $"PhaseEnumType = {electricitem.PhaseEnumType}, " +
                                            $"PhaseAngleEnumType = {electricitem.PhaseAngleEnumType}, " +
                                            $"DeviceName = N'{electricitem.DeviceName}'" +
                                            $" WHERE GatewayIndex ={electricitem.GatewayIndex} AND DeviceIndex = {electricitem.DeviceIndex}";
                                conn.Execute(Updatasql);
                            }
                            else
                            {
                                Insertsql = $"INSERT INTO {setting.InitialCatalog}.ElectricConfig (TotalMeterFlag,GatewayIndex,DeviceIndex,DeviceID,ElectricEnumType,LoopEnumType,PhaseEnumType,PhaseAngleEnumType,DeviceName)VALUES" +
                                            $"({electricitem.TotalMeterFlag},{electricitem.GatewayIndex},{electricitem.DeviceIndex},{electricitem.DeviceID},{electricdata.ElectricEnumType},{electricitem.LoopEnumType},{electricitem.PhaseEnumType},{electricitem.PhaseAngleEnumType},N'{electricitem.DeviceName}')";
                                conn.Execute(Insertsql);
                            }
                        }
                    }
                }
            }
        }
        #endregion

        #region 感測器基本資訊更新 
        /// <summary>
        /// 感測器基本資訊更新 
        /// </summary>
        /// <param name="electricIDs"></param>
        public void Insert_SenserConfig(List<GateWay> gateWays)
        {
            string Checksql = string.Empty;
            string Updatasql = string.Empty;
            string Insertsql = string.Empty;
            using (var conn = new MySqlConnection(myscbs.ConnectionString))
            {
                foreach (var gateitem in gateWays)
                {
                    foreach (var senseritem in gateitem.GateWaySenserIDs)
                    {
                        Checksql = $"SELECT * FROM SenserConfig WHERE GatewayIndex = {gateitem.GatewayIndex} AND DeviceIndex = {senseritem.DeviceIndex} ";
                        var Exist = conn.Query<ElectricConfig>(Checksql).ToList();
                        if (Exist.Count > 0)
                        {
                            Updatasql = $"UPDATE SenserConfig SET " +
                                        $"DeviceID = {senseritem.DeviceID}, " +
                                        $"SenserEnumType = {senseritem.SenserEnumType}, " +
                                        $"DeviceName = N'{senseritem.DeviceName}'" +
                                        $" WHERE GatewayIndex ={gateitem.GatewayIndex} AND DeviceIndex = {senseritem.DeviceIndex}";
                            conn.Execute(Updatasql);
                        }
                        else
                        {
                            Insertsql = $"INSERT INTO {setting.InitialCatalog}.SenserConfig (GatewayIndex,DeviceIndex,DeviceID,SenserEnumType,DeviceName)VALUES" +
                                        $"({gateitem.GatewayIndex},{senseritem.DeviceIndex},{senseritem.DeviceID},{senseritem.SenserEnumType},N'{senseritem.DeviceName}')";
                            conn.Execute(Insertsql);
                        }
                    }
                }
            }
        }
        #endregion

        #region 更新三相電表 ForWeb、Log與預存程序
        /// <summary>
        /// 更新三相電表 ForWeb與Log
        /// </summary>
        /// <param name="data"></param>
        public void Insert_ThreePhaseElectricMeter(ElectricMeterData data, ElectricDevice electricDevice)
        {
            DateTime ttimen = DateTime.Now;
            string ttime = ttimen.ToString("yyyyMMddHHmmss");
            string Checksql = string.Empty;
            string UpdataForwebsql = string.Empty;
            string InsertForweb = string.Empty;
            string InsertLogsql = string.Empty;
            string Proceduresql = string.Empty;
            string Proceduresql1 = string.Empty;
            string Checksql_Log = string.Empty;
            Checksql = $"SELECT * FROM ThreePhaseElectricMeter_ForWeb WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex}";
            Checksql_Log = $"SELECT * FROM ThreePhaseElectricMeter_Log WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex} AND ttime = '{ttimen:yyyyMMddHHmm00}'";
            UpdataForwebsql = $"UPDATE ThreePhaseElectricMeter_ForWeb SET " +
                              $"ttime= '{ttime}'," +
                              $"ttimen = '{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}'," +
                              $"rv = {data.Rv}," +
                              $"sv={data.Sv}," +
                              $"tv={data.Tv}," +
                              $"rsv = {data.RSv}," +
                              $"stv = {data.STv}," +
                              $"trv = {data.TRv}," +
                              $"ra={data.RA}," +
                              $"sa={data.SA}," +
                              $"ta={data.TA}," +
                              $"kw = {data.kW}," +
                              $"kwh = {data.kWh}," +
                              $"kvar={data.kVAR}," +
                              $"kvarh={data.kVARh}," +
                              $"kva={data.kVA}," +
                              $"kvah={data.kVAh}," +
                              $"pfe = {data.PF}," +
                              $"hz={data.HZ} " +
                              $"WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex} ";
            InsertForweb = $"INSERT INTO {setting.InitialCatalog}.ThreePhaseElectricMeter_ForWeb (ttime,ttimen,GatewayIndex,DeviceIndex,rv,sv,tv,rsv,stv,trv,ra,sa,ta,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                        $"'{ttime}','{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Rv},{data.Sv},{data.Tv},{data.RSv},{data.STv},{data.TRv},{data.RA},{data.SA},{data.TA},{data.kW},{data.kWh},{data.kVAR},{data.kVARh},{data.PF},{data.kVA},{data.kVAh},{data.HZ})";
            InsertLogsql = $"INSERT INTO {setting.InitialCatalog}.ThreePhaseElectricMeter_Log (ttime,ttimen,GatewayIndex,DeviceIndex,rv,sv,tv,rsv,stv,trv,ra,sa,ta,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                        $"'{ttimen:yyyyMMddHHmm00}','{ttimen.ToString("yyyy/MM/dd HH:mm:00")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Rv},{data.Sv},{data.Tv},{data.RSv},{data.STv},{data.TRv},{data.RA},{data.SA},{data.TA},{data.kW},{data.kWh},{data.kVAR},{data.kVARh},{data.PF},{data.kVA},{data.kVAh},{data.HZ})";
            using (var conn = new MySqlConnection(myscbs.ConnectionString))
            {
                //Proceduresql = $"CALL ElectricdailykwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.kWh})";//三段電價
                Proceduresql1 = $"CALL ElectricGeneralkwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.kWh})";//一般電價

                var Exist = conn.Query<ThreePhaseElectricMeter>(Checksql).ToList();
                if (Exist.Count > 0)
                {
                    conn.Execute(UpdataForwebsql);
                    Thread.Sleep(10);
                }
                else
                {
                    conn.Execute(InsertForweb);
                    Thread.Sleep(10);
                }
                var Exist_Log = conn.Query<ThreePhaseElectricMeter>(Checksql_Log).ToList();
                if (Exist_Log.Count == 0)
                {
                    conn.Execute(InsertLogsql);
                    Thread.Sleep(10);
                }
                //conn.Execute(Proceduresql);
                //Thread.Sleep(10);
                conn.Execute(Proceduresql1);

            }
        }
        #endregion

        #region 更新三相電表(單相使用) ForWeb、Log與預存程序
        /// <summary>
        /// 更新三相電表(單相使用) ForWeb與Log
        /// </summary>
        /// <param name="data"></param>
        public void Insert_SinglePhaseElectricMeter(ElectricMeterData data, ElectricDevice electricDevice)
        {
            DateTime ttimen = DateTime.Now;
            string ttime = ttimen.ToString("yyyyMMddHHmmss");
            string Checksql = string.Empty;
            string Checksql_Log = string.Empty;
            string UpdataForwebsql = string.Empty;
            string InsertForweb = string.Empty;
            string InsertLogsql = string.Empty;
            string Proceduresql = string.Empty;
            string Proceduresql1 = string.Empty;
            Checksql = $"SELECT * FROM SinglePhaseElectricMeter_ForWeb WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex}";
            Checksql_Log = $"SELECT * FROM SinglePhaseElectricMeter_Log WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex} AND ttime = '{ttimen:yyyyMMddHHmm00}'";
            PhaseAngleEnumType = (PhaseAngleEnumType)electricDevice.PhaseAngleEnumType;
            switch (PhaseAngleEnumType)
            {
                case PhaseAngleEnumType.R:
                    {
                        UpdataForwebsql = $"UPDATE SinglePhaseElectricMeter_ForWeb SET " +
                             $"ttime= '{ttime}'," +
                             $"ttimen = '{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}'," +
                             $"v = {data.Rv}," +
                             $"a={data.RA}," +
                             $"kw = {data.kWh_A}," +
                             $"kwh = {data.kWh_A}," +
                             $"kvar={data.kVAR_A}," +
                             $"kvarh={data.kVARh_A}," +
                             $"kva={data.kVA_A}," +
                             $"kvah={data.kVAh_A}," +
                             $"pfe = {data.PF_A}," +
                             $"hz={data.HZ} " +
                             $"WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex}";
                        InsertForweb = $"INSERT INTO {setting.InitialCatalog}.SinglePhaseElectricMeter_ForWeb (ttime,ttimen,GatewayIndex,DeviceIndex,v,a,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                                    $"'{ttime}','{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Rv},{data.RA},{data.kW_A},{data.kWh_A},{data.kVAR_A},{data.kVARh_A},{data.PF_A},{data.kVA_A},{data.kVAh_A},{data.HZ})";
                        InsertLogsql = $"INSERT INTO {setting.InitialCatalog}.SinglePhaseElectricMeter_Log (ttime,ttimen,GatewayIndex,DeviceIndex,v,a,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                                    $"'{ttimen:yyyyMMddHHmm00}','{ttimen.ToString("yyyy/MM/dd HH:mm:00")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Rv},{data.RA},{data.kW_A},{data.kWh_A},{data.kVAR_A},{data.kVARh_A},{data.PF_A},{data.kVA_A},{data.kVAh_A},{data.HZ})";
                    }
                    break;
                case PhaseAngleEnumType.S:
                    {
                        UpdataForwebsql = $"UPDATE SinglePhaseElectricMeter_ForWeb SET " +
                             $"ttime= '{ttime}'," +
                             $"ttimen = '{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}'," +
                             $"v = {data.Sv}," +
                             $"a={data.SA}," +
                             $"kw = {data.kWh_B}," +
                             $"kwh = {data.kWh_B}," +
                             $"kvar={data.kVAR_B}," +
                             $"kvarh={data.kVARh_B}," +
                             $"kva={data.kVA_B}," +
                             $"kvah={data.kVAh_B}," +
                             $"pfe = {data.PF_B}," +
                             $"hz={data.HZ} " +
                             $"WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex}";
                        InsertForweb = $"INSERT INTO {setting.InitialCatalog}.SinglePhaseElectricMeter_ForWeb (ttime,ttimen,GatewayIndex,DeviceIndex,v,a,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                                    $"'{ttime}','{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Sv},{data.SA},{data.kW_B},{data.kWh_B},{data.kVAR_B},{data.kVARh_B},{data.PF_B},{data.kVA_B},{data.kVAh_B},{data.HZ})";
                        InsertLogsql = $"INSERT INTO {setting.InitialCatalog}.SinglePhaseElectricMeter_Log (ttime,ttimen,GatewayIndex,DeviceIndex,v,a,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                                    $"'{ttimen:yyyyMMddHHmm00}','{ttimen.ToString("yyyy/MM/dd HH:mm:00")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Sv},{data.SA},{data.kW_B},{data.kWh_B},{data.kVAR_B},{data.kVARh_B},{data.PF_B},{data.kVA_B},{data.kVAh_B},{data.HZ})";
                    }
                    break;
                case PhaseAngleEnumType.T:
                    {
                        UpdataForwebsql = $"UPDATE SinglePhaseElectricMeter_ForWeb SET " +
                             $"ttime= '{ttime}'," +
                             $"ttimen = '{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}'," +
                             $"v = {data.Tv}," +
                             $"a={data.TA}," +
                             $"kw = {data.kWh_C}," +
                             $"kwh = {data.kWh_C}," +
                             $"kvar={data.kVAR_C}," +
                             $"kvarh={data.kVARh_C}," +
                             $"kva={data.kVA_C}," +
                             $"kvah={data.kVAh_C}," +
                             $"pfe = {data.PF_C}," +
                             $"hz={data.HZ} " +
                             $"WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex}";
                        InsertForweb = $"INSERT INTO {setting.InitialCatalog}.SinglePhaseElectricMeter_ForWeb (ttime,ttimen,GatewayIndex,DeviceIndex,v,a,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                                    $"'{ttime}','{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Tv},{data.TA},{data.kW_C},{data.kWh_C},{data.kVAR_C},{data.kVARh_C},{data.PF_C},{data.kVA_C},{data.kVAh_C},{data.HZ})";
                        InsertLogsql = $"INSERT INTO {setting.InitialCatalog}.SinglePhaseElectricMeter_Log (ttime,ttimen,GatewayIndex,DeviceIndex,v,a,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                                    $"'{ttimen:yyyyMMddHHmm00}','{ttimen.ToString("yyyy/MM/dd HH:mm:00")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Tv},{data.TA},{data.kW_C},{data.kWh_C},{data.kVAR_C},{data.kVARh_C},{data.PF_C},{data.kVA_C},{data.kVAh_C},{data.HZ})";
                    }
                    break;
            }
            switch (PhaseAngleEnumType)
            {
                case PhaseAngleEnumType.R:
                    {
                        //Proceduresql = $"CALL ElectricdailykwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.kWh_A})";//三段電價
                        Proceduresql1 = $"CALL ElectricGeneralkwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.kWh_A})";//一般電價
                    }
                    break;
                case PhaseAngleEnumType.S:
                    {
                        //Proceduresql = $"CALL ElectricdailykwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.kWh_B})";//三段電價
                        Proceduresql1 = $"CALL ElectricGeneralkwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.kWh_B})";//一般電價
                    }
                    break;
                case PhaseAngleEnumType.T:
                    {
                        //Proceduresql = $"CALL ElectricdailykwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.kWh_C})";//三段電價
                        Proceduresql1 = $"CALL ElectricGeneralkwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.kWh_C})";//一般電價
                    }
                    break;
            }

            using (var conn = new MySqlConnection(myscbs.ConnectionString))
            {
                var Exist = conn.Query<SinglePhaseElectricMeterLog>(Checksql).ToList();
                if (Exist.Count > 0)
                {
                    conn.Execute(UpdataForwebsql);
                    Thread.Sleep(10);
                }
                else
                {
                    conn.Execute(InsertForweb);
                    Thread.Sleep(10);
                }
                var Exist_Log = conn.Query<SinglePhaseElectricMeterLog>(Checksql_Log).ToList();
                if (Exist_Log.Count == 0)
                {
                    conn.Execute(InsertLogsql);
                    Thread.Sleep(10);
                }
                //conn.Execute(Proceduresql);
                //Thread.Sleep(10);
                conn.Execute(Proceduresql1);
            }
        }
        #endregion

        #region 更新多迴路電表(三相使用) ForWeb、Log與預存程序
        /// <summary>
        /// 更新多迴路電表(三相使用) ForWeb與Log
        /// </summary>
        /// <param name="data"></param>
        public void Insert_ThreePhaseElectricMeter(MultiCircuitElectricMeterData data, ElectricDevice electricDevice)
        {
            DateTime ttimen = DateTime.Now;
            string ttime = ttimen.ToString("yyyyMMddHHmmss");
            string Checksql = string.Empty;
            string UpdataForwebsql = string.Empty;
            string InsertForweb = string.Empty;
            string InsertLogsql = string.Empty;
            string Proceduresql = string.Empty;
            string Proceduresql1 = string.Empty;
            string Checksql_Log = string.Empty;
            Checksql = $"SELECT * FROM ThreePhaseElectricMeter_ForWeb WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex}";
            Checksql_Log = $"SELECT * FROM ThreePhaseElectricMeter_Log WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex} AND ttime = '{ttimen:yyyyMMddHHmm00}'";
            UpdataForwebsql = $"UPDATE ThreePhaseElectricMeter_ForWeb SET " +
                              $"ttime= '{ttime}'," +
                              $"ttimen = '{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}'," +
                              $"rv = {data.Rv[electricDevice.LoopEnumType]}," +
                              $"sv={data.Sv[electricDevice.LoopEnumType]}," +
                              $"tv={data.Tv[electricDevice.LoopEnumType]}," +
                              $"rsv = {data.RSv[electricDevice.LoopEnumType]}," +
                              $"stv = {data.STv[electricDevice.LoopEnumType]}," +
                              $"trv = {data.TRv[electricDevice.LoopEnumType]}," +
                              $"ra={data.RA[electricDevice.LoopEnumType]}," +
                              $"sa={data.SA[electricDevice.LoopEnumType]}," +
                              $"ta={data.TA[electricDevice.LoopEnumType]}," +
                              $"kw = {data.kW[electricDevice.LoopEnumType]}," +
                              $"kwh = {data.kWh[electricDevice.LoopEnumType]}," +
                              $"kvar={data.kVAR[electricDevice.LoopEnumType]}," +
                              $"kvarh={data.kVARh[electricDevice.LoopEnumType]}," +
                              $"kva={data.kVA[electricDevice.LoopEnumType]}," +
                              $"kvah={data.kVAh[electricDevice.LoopEnumType]}," +
                              $"pfe = {data.PF[electricDevice.LoopEnumType]}," +
                              $"hz={data.HZ[electricDevice.LoopEnumType]} " +
                              $"WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex}";
            InsertForweb = $"INSERT INTO {setting.InitialCatalog}.ThreePhaseElectricMeter_ForWeb (ttime,ttimen,GatewayIndex,DeviceIndex,rv,sv,tv,rsv,stv,trv,ra,sa,ta,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                        $"'{ttime}','{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Rv[electricDevice.LoopEnumType]},{data.Sv[electricDevice.LoopEnumType]},{data.Tv[electricDevice.LoopEnumType]},{data.RSv[electricDevice.LoopEnumType]},{data.STv[electricDevice.LoopEnumType]},{data.TRv[electricDevice.LoopEnumType]},{data.RA[electricDevice.LoopEnumType]},{data.SA[electricDevice.LoopEnumType]},{data.TA[electricDevice.LoopEnumType]},{data.kW[electricDevice.LoopEnumType]},{data.kWh[electricDevice.LoopEnumType]},{data.kVAR[electricDevice.LoopEnumType]},{data.kVARh[electricDevice.LoopEnumType]},{data.PF[electricDevice.LoopEnumType]},{data.kVA[electricDevice.LoopEnumType]},{data.kVAh[electricDevice.LoopEnumType]},{data.HZ[electricDevice.LoopEnumType]})";
            InsertLogsql = $"INSERT INTO {setting.InitialCatalog}.ThreePhaseElectricMeter_Log (ttime,ttimen,GatewayIndex,DeviceIndex,rv,sv,tv,rsv,stv,trv,ra,sa,ta,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                        $"'{ttimen:yyyyMMddHHmm00}','{ttimen.ToString("yyyy/MM/dd HH:mm:00")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Rv[electricDevice.LoopEnumType]},{data.Sv[electricDevice.LoopEnumType]},{data.Tv[electricDevice.LoopEnumType]},{data.RSv[electricDevice.LoopEnumType]},{data.STv[electricDevice.LoopEnumType]},{data.TRv[electricDevice.LoopEnumType]},{data.RA[electricDevice.LoopEnumType]},{data.SA[electricDevice.LoopEnumType]},{data.TA[electricDevice.LoopEnumType]},{data.kW[electricDevice.LoopEnumType]},{data.kWh[electricDevice.LoopEnumType]},{data.kVAR[electricDevice.LoopEnumType]},{data.kVARh[electricDevice.LoopEnumType]},{data.PF[electricDevice.LoopEnumType]},{data.kVA[electricDevice.LoopEnumType]},{data.kVAh[electricDevice.LoopEnumType]},{data.HZ[electricDevice.LoopEnumType]})";
            using (var conn = new MySqlConnection(myscbs.ConnectionString))
            {
                //Proceduresql = $"CALL ElectricdailykwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.kWh[electricDevice.LoopEnumType]})";//三段電價
                Proceduresql1 = $"CALL ElectricGeneralkwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.kWh[electricDevice.LoopEnumType]})";//一般電價
                var Exist = conn.Query<ThreePhaseElectricMeter>(Checksql).ToList();
                if (Exist.Count > 0)
                {
                    conn.Execute(UpdataForwebsql);
                    Thread.Sleep(10);
                }
                else
                {
                    conn.Execute(InsertForweb);
                    Thread.Sleep(10);
                }
                var Exist_Log = conn.Query<ThreePhaseElectricMeter>(Checksql_Log).ToList();
                if (Exist_Log.Count == 0)
                {
                    conn.Execute(InsertLogsql);
                    Thread.Sleep(10);
                }
                //conn.Execute(Proceduresql);
                //Thread.Sleep(10);
                conn.Execute(Proceduresql1);
            }

        }
        #endregion

        #region 更新多迴路電表(單相使用) ForWeb、Log與預存程序
        /// <summary>
        /// 更新三相電表(單相使用) ForWeb與Log
        /// </summary>
        /// <param name="data"></param>
        public void Insert_SinglePhaseElectricMeter(MultiCircuitElectricMeterData data, ElectricDevice electricDevice)
        {
            DateTime ttimen = DateTime.Now;
            string ttime = ttimen.ToString("yyyyMMddHHmmss");
            string Checksql = string.Empty;
            string Checksql_Log = string.Empty;
            string UpdataForwebsql = string.Empty;
            string InsertForweb = string.Empty;
            string InsertLogsql = string.Empty;
            string Proceduresql = string.Empty;
            string Proceduresql1 = string.Empty;
            Checksql = $"SELECT * FROM SinglePhaseElectricMeter_ForWeb WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex}";
            Checksql_Log = $"SELECT * FROM SinglePhaseElectricMeter_Log WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex} AND ttime = '{ttimen:yyyyMMddHHmm00}'";
            PhaseAngleEnumType = (PhaseAngleEnumType)electricDevice.PhaseAngleEnumType;
            switch (PhaseAngleEnumType)
            {
                case PhaseAngleEnumType.R:
                    {
                        UpdataForwebsql = $"UPDATE SinglePhaseElectricMeter_ForWeb SET " +
                             $"ttime= '{ttime}'," +
                             $"ttimen = '{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}'," +
                             $"v = {data.Rv[electricDevice.LoopEnumType]}," +
                             $"a={data.RA[electricDevice.LoopEnumType]}," +
                             $"kw = {data.R_kW[electricDevice.LoopEnumType]}," +
                             $"kwh = {data.R_kWh[electricDevice.LoopEnumType]}," +
                             $"kvar={data.R_kVAR[electricDevice.LoopEnumType]}," +
                             $"kvarh={data.R_kVARh[electricDevice.LoopEnumType]}," +
                             $"kva={data.R_kVA[electricDevice.LoopEnumType]}," +
                             $"kvah={data.R_kVAh[electricDevice.LoopEnumType]}," +
                             $"pfe = {data.R_PF[electricDevice.LoopEnumType]}," +
                             $"hz={data.HZ[electricDevice.LoopEnumType]} " +
                             $"WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex}";
                        InsertForweb = $"INSERT INTO {setting.InitialCatalog}.SinglePhaseElectricMeter_ForWeb (ttime,ttimen,GatewayIndex,DeviceIndex,v,a,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                                    $"'{ttime}','{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Rv[electricDevice.LoopEnumType]},{data.RA[electricDevice.LoopEnumType]},{data.R_kW[electricDevice.LoopEnumType]},{data.R_kWh[electricDevice.LoopEnumType]},{data.R_kVAR[electricDevice.LoopEnumType]},{data.R_kVARh[electricDevice.LoopEnumType]},{data.R_PF[electricDevice.LoopEnumType]},{data.R_kVA[electricDevice.LoopEnumType]},{data.R_kVAh[electricDevice.LoopEnumType]},{data.HZ[electricDevice.LoopEnumType]})";
                        InsertLogsql = $"INSERT INTO {setting.InitialCatalog}.SinglePhaseElectricMeter_Log (ttime,ttimen,GatewayIndex,DeviceIndex,v,a,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                                    $"'{ttimen:yyyyMMddHHmm00}','{ttimen.ToString("yyyy/MM/dd HH:mm:00")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Rv[electricDevice.LoopEnumType]},{data.RA[electricDevice.LoopEnumType]},{data.R_kW[electricDevice.LoopEnumType]},{data.R_kWh[electricDevice.LoopEnumType]},{data.R_kVAR[electricDevice.LoopEnumType]},{data.R_kVARh[electricDevice.LoopEnumType]},{data.R_PF[electricDevice.LoopEnumType]},{data.R_kVA[electricDevice.LoopEnumType]},{data.R_kVAh[electricDevice.LoopEnumType]},{data.HZ[electricDevice.LoopEnumType]})";
                    }
                    break;
                case PhaseAngleEnumType.S:
                    {
                        UpdataForwebsql = $"UPDATE SinglePhaseElectricMeter_ForWeb SET " +
                             $"ttime= '{ttime}'," +
                             $"ttimen = '{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}'," +
                             $"v = {data.Sv[electricDevice.LoopEnumType]}," +
                             $"a={data.SA[electricDevice.LoopEnumType]}," +
                             $"kw = {data.S_kW[electricDevice.LoopEnumType]}," +
                             $"kwh = {data.S_kWh[electricDevice.LoopEnumType]}," +
                             $"kvar={data.S_kVAR[electricDevice.LoopEnumType]}," +
                             $"kvarh={data.S_kVARh[electricDevice.LoopEnumType]}," +
                             $"kva={data.S_kVA[electricDevice.LoopEnumType]}," +
                             $"kvah={data.S_kVAh[electricDevice.LoopEnumType]}," +
                             $"pfe = {data.S_PF[electricDevice.LoopEnumType]}," +
                             $"hz={data.HZ[electricDevice.LoopEnumType]} " +
                             $"WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex}";
                        InsertForweb = $"INSERT INTO {setting.InitialCatalog}.SinglePhaseElectricMeter_ForWeb (ttime,ttimen,GatewayIndex,DeviceIndex,v,a,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                                    $"'{ttime}','{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Sv[electricDevice.LoopEnumType]},{data.SA[electricDevice.LoopEnumType]},{data.S_kW[electricDevice.LoopEnumType]},{data.S_kWh[electricDevice.LoopEnumType]},{data.S_kVAR[electricDevice.LoopEnumType]},{data.S_kVARh[electricDevice.LoopEnumType]},{data.S_PF[electricDevice.LoopEnumType]},{data.S_kVA[electricDevice.LoopEnumType]},{data.S_kVAh[electricDevice.LoopEnumType]},{data.HZ[electricDevice.LoopEnumType]})";
                        InsertLogsql = $"INSERT INTO {setting.InitialCatalog}.SinglePhaseElectricMeter_Log (ttime,ttimen,GatewayIndex,DeviceIndex,v,a,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                                    $"'{ttimen:yyyyMMddHHmm00}','{ttimen.ToString("yyyy/MM/dd HH:mm:00")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Sv[electricDevice.LoopEnumType]},{data.SA[electricDevice.LoopEnumType]},{data.S_kW[electricDevice.LoopEnumType]},{data.S_kWh[electricDevice.LoopEnumType]},{data.S_kVAR[electricDevice.LoopEnumType]},{data.S_kVARh[electricDevice.LoopEnumType]},{data.S_PF[electricDevice.LoopEnumType]},{data.S_kVA[electricDevice.LoopEnumType]},{data.S_kVAh[electricDevice.LoopEnumType]},{data.HZ[electricDevice.LoopEnumType]})";
                    }
                    break;
                case PhaseAngleEnumType.T:
                    {
                        UpdataForwebsql = $"UPDATE SinglePhaseElectricMeter_ForWeb SET " +
                             $"ttime= '{ttime}'," +
                             $"ttimen = '{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}'," +
                             $"v = {data.Tv[electricDevice.LoopEnumType]}," +
                             $"a={data.TA[electricDevice.LoopEnumType]}," +
                             $"kw = {data.T_kW[electricDevice.LoopEnumType]}," +
                             $"kwh = {data.T_kWh[electricDevice.LoopEnumType]}," +
                             $"kvar={data.T_kVAR[electricDevice.LoopEnumType]}," +
                             $"kvarh={data.T_kVARh[electricDevice.LoopEnumType]}," +
                             $"kva={data.T_kVA[electricDevice.LoopEnumType]}," +
                             $"kvah={data.T_kVAh[electricDevice.LoopEnumType]}," +
                             $"pfe = {data.T_PF[electricDevice.LoopEnumType]}," +
                             $"hz={data.HZ[electricDevice.LoopEnumType]} " +
                             $"WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {electricDevice.DeviceIndex}";
                        InsertForweb = $"INSERT INTO {setting.InitialCatalog}.SinglePhaseElectricMeter_ForWeb (ttime,ttimen,GatewayIndex,DeviceIndex,v,a,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                                    $"'{ttime}','{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Tv[electricDevice.LoopEnumType]},{data.TA[electricDevice.LoopEnumType]},{data.T_kW[electricDevice.LoopEnumType]},{data.T_kWh[electricDevice.LoopEnumType]},{data.T_kVAR[electricDevice.LoopEnumType]},{data.T_kVARh[electricDevice.LoopEnumType]},{data.T_PF[electricDevice.LoopEnumType]},{data.T_kVA[electricDevice.LoopEnumType]},{data.T_kVAh[electricDevice.LoopEnumType]},{data.HZ[electricDevice.LoopEnumType]})";
                        InsertLogsql = $"INSERT INTO {setting.InitialCatalog}.SinglePhaseElectricMeter_Log (ttime,ttimen,GatewayIndex,DeviceIndex,v,a,kw,kwh,kvar,kvarh,pfe,kva,kvah,hz)VALUES(" +
                                    $"'{ttimen:yyyyMMddHHmm00}','{ttimen.ToString("yyyy/MM/dd HH:mm:00")}',{data.GatewayIndex},{electricDevice.DeviceIndex},{data.Tv[electricDevice.LoopEnumType]},{data.TA[electricDevice.LoopEnumType]},{data.T_kW[electricDevice.LoopEnumType]},{data.T_kWh[electricDevice.LoopEnumType]},{data.T_kVAR[electricDevice.LoopEnumType]},{data.T_kVARh[electricDevice.LoopEnumType]},{data.T_PF[electricDevice.LoopEnumType]},{data.T_kVA[electricDevice.LoopEnumType]},{data.T_kVAh[electricDevice.LoopEnumType]},{data.HZ[electricDevice.LoopEnumType]})";
                    }
                    break;
            }
            switch (PhaseAngleEnumType)
            {
                case PhaseAngleEnumType.R:
                    {
                        //Proceduresql = $"CALL ElectricdailykwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.R_kWh[electricDevice.LoopEnumType]})";//三段電價
                        Proceduresql1 = $"CALL ElectricGeneralkwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.R_kWh[electricDevice.LoopEnumType]})";//一般電價
                    }
                    break;
                case PhaseAngleEnumType.S:
                    {
                        //Proceduresql = $"CALL ElectricdailykwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.S_kWh[electricDevice.LoopEnumType]})";//三段電價
                        Proceduresql1 = $"CALL ElectricGeneralkwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.S_kWh[electricDevice.LoopEnumType]})";//一般電價
                    }
                    break;
                case PhaseAngleEnumType.T:
                    {
                        //Proceduresql = $"CALL ElectricdailykwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.T_kWh[electricDevice.LoopEnumType]})";//三段電價
                        Proceduresql1 = $"CALL ElectricGeneralkwhProcedure({ttime},{data.GatewayIndex},{electricDevice.DeviceIndex},{data.T_kWh[electricDevice.LoopEnumType]})";//一般電價
                    }
                    break;
            }
            using (var conn = new MySqlConnection(myscbs.ConnectionString))
            {
                PhaseAngleEnumType = (PhaseAngleEnumType)electricDevice.PhaseAngleEnumType;

                var Exist = conn.Query<SinglePhaseElectricMeterLog>(Checksql).ToList();
                if (Exist.Count > 0)
                {
                    conn.Execute(UpdataForwebsql);
                    Thread.Sleep(10);
                }
                else
                {
                    conn.Execute(InsertForweb);
                    Thread.Sleep(10);
                }
                var Exist_Log = conn.Query<SinglePhaseElectricMeterLog>(Checksql_Log).ToList();
                if (Exist_Log.Count == 0)
                {
                    conn.Execute(InsertLogsql);
                    Thread.Sleep(10);
                }
                //conn.Execute(Proceduresql);
                //Thread.Sleep(10);
                conn.Execute(Proceduresql1);
            }
        }
        #endregion

        #region 更新溫溼度感測器 ForWeb與Log
        /// <summary>
        /// 更新溫溼度感測器 ForWeb與Log
        /// </summary>
        /// <param name="data"></param>
        public void Insert_Senser(SenserData data)
        {
            DateTime ttimen = DateTime.Now;
            string ttime = ttimen.ToString("yyyyMMddHHmmss");
            string Checksql = string.Empty;
            string Checksql_log = string.Empty;
            string UpdataForwebsql = string.Empty;
            string InsertForweb = string.Empty;
            string InsertLogsql = string.Empty;
            Checksql = $"SELECT * FROM Senser_ForWeb WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {data.DeviceIndex}";
            Checksql_log = $"SELECT * FROM Senser_Log WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {data.DeviceIndex} AND ttime = '{ttimen:yyyyMMddHHmm00}'";
            UpdataForwebsql = $"UPDATE Senser_ForWeb SET " +
                              $"ttime= '{ttime}'," +
                              $"ttimen = '{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}'," +
                              $"Temperature = {data.Temperature}," +
                              $"Humidity={data.Humidity}," +
                              $"PM1={data.PM1}," +
                              $"PM25 = {data.PM25}," +
                              $"PM10 = {data.PM10}," +
                              $"CO2 = {data.CO2}," +
                              $"TVOC={data.TVOC}," +
                              $"HCHO={data.HCHO}," +
                              $"O3={data.O3}," +
                              $"CO = {data.CO}," +
                              $"Mold = {data.Mold}," +
                              $"IAQ={data.IAQ} " +
                              $"WHERE GatewayIndex = {data.GatewayIndex} AND DeviceIndex = {data.DeviceIndex}";
            InsertForweb = $"INSERT INTO {setting.InitialCatalog}.Senser_ForWeb (ttime,ttimen,GatewayIndex,DeviceIndex,Temperature,Humidity,PM1,PM25,PM10,CO2,TVOC,HCHO,O3,CO,Mold,IAQ)VALUES(" +
                        $"'{ttime}','{ttimen.ToString("yyyy/MM/dd HH:mm:ss")}',{data.GatewayIndex},{data.DeviceIndex},{data.Temperature},{data.Humidity },{data.PM1},{data.PM25},{data.PM10},{data.CO2},{data.TVOC},{data.HCHO},{data.O3},{data.CO},{data.Mold},{data.IAQ})";
            InsertLogsql = $"INSERT INTO {setting.InitialCatalog}.Senser_Log (ttime,ttimen,GatewayIndex,DeviceIndex,Temperature,Humidity,PM1,PM25,PM10,CO2,TVOC,HCHO,O3,CO,Mold,IAQ)VALUES(" +
                          $"'{ttimen:yyyyMMddHHmm00}','{ttimen.ToString("yyyy/MM/dd HH:mm:00")}',{data.GatewayIndex},{data.DeviceIndex},{data.Temperature},{data.Humidity },{data.PM1},{data.PM25},{data.PM10},{data.CO2},{data.TVOC},{data.HCHO},{data.O3},{data.CO},{data.Mold},{data.IAQ})";

            using (var conn = new MySqlConnection(myscbs.ConnectionString))
            {
                var Exist = conn.Query<SenserLog>(Checksql).ToList();
                if (Exist.Count > 0)
                {
                    conn.Execute(UpdataForwebsql);
                    Thread.Sleep(10);
                }
                else
                {
                    conn.Execute(InsertForweb);
                    Thread.Sleep(10);
                }
                var LogExist = conn.Query<SenserLog>(Checksql_log).ToList();
                if (LogExist.Count == 0)
                {
                    conn.Execute(InsertLogsql);
                    Thread.Sleep(10);
                }
            }
        }
        #endregion

        #region 搜尋總表KWH Circel圖
        /// <summary>
        /// 搜尋總表KWH Pie圖
        /// </summary>
        /// <param name="groupSetting">通訊資訊</param>
        /// <param name="GroupIndex">群組編號</param>
        /// <param name="DateIndex">數值類型 0 = kW，1 = 錢</param>
        /// <returns></returns>
        public decimal Serch_TotalMeter_Circel(GroupSetting groupSetting, int GroupIndex, int DateIndex)
        {
            decimal module = 0;
            string sql = string.Empty;
            List<string> Search_TotalMeterstr = new List<string>();
            string Search_Criteria = string.Empty; //搜尋條件

            foreach (var Electricitem in groupSetting.ElectricDevices)
            {
                if (Electricitem.GroupIndex == GroupIndex)
                {
                    Search_TotalMeterstr.Add($"(GatewayIndex = {Electricitem.GatewayIndex} AND DeviceIndex = {Electricitem.DeviceIndex})");
                }
            }

            if (Search_TotalMeterstr.Count > 0)
            {
                if (Search_TotalMeterstr.Count == 1)
                {
                    Search_Criteria = $"AND {Search_TotalMeterstr[0]}";
                }
                else
                {
                    Search_Criteria = $"AND ({Search_TotalMeterstr[0]}";
                    for (int i = 1; i < Search_TotalMeterstr.Count; i++)
                    {
                        if (i == Search_TotalMeterstr.Count - 1)
                        {
                            Search_Criteria += $" OR {Search_TotalMeterstr[i]})";
                        }
                        else
                        {
                            Search_Criteria += $" OR {Search_TotalMeterstr[i]}";
                        }
                    }
                }
            }
            else
            {
                Search_Criteria = " ";
            }
            if (setting.ElectricMeterPriceFlag)
            {
                if (DateIndex == 0)
                {
                    sql = $"SELECT SUM(Total) AS Value FROM electricdailykwh WHERE ttime >='{DateTime.Now:yyyyMM0100}' AND ttime <='{DateTime.Now:yyyyMM3123}' {Search_Criteria} GROUP BY ttime";
                }
                else
                {
                    sql = $"SELECT SUM(MoneyTotal) AS Value FROM electricdailykwh WHERE ttime >='{DateTime.Now:yyyyMM0100}' AND ttime <='{DateTime.Now:yyyyMM3123}' {Search_Criteria} GROUP BY ttime";
                }
            }
            else
            {
                if (DateIndex == 0)
                {
                    sql = $"SELECT SUM(KwhTotal) AS Value FROM electrictotalprice WHERE ttime >='{DateTime.Now:yyyyMM0100}' AND ttime <='{DateTime.Now:yyyyMM3123}' {Search_Criteria} GROUP BY ttime";
                }
                else
                {
                    sql = $"SELECT SUM(Price) AS Value FROM electrictotalprice WHERE ttime >='{DateTime.Now:yyyyMM0100}' AND ttime <='{DateTime.Now:yyyyMM3123}' {Search_Criteria} GROUP BY ttime";
                }

            }
            using (var conn = new MySqlConnection(myscbs.ConnectionString))
            {
                var modules = conn.Query<decimal>(sql).ToList();
                foreach (var item in modules)
                {
                    module += item;
                }
            }
            return module;
        }
        #endregion

        #region 查詢三段電價金額 (不使用)
        /// <summary>
        /// 查詢三段電價金額
        /// </summary>
        /// <param name="groupSetting"></param>
        /// <param name="GroupIndex"></param>
        /// <returns></returns>
        public ElectricDailykwh Serch_TotalMeter_ElectricDailykwh(GroupSetting groupSetting, int GroupIndex)
        {
            string sql = string.Empty;
            List<string> Search_TotalMeterstr = new List<string>();
            string Search_Criteria = string.Empty; //搜尋條件
            foreach (var Electricitem in groupSetting.ElectricDevices)
            {
                if (Electricitem.GroupIndex == GroupIndex)
                {
                    Search_TotalMeterstr.Add($"(GatewayIndex = {Electricitem.GatewayIndex} AND DeviceIndex = {Electricitem.DeviceIndex})");
                }
            }
            if (Search_TotalMeterstr.Count > 0)
            {
                if (Search_TotalMeterstr.Count == 1)
                {
                    Search_Criteria = $"AND {Search_TotalMeterstr[0]}";
                }
                else
                {
                    Search_Criteria = $"AND ({Search_TotalMeterstr[0]}";
                    for (int i = 1; i < Search_TotalMeterstr.Count; i++)
                    {
                        if (i == Search_TotalMeterstr.Count - 1)
                        {
                            Search_Criteria += $" OR {Search_TotalMeterstr[i]})";
                        }
                        else
                        {
                            Search_Criteria += $" OR {Search_TotalMeterstr[i]}";
                        }
                    }
                }
            }
            else
            {
                Search_Criteria = " ";
            }
            sql = $"SELECT SUM(MoneyTotal) AS MoneyTotal,SUM(Total) AS Total FROM electricdailykwh WHERE ttime >='{DateTime.Now:yyyyMM0000}' AND ttime <='{DateTime.Now:yyyyMM3123}' {Search_Criteria} GROUP BY ttime";
            using (var conn = new MySqlConnection(myscbs.ConnectionString))
            {
                var data = conn.Query<ElectricDailykwh>(sql).ToList();
                ElectricDailykwh electricDailykwh = new ElectricDailykwh();
                foreach (var item in data)
                {
                    electricDailykwh.Total += item.Total;
                    electricDailykwh.MoneyTotal += item.MoneyTotal;
                }
                return electricDailykwh;
            }
        }
        #endregion

        #region 查詢一般電費金額 (不使用)
        /// <summary>
        /// 查詢一般電費金額
        /// </summary>
        /// <param name="groupSetting"></param>
        /// <param name="GroupIndex"></param>
        /// <returns></returns>
        public ElectricTotalPrice Serch_TotalMeter_ElectricTotalPrice(GroupSetting groupSetting, int GroupIndex)
        {
            string sql = string.Empty;
            List<string> Search_TotalMeterstr = new List<string>();
            string Search_Criteria = string.Empty; //搜尋條件
            foreach (var Electricitem in groupSetting.ElectricDevices)
            {
                if (Electricitem.GroupIndex == GroupIndex)
                {
                    Search_TotalMeterstr.Add($"(GatewayIndex = {Electricitem.GatewayIndex} AND DeviceIndex = {Electricitem.DeviceIndex})");
                }
            }

            if (Search_TotalMeterstr.Count > 0)
            {
                if (Search_TotalMeterstr.Count == 1)
                {
                    Search_Criteria = $"AND {Search_TotalMeterstr[0]}";
                }
                else
                {
                    Search_Criteria = $"AND ({Search_TotalMeterstr[0]}";
                    for (int i = 1; i < Search_TotalMeterstr.Count; i++)
                    {
                        if (i == Search_TotalMeterstr.Count - 1)
                        {
                            Search_Criteria += $" OR {Search_TotalMeterstr[i]})";
                        }
                        else
                        {
                            Search_Criteria += $" OR {Search_TotalMeterstr[i]}";
                        }
                    }
                }
            }
            else
            {
                Search_Criteria = " ";
            }
            sql = $"SELECT  SUM(Price) AS Price,SUM(KwhTotal) AS KwhTotal FROM electrictotalprice WHERE ttime >='{DateTime.Now:yyyyMM0000}' AND ttime <='{DateTime.Now:yyyyMM3123}' {Search_Criteria} GROUP BY ttime";
            using (var conn = new MySqlConnection(myscbs.ConnectionString))
            {
                var data = conn.Query<ElectricTotalPrice>(sql).ToList();
                ElectricTotalPrice electricTotalPrice = new ElectricTotalPrice();
                foreach (var item in data)
                {
                    electricTotalPrice.Price += item.Price;
                    electricTotalPrice.KwhTotal += item.KwhTotal;
                }
                return electricTotalPrice;
            }
        }
        #endregion
    }
}
