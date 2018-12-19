﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SharpPlayer.PlayerInstance;
using System.Runtime.InteropServices;
using System.ComponentModel.Design;

namespace SharpPlayer
{
    [ComVisible(true)]
    [Docking(DockingBehavior.Ask)]
    [ToolboxItem(typeof(VideoPlayer))]
    [ToolboxItemFilter("System.Windows.Forms")]
    [Description("SharpPlayer - VideoPlayer")]
    public partial class VideoPlayer : Control, ISharpPlayer
    {
        public VideoPlayer()
        {
            this.SuspendLayout();

            this.Name = "VideoPlayer";
            this.BackColor = Color.Black;

            this.ResumeLayout();

            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            if (Default.HasConfigure)
            {
                Setup(Default.PlayerInstance, Default.VideoPlayerInstance);
            }
        }


        private IPlayerInstance PlayerInstance = null;

        private IVideoPlayerInstance VideoPlayerInstance = null;

        internal void Setup(IPlayerInstance playerInstance, IVideoPlayerInstance videoPlayerInstance)
        {
            PlayerInstance = playerInstance;
            VideoPlayerInstance = videoPlayerInstance;

            VideoPlayerInstance.SetVideoCanvas(this);

            LoadCacheData();
        }

        public void SetupWithVLC()
        {
            var vlc = new VlcInstance();
            Setup(vlc, vlc);
        }

        public void SetupWithVLC(string libVlc_directory)
        {
            var vlc = new VlcInstance(libVlc_directory);
            Setup(vlc, vlc);
        }

        public void SetupWithVLC(string libVlcCore_path, string libVlc_path)
        {
            var vlc = new VlcInstance(libVlcCore_path, libVlc_path);
            Setup(vlc, vlc);
        }
    }
}
