namespace Examples
{
    partial class Tester2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.videoPlayer1 = new SharpPlayer.VideoPlayer();
            this.SuspendLayout();
            // 
            // videoPlayer1
            // 
            this.videoPlayer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoPlayer1.BackColor = System.Drawing.Color.Black;
            this.videoPlayer1.Location = new System.Drawing.Point(12, 12);
            this.videoPlayer1.MediaUri = null;
            this.videoPlayer1.Mute = false;
            this.videoPlayer1.Name = "videoPlayer1";
            this.videoPlayer1.Position = ((long)(0));
            this.videoPlayer1.Size = new System.Drawing.Size(776, 426);
            this.videoPlayer1.TabIndex = 0;
            this.videoPlayer1.Text = "videoPlayer1";
            this.videoPlayer1.Volume = 0;
            // 
            // Tester2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.videoPlayer1);
            this.Name = "Tester2";
            this.Text = "Tester2";
            this.Load += new System.EventHandler(this.Tester2_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private SharpPlayer.VideoPlayer videoPlayer1;
    }
}