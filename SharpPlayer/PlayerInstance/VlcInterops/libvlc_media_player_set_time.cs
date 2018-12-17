using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpPlayer.PlayerInstance.VlcInterops
{
    internal delegate void libvlc_media_player_set_time(IntPtr mediaPlayerInstance, long time);
}
