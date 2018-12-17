using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpPlayer.PlayerInstance.VlcInterops
{
    internal delegate int libvlc_video_take_snapshot(IntPtr mediaPlayerInstance, uint num, string fileName, uint width, uint height);
}
