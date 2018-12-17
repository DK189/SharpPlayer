using SharpPlayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Examples
{
    public partial class Tester : Form
    {
        public Tester()
        {
            SharpPlayer.Default.SetupWithVLC(@"C:\Program Files\VideoLAN\VLC");

            InitializeComponent();
        }

        private void Tester_Load(object sender, EventArgs e)
        {
            //videoPlayer1.MediaUri = new Uri("https://steamcdn-a.akamaihd.net/steamcommunity/public/images/avatars/c7/c75b144ced5e4f5e8c1bd18f5c18fa08f4538297_full.jpg");
            videoPlayer1.MediaUri = new Uri("https://steamcdn-a.akamaihd.net/steam/apps/2037716/movie480.webm?t=1447370570");
            videoPlayer1.Play();
        }

        private void button1_Click(object sender, EventArgs e)
        {



            var frm = new Form()
            {
                ClientSize = videoPlayer1.VideoSize,
                Text = DateTime.Now + " | " + videoPlayer1.VideoSize
            };
            frm.Controls.Add(new PictureBox()
            {
                Image = videoPlayer1.TakeSnapshot(),
                Dock = DockStyle.Fill
            });
            frm.Show();


            videoPlayer1.TakeSnapshot(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory), "test.png"));

        }
    }
}
