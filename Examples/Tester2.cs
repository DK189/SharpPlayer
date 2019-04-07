using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Examples
{
    public partial class Tester2 : Form
    {
        public Tester2()
        {
            InitializeComponent();
        }

        private void Tester2_Load(object sender, EventArgs e)
        {
            videoPlayer1.MediaUri = new Uri("https://steamcdn-a.akamaihd.net/steam/apps/2037716/movie480.webm?t=1447370570");
            videoPlayer1.Play();
        }
    }
}
