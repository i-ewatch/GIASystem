using GIASystem.Configuration;
using Serilog;
using System;
using System.Collections.Generic;
using System.IO;

namespace GIASystem.Views
{
    public partial class VideoControl : Field4UserControl
    {
        private List<string> mMovieFileName = new List<string>();
        public VideoControl(MediaPlaySetting mediaPlaySetting)
        {
            InitializeComponent();
            MediaPlaySetting = mediaPlaySetting;
            axWindowsMediaPlayer1.uiMode = "None";
            axWindowsMediaPlayer1.settings.volume = 100;
        }
        public override void TextChange()
        {
            try
            {
                if (MediaPlaySetting != null)
                {
                    string mDirectory = MediaPlaySetting.VideoPath;
                    if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsUndefined)//未知狀態
                    {
                        if (Directory.Exists(mDirectory) == true)
                        {
                            DirectoryInfo di = new DirectoryInfo(mDirectory);
                            foreach (var fi in di.GetFiles())
                            {
                                mMovieFileName.Add(fi.Name);
                            }
                            axWindowsMediaPlayer1.URL = mDirectory + @"\" + mMovieFileName[0];
                            mMovieFileName.RemoveAt(0);
                        }
                        else
                        {
                            if (Directory.Exists($"{MyWorkPath}\\Videos") == true)
                            {
                                DirectoryInfo di = new DirectoryInfo($"{MyWorkPath}\\Videos");
                                foreach (var fi in di.GetFiles())
                                {
                                    mMovieFileName.Add(fi.Name);
                                }
                                axWindowsMediaPlayer1.URL = $"{MyWorkPath}\\Videos" + @"\" + mMovieFileName[0];
                                mMovieFileName.RemoveAt(0);
                            }
                        }
                    }
                    else if (axWindowsMediaPlayer1.playState == WMPLib.WMPPlayState.wmppsStopped)//播放停止
                    {
                        if (mMovieFileName.Count > 0)
                        {
                            if (Directory.Exists(mDirectory) == true)
                            {
                                if (File.Exists(mDirectory + @"\" + mMovieFileName[0]) == true)
                                    axWindowsMediaPlayer1.URL = mDirectory + @"\" + mMovieFileName[0];
                                mMovieFileName.RemoveAt(0);
                            }
                            else
                            {
                                if (File.Exists($"{MyWorkPath}\\Videos" + @"\" + mMovieFileName[0]) == true)
                                    axWindowsMediaPlayer1.URL = $"{MyWorkPath}\\Videos" + @"\" + mMovieFileName[0];
                                mMovieFileName.RemoveAt(0);
                            }
                        }
                        else
                        {
                            GC.Collect();
                            if (Directory.Exists(mDirectory) == true)
                            {
                                DirectoryInfo di = new DirectoryInfo(mDirectory);
                                foreach (var fi in di.GetFiles())
                                {
                                    mMovieFileName.Add(fi.Name);
                                }
                                axWindowsMediaPlayer1.URL = mDirectory + @"\" + mMovieFileName[0];
                                mMovieFileName.RemoveAt(0);
                            }
                            else
                            {
                                if (Directory.Exists($"{MyWorkPath}\\Videos") == true)
                                {
                                    DirectoryInfo di = new DirectoryInfo($"{MyWorkPath}\\Videos");
                                    foreach (var fi in di.GetFiles())
                                    {
                                        mMovieFileName.Add(fi.Name);
                                    }
                                    axWindowsMediaPlayer1.URL = $"{MyWorkPath}\\Videos" + @"\" + mMovieFileName[0];
                                    mMovieFileName.RemoveAt(0);
                                }
                            }
                        }
                    }
                }
            }
            catch (ArgumentOutOfRangeException) { }
            catch (Exception ex)
            {
                Log.Error(ex, "播放影片錯誤");
            }
        }
    }
}
