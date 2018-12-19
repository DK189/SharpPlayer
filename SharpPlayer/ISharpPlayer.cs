using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpPlayer
{
    internal interface ISharpPlayer
    {
        void SetupWithVLC();

        void SetupWithVLC(string libVlc_directory);

        void SetupWithVLC(string libVlcCore_path, string libVlc_path);
    }
}
