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
        string[] extensions = { "*.jpg", "*.jpeg", "*.png", "*.bmp", "*.webp", "*.svg" };

        Panel panel;
        PictureBox image;
        PictureBox selectedImage;
        Label fileName;
        Label pathLabel;
        Image fullimg;

        public Form1()
        {
            Panel pathPanel = new Panel
            {
                Dock = DockStyle.Bottom,
                AutoScroll = true,
                Height = 20,
                BackColor = Color.LightGray,
               
            };

            pathLabel = new Label
            {
                Text = "Path: " + path,
                AutoSize = true,
                AutoEllipsis = true,
                Location = new Point(10, 3),
            };

            Panel topPanel = new Panel
            {
                Dock = DockStyle.Top,
                Height = 20,
                BackColor = Color.LightGray
            };

            Label settingsBtn = new Label
            {
                Text = "Settings",
                Location = new Point(10, 3),
                AutoSize = true
            };

            Label creditsBtn = new Label
            {
                Text = "Credits",
                Location = new Point(60, 3),
                AutoSize = true
            };

            InitializeComponent();
            this.Load += scanFiles;
            settingsBtn.Click += settingsBtn_Click;
            creditsBtn.Click += creditsBtn_Click;

            pathPanel.Controls.Add(pathLabel);
            topPanel.Controls.Add(settingsBtn);
            topPanel.Controls.Add(creditsBtn);

            this.Controls.Add(topPanel);
            this.Controls.Add(pathPanel);
        }

        public async void scanFiles(object sender, EventArgs e)
        {

            Panel loadingPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White,
            };

            Label loadingLabel = new Label
            {
                Text = "Loading",
                TextAlign = ContentAlignment.MiddleCenter,
                Font = new Font("Arial", 46, FontStyle.Bold),
                AutoSize = true
                
            };

            loadingPanel.Controls.Add(loadingLabel);
            this.Controls.Add(loadingPanel);
            loadingPanel.BringToFront();
            loadingPanel.Refresh();

            await Task.Run(() =>
            {

                Invoke(new Action(() => imagePanel.Controls.Clear()));

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

                        try
                        {
                            fullimg = Image.FromFile(file);
                        }
                        catch (OutOfMemoryException)
                        {
                            Console.WriteLine($"Failed to load image: {file}");
                            continue;
                        }

                        Image thumbnail = fullimg.GetThumbnailImage(w_image, h_image, () => false, IntPtr.Zero);
                        fullimg.Dispose(); 

                        image = new PictureBox
                        {
                            Image = thumbnail,       
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
                            AutoEllipsis = true,
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


                        if (!this.IsDisposed && !this.Disposing)
                        {
                            Invoke(new Action(() => imagePanel.Controls.Add(panel)));
                        }
                 
                    }
                }
            });

            this.Controls.Remove(loadingPanel);
            loadingPanel.Dispose();
        }

        private void creditsBtn_Click(object sender, EventArgs e)
        {
            creditsForm creditsForm = new creditsForm();
            creditsForm.ShowDialog();
        }

        private void image_Click(object sender, EventArgs e)
        {
            PictureBox clickedImage = sender as PictureBox;
            string imagePath = clickedImage.Tag as string;

            try
            {
                Process.Start(new ProcessStartInfo(imagePath) { UseShellExecute = true });
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error opening photo: " + ex.Message);
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

            foreach (Control ctrl in imagePanel.Controls)
            {
                if (ctrl is Panel imgPanel)
                {
                    foreach (Control child in imgPanel.Controls)
                    {
                        if (child is PictureBox pb)
                        {
                            if (pb.Image != null)
                            {
                                pb.Image.Dispose(); // free the image from memory
                                pb.Image = null;
                            }
                            pb.Dispose();
                        }
                        else
                        {
                            child.Dispose(); // dispose Label or other controls
                        }
                    }
                    imgPanel.Dispose(); // dispose the panel
                }
            }

            imagePanel.Controls.Clear();

            // force garbage collection to reclaim memory
            GC.Collect();
            GC.WaitForPendingFinalizers();

            scanFiles(this, EventArgs.Empty);
            pathLabel.Text = "Path:" + path;
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
