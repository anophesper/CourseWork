namespace ExpressPost_CourseWork.Forms.Client
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
            this.MyProfileButton = new System.Windows.Forms.Button();
            this.CreateParcelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // MyProfileButton
            // 
            this.MyProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyProfileButton.Location = new System.Drawing.Point(49, 12);
            this.MyProfileButton.Name = "MyProfileButton";
            this.MyProfileButton.Size = new System.Drawing.Size(150, 40);
            this.MyProfileButton.TabIndex = 13;
            this.MyProfileButton.Text = "Профіль";
            this.MyProfileButton.UseVisualStyleBackColor = true;
            this.MyProfileButton.Click += new System.EventHandler(this.MyProfileButton_Click);
            // 
            // CreateParcelButton
            // 
            this.CreateParcelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateParcelButton.Location = new System.Drawing.Point(266, 12);
            this.CreateParcelButton.Name = "CreateParcelButton";
            this.CreateParcelButton.Size = new System.Drawing.Size(250, 40);
            this.CreateParcelButton.TabIndex = 14;
            this.CreateParcelButton.Text = "Створити накладну";
            this.CreateParcelButton.UseVisualStyleBackColor = true;
            this.CreateParcelButton.Click += new System.EventHandler(this.CreateParcelButton_Click);
            // 
            // ClientMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.CreateParcelButton);
            this.Controls.Add(this.MyProfileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ClientMainForm";
            this.Text = "ClientMainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button MyProfileButton;
        private System.Windows.Forms.Button CreateParcelButton;
    }
}