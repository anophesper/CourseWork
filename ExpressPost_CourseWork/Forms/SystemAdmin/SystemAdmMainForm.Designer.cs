namespace ExpressPost_CourseWork.Forms.SystemAdmin
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
            this.RoutesButton = new System.Windows.Forms.Button();
            this.BranchesButton = new System.Windows.Forms.Button();
            this.WorkersButton = new System.Windows.Forms.Button();
            this.MyProfileButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // RoutesButton
            // 
            this.RoutesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RoutesButton.Location = new System.Drawing.Point(251, 164);
            this.RoutesButton.Name = "RoutesButton";
            this.RoutesButton.Size = new System.Drawing.Size(250, 40);
            this.RoutesButton.TabIndex = 22;
            this.RoutesButton.Text = "Маршрути";
            this.RoutesButton.UseVisualStyleBackColor = true;
            this.RoutesButton.Click += new System.EventHandler(this.RoutesButton_Click);
            // 
            // BranchesButton
            // 
            this.BranchesButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BranchesButton.Location = new System.Drawing.Point(251, 88);
            this.BranchesButton.Name = "BranchesButton";
            this.BranchesButton.Size = new System.Drawing.Size(250, 40);
            this.BranchesButton.TabIndex = 21;
            this.BranchesButton.Text = "Відділення";
            this.BranchesButton.UseVisualStyleBackColor = true;
            this.BranchesButton.Click += new System.EventHandler(this.BranchesButton_Click);
            // 
            // WorkersButton
            // 
            this.WorkersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WorkersButton.Location = new System.Drawing.Point(251, 12);
            this.WorkersButton.Name = "WorkersButton";
            this.WorkersButton.Size = new System.Drawing.Size(250, 40);
            this.WorkersButton.TabIndex = 20;
            this.WorkersButton.Text = "Працівники";
            this.WorkersButton.UseVisualStyleBackColor = true;
            this.WorkersButton.Click += new System.EventHandler(this.WorkersButton_Click);
            // 
            // MyProfileButton
            // 
            this.MyProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyProfileButton.Location = new System.Drawing.Point(34, 12);
            this.MyProfileButton.Name = "MyProfileButton";
            this.MyProfileButton.Size = new System.Drawing.Size(150, 40);
            this.MyProfileButton.TabIndex = 19;
            this.MyProfileButton.Text = "Профіль";
            this.MyProfileButton.UseVisualStyleBackColor = true;
            this.MyProfileButton.Click += new System.EventHandler(this.MyProfileButton_Click);
            // 
            // SystemAdmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.RoutesButton);
            this.Controls.Add(this.BranchesButton);
            this.Controls.Add(this.WorkersButton);
            this.Controls.Add(this.MyProfileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "SystemAdmMainForm";
            this.Text = "SystemAdmMainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button RoutesButton;
        private System.Windows.Forms.Button BranchesButton;
        private System.Windows.Forms.Button WorkersButton;
        private System.Windows.Forms.Button MyProfileButton;
    }
}