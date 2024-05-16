namespace ExpressPost_CourseWork.Forms.Authorize
{
    partial class ChangePasswordForm
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
            this.SaveButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.currentPasswordTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.newPasswordAgainTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // SaveButton
            // 
            this.SaveButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SaveButton.Location = new System.Drawing.Point(173, 203);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(150, 35);
            this.SaveButton.TabIndex = 19;
            this.SaveButton.Text = "Зберегти";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(128, 17);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(143, 20);
            this.label1.TabIndex = 18;
            this.label1.Text = "Поточний пароль";
            // 
            // currentPasswordTextBox
            // 
            this.currentPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentPasswordTextBox.Location = new System.Drawing.Point(132, 40);
            this.currentPasswordTextBox.Name = "currentPasswordTextBox";
            this.currentPasswordTextBox.Size = new System.Drawing.Size(230, 29);
            this.currentPasswordTextBox.TabIndex = 17;
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(128, 130);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(116, 20);
            this.passwordLabel.TabIndex = 16;
            this.passwordLabel.Text = "Новий пароль";
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneNumberLabel.Location = new System.Drawing.Point(128, 74);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(116, 20);
            this.phoneNumberLabel.TabIndex = 15;
            this.phoneNumberLabel.Text = "Новий пароль";
            // 
            // newPasswordAgainTextBox
            // 
            this.newPasswordAgainTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPasswordAgainTextBox.Location = new System.Drawing.Point(132, 153);
            this.newPasswordAgainTextBox.Name = "newPasswordAgainTextBox";
            this.newPasswordAgainTextBox.PasswordChar = '*';
            this.newPasswordAgainTextBox.Size = new System.Drawing.Size(230, 29);
            this.newPasswordAgainTextBox.TabIndex = 14;
            // 
            // newPasswordTextBox
            // 
            this.newPasswordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPasswordTextBox.Location = new System.Drawing.Point(132, 97);
            this.newPasswordTextBox.Name = "newPasswordTextBox";
            this.newPasswordTextBox.Size = new System.Drawing.Size(230, 29);
            this.newPasswordTextBox.TabIndex = 13;
            // 
            // ChangePasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(500, 270);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.currentPasswordTextBox);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.phoneNumberLabel);
            this.Controls.Add(this.newPasswordAgainTextBox);
            this.Controls.Add(this.newPasswordTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ChangePasswordForm";
            this.Text = "ChangePasswordForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox currentPasswordTextBox;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Label phoneNumberLabel;
        private System.Windows.Forms.TextBox newPasswordAgainTextBox;
        private System.Windows.Forms.TextBox newPasswordTextBox;
    }
}