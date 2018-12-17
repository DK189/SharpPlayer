using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SharpPlayer
{
    internal interface IPlayerControl
    {
        Uri MediaUri { get; set; }
        long Position { get; set; }
        long Duration { get; }
        int Volume { get; set; }
        void Play();
        void Pause();
        void Stop();
    }
}
