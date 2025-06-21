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
            InitializeComponent();
            this.Load += scanFiles;
        }

        private void scanFiles(object sender ,EventArgs e) 
        {
            int x = 10;
            foreach(var ext in extensions) 
            {
                string[] files = Directory.GetFiles(path, ext);
                foreach(string file in files)
                {
                    PictureBox image = new PictureBox
                    {
                        Image = Image.FromFile(file),
                        SizeMode = PictureBoxSizeMode.Zoom,
                        Width = 200,
                        Height = 200,
                        BorderStyle = BorderStyle.FixedSingle,
                        Left = x 
                    };

                    imagePanel.Controls.Add(image);
                    x += image.Width + 10; 
                    Console.WriteLine(file);
                }
            }
        }
    }
}
