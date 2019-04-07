﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Examples
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            SharpPlayer.Default.SetupWithVLC(@"C:\Program Files\VideoLAN\VLC");

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Tester());
        }
    }
}
