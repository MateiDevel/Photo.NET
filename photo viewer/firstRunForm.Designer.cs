namespace photo_viewer
{
    partial class firstRunForm
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
            this.hello = new System.Windows.Forms.Label();
            this.welcome = new System.Windows.Forms.Label();
            this.pathBox = new System.Windows.Forms.TextBox();
            this.search = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.done = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // hello
            // 
            this.hello.Font = new System.Drawing.Font("Segoe UI", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hello.Location = new System.Drawing.Point(208, 9);
            this.hello.Name = "hello";
            this.hello.Size = new System.Drawing.Size(206, 87);
            this.hello.TabIndex = 0;
            this.hello.Text = "Hello,";
            this.hello.Click += new System.EventHandler(this.hello_Click);
            // 
            // welcome
            // 
            this.welcome.AutoSize = true;
            this.welcome.Location = new System.Drawing.Point(115, 156);
            this.welcome.Name = "welcome";
            this.welcome.Size = new System.Drawing.Size(388, 13);
            this.welcome.TabIndex = 1;
            this.welcome.Text = "Welcome to Photo Viewer! Please input the path where your photos are located: ";
            this.welcome.Click += new System.EventHandler(this.welcome_Click);
            // 
            // pathBox
            // 
            this.pathBox.Location = new System.Drawing.Point(162, 202);
            this.pathBox.Name = "pathBox";
            this.pathBox.Size = new System.Drawing.Size(237, 20);
            this.pathBox.TabIndex = 2;
            this.pathBox.Text = "C:\\";
            // 
            // search
            // 
            this.search.Location = new System.Drawing.Point(421, 202);
            this.search.Name = "search";
            this.search.Size = new System.Drawing.Size(26, 23);
            this.search.TabIndex = 3;
            this.search.Text = "...";
            this.search.UseVisualStyleBackColor = true;
            this.search.Click += new System.EventHandler(this.search_Click);
            // 
            // done
            // 
            this.done.Location = new System.Drawing.Point(266, 257);
            this.done.Name = "done";
            this.done.Size = new System.Drawing.Size(75, 23);
            this.done.TabIndex = 4;
            this.done.Text = "Done!";
            this.done.UseVisualStyleBackColor = true;
            this.done.Click += new System.EventHandler(this.done_Click);
            // 
            // firstRunForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 292);
            this.Controls.Add(this.done);
            this.Controls.Add(this.search);
            this.Controls.Add(this.pathBox);
            this.Controls.Add(this.welcome);
            this.Controls.Add(this.hello);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "firstRunForm";
            this.Text = "Welcome";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label hello;
        private System.Windows.Forms.Label welcome;
        private System.Windows.Forms.TextBox pathBox;
        private System.Windows.Forms.Button search;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button done;
    }
}