using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SharpPlayer
{
    public abstract class SharpPlayerControl : Control
    {
        protected abstract void LoadCacheData();

        public abstract void SetupWithVLC();

        public abstract void SetupWithVLC(string libVlc_directory);

        public abstract void SetupWithVLC(string libVlcCore_path, string libVlc_path);
    }
}
