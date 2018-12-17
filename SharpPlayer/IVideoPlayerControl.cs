using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SharpPlayer
{
    internal interface IVideoPlayerControl
    {
        Size VideoSize { get; }
        void TakeSnapshot(string dst);
        Bitmap TakeSnapshot();
    }
}
