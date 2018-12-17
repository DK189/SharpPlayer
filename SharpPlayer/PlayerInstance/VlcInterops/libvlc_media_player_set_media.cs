using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SharpPlayer.PlayerInstance.VlcInterops
{
    internal delegate void libvlc_media_player_set_media(IntPtr mediaPlayerInstance, IntPtr mediaInstance);
}
