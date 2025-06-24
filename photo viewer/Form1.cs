using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photo_viewer
{
    public partial class Form1 : Form
    {
        string path = Properties.Settings.Default.FolderPath;
        string[] extensions = { "*.jpg" , "*.jpeg", "*.png" };

        public Form1()
        {
            Panel topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 20,
                BackColor = Color.LightGray
            };

            Button settingsBtn = new Button
            {
                Text = "Settings",
            };

            InitializeComponent();
            this.Load += scanFiles;

            topPanel.Controls.Add(settingsBtn);
            this.Controls.Add(topPanel);
        }

        private void scanFiles(object sender ,EventArgs e) 
        {
            
            // flowlayoutpanel is better for dynamic use
            imagePanel.Controls.Clear();

            foreach (var ext in extensions) 
            {
                int w_image = 200;
                int h_image = 200;
                int w_panel = 200;
                int h_panel = h_image + 20;

                string[] files = Directory.GetFiles(path, ext);
                foreach(string file in files)
                {

                    Panel panel = new Panel
                    {
                        Width = w_panel,
                        Height = h_panel,
                        Margin = new Padding(10),
                        
                    };

                    PictureBox image = new PictureBox
                    {
                        Image = Image.FromFile(file),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Width = w_image,
                        Height = h_image,
                        BorderStyle = BorderStyle.FixedSingle
                            
                    };
                    Label fileName = new Label
                    {
                        Text = Path.GetFileName(file),
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Bottom,
                        Height = 20
                    };

                    if(image.Location.Y + image.Height >= this.ClientSize.Height) 
                    {
                        h_image = this.ClientSize.Height - 20;
                    }

                    panel.Controls.Add(image);
                    panel.Controls.Add(fileName);

                    imagePanel.Controls.Add(panel); 
                    Console.WriteLine(file);
                }
            }
        }

        private void settingsBtn_Click(object sender , EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
