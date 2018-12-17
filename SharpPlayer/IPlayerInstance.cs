using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SharpPlayer
{
    internal interface IPlayerInstance
    {
        void SetMediaUri(Uri uri);
        void Play();
        void Pause();
        void Stop();
        bool IsPlaying { get; }
        bool CanPause { get; }
        bool CanSeek { get; }
        long Position { get; set; }
        long Duration { get; }
        int Volume { get; set; }
    }
}
