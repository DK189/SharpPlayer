using SharpPlayer.PlayerInstance;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpPlayer
{
    /// <summary>
    /// Default settings for SharpPlayer
    /// </summary>
    public static class Default
    {
        internal static IPlayerInstance PlayerInstance;
        internal static IVideoPlayerInstance VideoPlayerInstance;

        internal static void Setup(IPlayerInstance playerInstance, IVideoPlayerInstance videoPlayerInstance)
        {
            PlayerInstance = playerInstance;
            VideoPlayerInstance = videoPlayerInstance;
        }

        internal static bool HasConfigure
        {
            get
            {
                return PlayerInstance != null && VideoPlayerInstance != null;
            }
        }

        public static void SetupWithVLC()
        {
            var vlc = new VlcInstance();
            Setup(vlc, vlc);
        }

        public static void SetupWithVLC(string libVlc_directory)
        {
            var vlc = new VlcInstance(libVlc_directory);
            Setup(vlc, vlc);
        }

        public static void SetupWithVLC(string libVlcCore_path, string libVlc_path)
        {
            var vlc = new VlcInstance(libVlcCore_path, libVlc_path);
            Setup(vlc, vlc);
        }
    }
}
