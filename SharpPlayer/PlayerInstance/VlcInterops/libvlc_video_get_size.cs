using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpPlayer.PlayerInstance.VlcInterops
{
    internal delegate int libvlc_video_get_size(IntPtr mediaPlayerInstance, uint num, out uint px, out uint py);
}
