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
    public partial class settingsForm : Form
    {
        string path = Properties.Settings.Default.FolderPath;
        int sideWidth = 130;

        Panel optionsPnl;
        Label pathLabel;
        TextBox pathBox;

        private Form1 form1;

        public settingsForm(Form1 form1)
        {
            this.form1 = form1;
            optionsPnl = new Panel
            {
                Dock = DockStyle.Fill
            };

            pathLabel = new Label
            {
                Text = "Path",
                AutoSize = true,
                Location = new Point(sideWidth + 10, 10)
            };

            pathBox = new TextBox
            {
                Text = path,
                Width = 200,
                Location = new Point(pathLabel.Location.X, pathLabel.Location.Y + 20)
            };

            Panel sidePanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = sideWidth,
                BackColor = Color.LightGray
            };

            Label pathBtn = new Label
            {
                Text = "Path",
            };

            pathBtn.Click += pathBtn_Click;
            sidePanel.Click += sidePanel_Click;
            this.Controls.Add(sidePanel);
            this.Controls.Add(optionsPnl);
            sidePanel.Controls.Add(pathBtn);
            InitializeComponent();
        }

        private void pathBtn_Click(object sender, EventArgs e)
        {
            optionsPnl.Controls.Clear();

            Button searchBtn = new Button
            {
                Text = "...",
                Location = new Point(pathBox.Location.X + 200, pathBox.Location.Y),
                Size = new Size(30, pathBox.Height)
            };
            searchBtn.Click += searchBtn_Click;

            optionsPnl.Controls.Add(pathLabel);
            optionsPnl.Controls.Add(pathBox);
            optionsPnl.Controls.Add(searchBtn);
        }

        private void searchBtn_Click(object sender, EventArgs e)
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
                    form1.refreshFiles(); 

                }
            }
        }

        private void sidePanel_Click(object sender, EventArgs e)
        {
            optionsPnl.Controls.Clear();
        }
    }
}