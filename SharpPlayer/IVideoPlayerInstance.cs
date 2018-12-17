using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpPlayer
{
    internal interface IVideoPlayerInstance
    {
        void SetVideoCanvas(Control canvas);
        void TakeSnapshot(string dst);
        Bitmap TakeSnapshot();
        Size VideoSize {get;}
    }
}
