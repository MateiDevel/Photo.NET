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
using System.Diagnostics;

namespace photo_viewer
{
    public partial class Form1 : Form
    {

        string path = Properties.Settings.Default.FolderPath;
        string[] extensions = { "*.jpg", "*.jpeg", "*.png" };

        Panel panel;
        PictureBox image;
        PictureBox selectedImage;
        Label fileName;

        public Form1()
        {
            Panel topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 20,
                BackColor = Color.LightGray
            };

            Label settingsBtn = new Label
            {
                Text = "Settings",
            };

            InitializeComponent();
            this.Load += scanFiles;
            settingsBtn.Click += settingsBtn_Click;

            topPanel.Controls.Add(settingsBtn);
            this.Controls.Add(topPanel);
        }

        public void scanFiles(object sender, EventArgs e)
        {
            imagePanel.Controls.Clear();
            foreach (var ext in extensions)
            {
                int w_image = 200;
                int h_image = 200;
                int w_panel = 200;
                int h_panel = h_image + 20;

                string[] files = Directory.GetFiles(path, ext);
                foreach (string file in files)
                {
                    panel = new Panel
                    {
                        Width = w_panel,
                        Height = h_panel,
                        Margin = new Padding(10),
                    };

                    image = new PictureBox
                    {
                        Image = Image.FromFile(file),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Width = w_image,
                        Height = h_image,
                        BorderStyle = BorderStyle.FixedSingle,
                        Tag = file
                    };
                    fileName = new Label
                    {
                        Text = Path.GetFileName(file),
                        AutoSize = false,
                        TextAlign = ContentAlignment.MiddleCenter,
                        Dock = DockStyle.Bottom,
                        Height = 20
                    };

                    if (image.Location.Y + image.Height >= this.ClientSize.Height)
                    {
                        h_image = this.ClientSize.Height - 20;
                    }

                    panel.Controls.Add(image);
                    panel.Controls.Add(fileName);

                    image.Click += image_Click;

                    imagePanel.Controls.Add(panel);
                    Console.WriteLine(file);
                }
            }
        }

        private void image_Click(object sender, EventArgs e)
        {
            PictureBox clickedImage = sender as PictureBox;
            if (clickedImage == null) return;
            string imagePath = clickedImage.Tag as string;

            try
            {
                Process.Start(new ProcessStartInfo(imagePath) { UseShellExecute = true });
            }
            catch(Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
            }
            if (clickedImage != null)
            {
                if (selectedImage != null && selectedImage != clickedImage)
                {
                    selectedImage.BackColor = Color.Transparent;
                }
                clickedImage.BackColor = Color.LightGray;
                selectedImage = clickedImage;
            }


        }

        public void refreshFiles()
        {
            path = Properties.Settings.Default.FolderPath;
            imagePanel.Controls.Clear();
            scanFiles(this, EventArgs.Empty);
        }

        private void settingsBtn_Click(object sender, EventArgs e)
        {
            settingsForm settings = new settingsForm(this);
            settings.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
