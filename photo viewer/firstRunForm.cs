using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace photo_viewer
{
    public partial class firstRunForm : Form
    {
        public firstRunForm()
        {
            InitializeComponent();
            this.search.Click += search_Click;
            hello.Location = welcome.Location = new Point((this.ClientSize.Width - hello.Width) / 2, hello.Location.Y); 
            welcome.Location = new Point((this.ClientSize.Width - welcome.Width) / 2, this.ClientSize.Height / 2);
        }

        

        private void search_Click(object sender, EventArgs e)
        {
            using (folderBrowserDialog1) 
            {
                folderBrowserDialog1.Description = "Select the folder where your photos are located";

                if (folderBrowserDialog1.ShowDialog() == DialogResult.OK) 
                {
                    string path = folderBrowserDialog1.SelectedPath;
                    Properties.Settings.Default.FolderPath = path;
                    Properties.Settings.Default.Save();
                    pathBox.Text = path;
                }
            }
        }

        private void done_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(pathBox.Text)) 
            {
                welcome.Text = "The path selected does not exist";
                welcome.Location = new Point((this.ClientSize.Width - welcome.Width) / 2, this.ClientSize.Height / 2);
            }
            else 
            {   
                this.Close();
                Console.WriteLine(Properties.Settings.Default.FolderPath);
            }
            
        }

        private void hello_Click(object sender, EventArgs e)
        {

        }
        
        private void welcome_Click(object sender, EventArgs e)
        {

        }
    }
}
