namespace ExpressPost.Forms
{
    partial class ClientMainForm
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
            this.MyProfile_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MyProfile_button
            // 
            this.MyProfile_button.Location = new System.Drawing.Point(12, 12);
            this.MyProfile_button.Name = "MyProfile_button";
            this.MyProfile_button.Size = new System.Drawing.Size(104, 46);
            this.MyProfile_button.TabIndex = 0;
            this.MyProfile_button.Text = "my profile";
            this.MyProfile_button.UseVisualStyleBackColor = true;
            this.MyProfile_button.Click += new System.EventHandler(this.MyProfile_button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.MyProfile_button);
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MyProfile_button;
    }
}