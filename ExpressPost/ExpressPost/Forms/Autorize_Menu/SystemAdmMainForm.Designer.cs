namespace ExpressPost.Forms
{
    partial class SystemAdmMainForm
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
            this.WorkersButton = new System.Windows.Forms.Button();
            this.MyProfile_button = new System.Windows.Forms.Button();
            this.routesButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // WorkersButton
            // 
            this.WorkersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkersButton.Location = new System.Drawing.Point(195, 12);
            this.WorkersButton.Name = "WorkersButton";
            this.WorkersButton.Size = new System.Drawing.Size(145, 49);
            this.WorkersButton.TabIndex = 3;
            this.WorkersButton.Text = "Workers";
            this.WorkersButton.UseVisualStyleBackColor = true;
            this.WorkersButton.Click += new System.EventHandler(this.WorkersButton_Click);
            // 
            // MyProfile_button
            // 
            this.MyProfile_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyProfile_button.Location = new System.Drawing.Point(12, 12);
            this.MyProfile_button.Name = "MyProfile_button";
            this.MyProfile_button.Size = new System.Drawing.Size(104, 46);
            this.MyProfile_button.TabIndex = 2;
            this.MyProfile_button.Text = "Profile";
            this.MyProfile_button.UseVisualStyleBackColor = true;
            this.MyProfile_button.Click += new System.EventHandler(this.MyProfile_button_Click);
            // 
            // routesButton
            // 
            this.routesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.routesButton.Location = new System.Drawing.Point(195, 90);
            this.routesButton.Name = "routesButton";
            this.routesButton.Size = new System.Drawing.Size(145, 49);
            this.routesButton.TabIndex = 4;
            this.routesButton.Text = "Routes";
            this.routesButton.UseVisualStyleBackColor = true;
            this.routesButton.Click += new System.EventHandler(this.routesButton_Click);
            // 
            // SystemAdmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.routesButton);
            this.Controls.Add(this.WorkersButton);
            this.Controls.Add(this.MyProfile_button);
            this.Name = "SystemAdmMainForm";
            this.Text = "SystemAdmMainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button WorkersButton;
        private System.Windows.Forms.Button MyProfile_button;
        private System.Windows.Forms.Button routesButton;
    }
}