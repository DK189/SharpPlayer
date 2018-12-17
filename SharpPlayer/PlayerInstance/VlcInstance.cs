using SharpPlayer.PlayerInstance.VlcInterops;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;

namespace SharpPlayer.PlayerInstance
{
    internal class VlcInstance : IPlayerInstance, IVideoPlayerInstance
    {
        private static readonly string LIB_VLC_CORE_FILENAME;

        private static readonly string LIB_VLC_FILENAME;

        static VlcInstance()
        {
            LIB_VLC_CORE_FILENAME = "libvlccore.dll";
            LIB_VLC_FILENAME = "libvlc.dll";
        }

        /// <summary>
        /// Open VLC Instance in current directory
        /// 
        /// build your project with libvlc library
        /// </summary>
        public VlcInstance()
            : this(Environment.CurrentDirectory)
        {

        }

        /// <summary>
        /// Open VLC Instance
        /// 
        /// You can create new instance with VLC directory
        /// </summary>
        /// <param name="libVlc_directory">your custom lib</param>
        public VlcInstance(string libVlc_directory)
            : this(Path.Combine(libVlc_directory, LIB_VLC_CORE_FILENAME), Path.Combine(libVlc_directory, LIB_VLC_FILENAME))
        {

        }

        /// <summary>
        /// Open VLC Instance
        /// </summary>
        /// <param name="libVlcCore_path"></param>
        /// <param name="libVlc_path"></param>
        public VlcInstance(string libVlcCore_path, string libVlc_path)
        {
            LibVlcCore = DarkKernel.Kernel.LoadLibrary(libVlcCore_path);
            LibVlc = DarkKernel.Kernel.LoadLibrary(libVlc_path);

            if (LibVlcCore == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            if (LibVlc == IntPtr.Zero)
            {
                throw new Win32Exception(Marshal.GetLastWin32Error());
            }

            Init();
        }

        private IntPtr LibVlcCore = IntPtr.Zero;
        private IntPtr LibVlc = IntPtr.Zero;

        private IntPtr LibVlcInstance = IntPtr.Zero;
        private IntPtr LibVlcMediaPlayer = IntPtr.Zero;

        private void Init()
        {
            byte[] bytes = Encoding.UTF8.GetBytes("--quiet");
            IntPtr intPtr = Marshal.AllocHGlobal(bytes.Length + 1);
            Marshal.Copy(bytes, 0, intPtr, bytes.Length);
            Marshal.WriteByte(intPtr, bytes.Length, 0);
            LibVlcInstance = LoadFunc<libvlc_new>()(1, new IntPtr[1] { intPtr });
            LibVlcMediaPlayer = LoadFunc<libvlc_media_player_new>()(LibVlcInstance);
        }

        public T LoadFunc<T>() where T : class
        {
            return DarkKernel.Kernel.LoadFunction<T>(LibVlc, typeof(T).Name);
        }

        public long Position
        {
            get
            {
                return LoadFunc<libvlc_media_player_get_time>()(LibVlcMediaPlayer);
            }
            set
            {
                LoadFunc<libvlc_media_player_set_time>()(LibVlcMediaPlayer, value);
            }
        }

        public long Duration
        {
            get
            {
                var mediaPtr = LoadFunc<libvlc_media_player_get_media>()(LibVlcMediaPlayer);
                if (mediaPtr == IntPtr.Zero)
                {
                    return 0;
                }
                return LoadFunc<libvlc_media_get_duration>()(mediaPtr);
            }
        }

        public bool IsPlaying
        {
            get
            {
                return LoadFunc<libvlc_media_player_is_playing>()(LibVlcMediaPlayer) == 1;
            }
        }

        public bool CanPause
        {
            get
            {
                return LoadFunc<libvlc_media_player_can_pause>()(LibVlcMediaPlayer) == 1;
            }
        }

        public bool CanSeek
        {
            get
            {
                return LoadFunc<libvlc_media_player_is_seekable>()(LibVlcMediaPlayer) == 1;
            }
        }

        public Size VideoSize
        {
            get
            {
                uint px, py;
                var returnCode = LoadFunc<libvlc_video_get_size>()(LibVlcMediaPlayer, 0, out px, out py);
                if (returnCode != 0)
                {
                    throw new Exception("video does not exist! returnCode = " + returnCode);
                }

                return new Size((int)px, (int)py);
            }
        }

        public int Volume
        {
            get
            {
                return LoadFunc<libvlc_audio_get_volume>()(LibVlcMediaPlayer);
            }
            set
            {
                LoadFunc<libvlc_audio_set_volume>()(LibVlcMediaPlayer, value);
            }
        }

        public void SetMediaUri(Uri uri)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(uri.AbsoluteUri);
            IntPtr intPtr = Marshal.AllocHGlobal(bytes.Length + 1);
            try
            {
                Marshal.Copy(bytes, 0, intPtr, bytes.Length);
                Marshal.WriteByte(intPtr, bytes.Length, 0);
            }
            catch (Exception ex)
            {
                Marshal.FreeHGlobal(intPtr);
                throw ex;
            }

            var mediaPtr = LoadFunc<libvlc_media_new_location>()(LibVlcInstance, intPtr);
            LoadFunc<libvlc_media_player_set_media>()(LibVlcMediaPlayer, mediaPtr);
        }

        public void Pause()
        {
            LoadFunc<libvlc_media_player_pause>()(LibVlcMediaPlayer);
        }

        public void Play()
        {
            LoadFunc<libvlc_media_player_play>()(LibVlcMediaPlayer);
        }

        public void Stop()
        {
            LoadFunc<libvlc_media_player_stop>()(LibVlcMediaPlayer);
        }

        public void SetVideoCanvas(Control canvas)
        {
            var hwnd = canvas.Handle;
            LoadFunc<libvlc_media_player_set_hwnd>()(LibVlcMediaPlayer, hwnd);

        }

        public void TakeSnapshot(string dst)
        {
            LoadFunc<libvlc_video_take_snapshot>()(LibVlcMediaPlayer, 0u, dst, 0u, 0u);
        }

        public Bitmap TakeSnapshot()
        {
            string tmpFile = Path.Combine(Path.GetTempPath(), Guid.NewGuid().ToString() + ".bmp");
            TakeSnapshot(tmpFile);
            Bitmap bmp = new Bitmap(tmpFile), result = new Bitmap(bmp.Size.Width, bmp.Size.Height);
            Graphics.FromImage(result).DrawImageUnscaledAndClipped(bmp, new Rectangle(new Point(0, 0), bmp.Size));
            bmp.Dispose();
            File.Delete(tmpFile);
            return result;
        }
    }
}
