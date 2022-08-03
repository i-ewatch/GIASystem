﻿using GIASystem.Configuration;
using GIASystem.Enums;
using GIASystem.Methods;
using GIASystem.Protocols;
using System;
using System.Collections.Generic;

namespace GIASystem.Views
{
    public partial class Field4UserControl : DevExpress.XtraEditors.XtraUserControl
    {
        /// <summary>
        /// 初始路徑
        /// </summary>
        public string MyWorkPath { get; set; } = AppDomain.CurrentDomain.BaseDirectory;
        /// <summary>
        /// 資料庫方法
        /// </summary>
        public SqlMethod SqlMethod { get; set; }
        /// <summary>
        /// 群組資訊
        /// </summary>
        public GroupSetting GroupSetting { get; set; }
        /// <summary>
        /// 畫面媒體資訊
        /// </summary>
        public GIAScreenMediaSetting ScreenMediaSetting { get; set; }
        /// <summary>
        /// 跑馬燈設定
        /// </summary>
        public MarqueeSetting MarqueeSetting { get; set; }
        /// <summary>
        /// 影片資訊
        /// </summary>
        public MediaPlaySetting MediaPlaySetting { get; set; }
        /// <summary>
        /// 總數值物建
        /// </summary>
        public List<AbsProtocol> AbsProtocols { get; set; }
        public GIA_DistricsSetting GIA_DistricsSetting { get; set; }
        /// <summary>
        /// 天氣資訊
        /// </summary>
        public List<Taiwan_DistricsSetting> Taiwan_DistricsSetting { get; set; }
        /// <summary>
        /// 通道資訊
        /// </summary>
        public GateWaySetting GateWaySetting { get; set; }
        /// <summary>
        /// 資料庫資訊
        /// </summary>
        public SqlDBSetting SqlDBSetting { get; set; }
        /// <summary>
        /// 設備資訊
        /// </summary>
        public GateWay GateWay { get; set; }
        /// <summary>
        /// 刷新時間
        /// </summary>
        public DateTime RefreshTime { get; set; }
        #region Enums
        /// <summary>
        /// 電表設備類型
        /// </summary>
        public ElectricEnumType ElectricEnumType { get; set; }
        /// <summary>
        /// 環境設備類型
        /// </summary>
        public SenserEnumType SenserEnumType { get; set; }
        /// <summary>
        /// 環境設備類型
        /// </summary>
        public APIEnumType APIEnumType { get; set; }
        /// <summary>
        /// 迴圈類型
        /// </summary>
        public LoopEnumType LoopEnumType { get; set; }
        /// <summary>
        /// 相位類型
        /// </summary>
        public PhaseEnumType PhaseEnumType { get; set; }
        /// <summary>
        /// 相角類型
        /// </summary>
        public PhaseAngleEnumType PhaseAngleEnumType { get; set; }
        #endregion

        #region 畫面/字體顏色
        /// <summary>
        /// 畫面R顏色
        /// </summary>
        public int Rpanel { get; set; } = 0;
        /// <summary>
        /// 畫面G顏色
        /// </summary>
        public int Gpanel { get; set; } = 0;
        /// <summary>
        /// 畫面B顏色
        /// </summary>
        public int Bpanel { get; set; } = 0;
        /// <summary>
        /// 字體R顏色
        /// </summary>
        public int RFore { get; set; } = 0;
        /// <summary>
        /// 字體R顏色
        /// </summary>
        public int GFore { get; set; } = 0;
        /// <summary>
        /// 字體B顏色
        /// </summary>
        public int BFore { get; set; } = 0;
        #endregion
        public virtual void TextChange() { }
    }
}
