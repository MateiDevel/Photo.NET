using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photo_viewer
{
    public partial class creditsForm : Form
    {
        public creditsForm()
        {
            InitializeComponent();
            pictureBox1.Image = SystemIcons.Application.ToBitmap();
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            Label title = new Label()
            {
                Text = "Photo \n    .NET",
                Font = new Font("Roboto", 29, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(200, pictureBox1.Location.Y)
            };

            github.LinkClicked += github_LinkClicked;
            buy.LinkClicked += buy_LinkClicked;

            creditpanel.Controls.Add(title);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void github_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/MateiDevel/photo.NET");
        }

        private void buy_LinkClicked(object sender , LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://buymeacoffee.com/mateidev");
        }
    }
}
