namespace ExpressPost_CourseWork.Forms.BranchAdmin
{
    partial class BranchAdmMainForm
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
            this.ArrivedParcelButton = new System.Windows.Forms.Button();
            this.MyProfileButton = new System.Windows.Forms.Button();
            this.SendParcelButton = new System.Windows.Forms.Button();
            this.PickUpParcelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ArrivedParcelButton
            // 
            this.ArrivedParcelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ArrivedParcelButton.Location = new System.Drawing.Point(250, 12);
            this.ArrivedParcelButton.Name = "ArrivedParcelButton";
            this.ArrivedParcelButton.Size = new System.Drawing.Size(250, 40);
            this.ArrivedParcelButton.TabIndex = 16;
            this.ArrivedParcelButton.Text = "Прибувші посилки";
            this.ArrivedParcelButton.UseVisualStyleBackColor = true;
            this.ArrivedParcelButton.Click += new System.EventHandler(this.ArrivedParcelButton_Click);
            // 
            // MyProfileButton
            // 
            this.MyProfileButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyProfileButton.Location = new System.Drawing.Point(33, 12);
            this.MyProfileButton.Name = "MyProfileButton";
            this.MyProfileButton.Size = new System.Drawing.Size(150, 40);
            this.MyProfileButton.TabIndex = 15;
            this.MyProfileButton.Text = "Профіль";
            this.MyProfileButton.UseVisualStyleBackColor = true;
            this.MyProfileButton.Click += new System.EventHandler(this.MyProfileButton_Click);
            // 
            // SendParcelButton
            // 
            this.SendParcelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SendParcelButton.Location = new System.Drawing.Point(250, 88);
            this.SendParcelButton.Name = "SendParcelButton";
            this.SendParcelButton.Size = new System.Drawing.Size(250, 40);
            this.SendParcelButton.TabIndex = 17;
            this.SendParcelButton.Text = "Посилки на відправку";
            this.SendParcelButton.UseVisualStyleBackColor = true;
            this.SendParcelButton.Click += new System.EventHandler(this.SendParcelButton_Click);
            // 
            // PickUpParcelButton
            // 
            this.PickUpParcelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PickUpParcelButton.Location = new System.Drawing.Point(250, 164);
            this.PickUpParcelButton.Name = "PickUpParcelButton";
            this.PickUpParcelButton.Size = new System.Drawing.Size(250, 40);
            this.PickUpParcelButton.TabIndex = 18;
            this.PickUpParcelButton.Text = "Посилки на видачу";
            this.PickUpParcelButton.UseVisualStyleBackColor = true;
            this.PickUpParcelButton.Click += new System.EventHandler(this.PickUpParcelButton_Click);
            // 
            // BranchAdmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.PickUpParcelButton);
            this.Controls.Add(this.SendParcelButton);
            this.Controls.Add(this.ArrivedParcelButton);
            this.Controls.Add(this.MyProfileButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "BranchAdmMainForm";
            this.Text = "BranchAdmMainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button ArrivedParcelButton;
        private System.Windows.Forms.Button MyProfileButton;
        private System.Windows.Forms.Button SendParcelButton;
        private System.Windows.Forms.Button PickUpParcelButton;
    }
}