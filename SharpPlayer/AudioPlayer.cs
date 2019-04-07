using System;
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
    [ToolboxItemFilter("System.Windows.Forms")]
    [Description("SharpPlayer - AudioPlayer")]
    public partial class AudioPlayer : Component, ISharpPlayer
    {
        public AudioPlayer()
        {
            if (LicenseManager.UsageMode == LicenseUsageMode.Designtime)
            {
                return;
            }

            if (Default.HasConfigure)
            {
                Setup(Default.PlayerInstance);
            }
        }


        private IPlayerInstance PlayerInstance = null;

        internal void Setup(IPlayerInstance playerInstance)
        {
            PlayerInstance = playerInstance;

            LoadCacheData();
        }

        public void SetupWithVLC()
        {
            var vlc = new VlcInstance();
            Setup(vlc);
        }

        public void SetupWithVLC(string libVlc_directory)
        {
            var vlc = new VlcInstance(libVlc_directory);
            Setup(vlc);
        }

        public void SetupWithVLC(string libVlcCore_path, string libVlc_path)
        {
            var vlc = new VlcInstance(libVlcCore_path, libVlc_path);
            Setup(vlc);
        }
    }
}
