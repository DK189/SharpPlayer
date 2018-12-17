using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpPlayer.PlayerInstance.VlcInterops
{
    internal delegate void libvlc_audio_set_volume(IntPtr mediaPlayerInstance, int volume);
}
