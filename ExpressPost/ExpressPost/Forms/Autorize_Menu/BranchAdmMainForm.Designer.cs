namespace ExpressPost.Forms
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
            this.CreatePackageButton = new System.Windows.Forms.Button();
            this.MyProfile_button = new System.Windows.Forms.Button();
            this.arrivedPackages_button = new System.Windows.Forms.Button();
            this.pickUpParcels_button = new System.Windows.Forms.Button();
            this.sendPackages_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreatePackageButton
            // 
            this.CreatePackageButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreatePackageButton.Location = new System.Drawing.Point(201, 12);
            this.CreatePackageButton.Name = "CreatePackageButton";
            this.CreatePackageButton.Size = new System.Drawing.Size(237, 49);
            this.CreatePackageButton.TabIndex = 3;
            this.CreatePackageButton.Text = "Create new package";
            this.CreatePackageButton.UseVisualStyleBackColor = true;
            this.CreatePackageButton.Click += new System.EventHandler(this.CreatePackageButton_Click);
            // 
            // MyProfile_button
            // 
            this.MyProfile_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MyProfile_button.Location = new System.Drawing.Point(33, 12);
            this.MyProfile_button.Name = "MyProfile_button";
            this.MyProfile_button.Size = new System.Drawing.Size(104, 46);
            this.MyProfile_button.TabIndex = 2;
            this.MyProfile_button.Text = "Profile";
            this.MyProfile_button.UseVisualStyleBackColor = true;
            this.MyProfile_button.Click += new System.EventHandler(this.MyProfile_button_Click);
            // 
            // arrivedPackages_button
            // 
            this.arrivedPackages_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.arrivedPackages_button.Location = new System.Drawing.Point(201, 135);
            this.arrivedPackages_button.Name = "arrivedPackages_button";
            this.arrivedPackages_button.Size = new System.Drawing.Size(237, 49);
            this.arrivedPackages_button.TabIndex = 4;
            this.arrivedPackages_button.Text = "Arrived Packages";
            this.arrivedPackages_button.UseVisualStyleBackColor = true;
            this.arrivedPackages_button.Click += new System.EventHandler(this.arrivedPackages_button_Click);
            // 
            // pickUpParcels_button
            // 
            this.pickUpParcels_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pickUpParcels_button.Location = new System.Drawing.Point(201, 215);
            this.pickUpParcels_button.Name = "pickUpParcels_button";
            this.pickUpParcels_button.Size = new System.Drawing.Size(237, 49);
            this.pickUpParcels_button.TabIndex = 5;
            this.pickUpParcels_button.Text = "PickUp Packages";
            this.pickUpParcels_button.UseVisualStyleBackColor = true;
            this.pickUpParcels_button.Click += new System.EventHandler(this.pickUpParcels_button_Click);
            // 
            // sendPackages_button
            // 
            this.sendPackages_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sendPackages_button.Location = new System.Drawing.Point(201, 294);
            this.sendPackages_button.Name = "sendPackages_button";
            this.sendPackages_button.Size = new System.Drawing.Size(237, 49);
            this.sendPackages_button.TabIndex = 6;
            this.sendPackages_button.Text = "Send Packages";
            this.sendPackages_button.UseVisualStyleBackColor = true;
            this.sendPackages_button.Click += new System.EventHandler(this.sendPackages_button_Click);
            // 
            // BranchAdmMainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.sendPackages_button);
            this.Controls.Add(this.pickUpParcels_button);
            this.Controls.Add(this.arrivedPackages_button);
            this.Controls.Add(this.CreatePackageButton);
            this.Controls.Add(this.MyProfile_button);
            this.Name = "BranchAdmMainForm";
            this.Text = "BranchAdmMainForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreatePackageButton;
        private System.Windows.Forms.Button MyProfile_button;
        private System.Windows.Forms.Button arrivedPackages_button;
        private System.Windows.Forms.Button pickUpParcels_button;
        private System.Windows.Forms.Button sendPackages_button;
    }
}