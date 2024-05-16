namespace ExpressPost_CourseWork.Forms.Authorize
{
    partial class AuthorizeForm
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
            this.phoneTextBox = new System.Windows.Forms.TextBox();
            this.passwordTextBox = new System.Windows.Forms.TextBox();
            this.phoneNumberLabel = new System.Windows.Forms.Label();
            this.passwordLabel = new System.Windows.Forms.Label();
            this.EnterButton = new System.Windows.Forms.Button();
            this.RegistrationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // phoneTextBox
            // 
            this.phoneTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneTextBox.Location = new System.Drawing.Point(344, 188);
            this.phoneTextBox.Name = "phoneTextBox";
            this.phoneTextBox.Size = new System.Drawing.Size(230, 31);
            this.phoneTextBox.TabIndex = 0;
            // 
            // passwordTextBox
            // 
            this.passwordTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordTextBox.Location = new System.Drawing.Point(344, 255);
            this.passwordTextBox.Name = "passwordTextBox";
            this.passwordTextBox.PasswordChar = '*';
            this.passwordTextBox.Size = new System.Drawing.Size(230, 31);
            this.passwordTextBox.TabIndex = 1;
            // 
            // phoneNumberLabel
            // 
            this.phoneNumberLabel.AutoSize = true;
            this.phoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phoneNumberLabel.Location = new System.Drawing.Point(340, 161);
            this.phoneNumberLabel.Name = "phoneNumberLabel";
            this.phoneNumberLabel.Size = new System.Drawing.Size(163, 24);
            this.phoneNumberLabel.TabIndex = 2;
            this.phoneNumberLabel.Text = "Номер Телефону";
            // 
            // passwordLabel
            // 
            this.passwordLabel.AutoSize = true;
            this.passwordLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabel.Location = new System.Drawing.Point(340, 228);
            this.passwordLabel.Name = "passwordLabel";
            this.passwordLabel.Size = new System.Drawing.Size(76, 24);
            this.passwordLabel.TabIndex = 3;
            this.passwordLabel.Text = "Пароль";
            // 
            // EnterButton
            // 
            this.EnterButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EnterButton.Location = new System.Drawing.Point(382, 316);
            this.EnterButton.Name = "EnterButton";
            this.EnterButton.Size = new System.Drawing.Size(150, 35);
            this.EnterButton.TabIndex = 4;
            this.EnterButton.Text = "Ввійти";
            this.EnterButton.UseVisualStyleBackColor = true;
            this.EnterButton.Click += new System.EventHandler(this.EnterButton_Click);
            // 
            // RegistrationLabel
            // 
            this.RegistrationLabel.AutoSize = true;
            this.RegistrationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegistrationLabel.Location = new System.Drawing.Point(410, 354);
            this.RegistrationLabel.Name = "RegistrationLabel";
            this.RegistrationLabel.Size = new System.Drawing.Size(85, 20);
            this.RegistrationLabel.TabIndex = 5;
            this.RegistrationLabel.Text = "Регістація";
            this.RegistrationLabel.Click += new System.EventHandler(this.RegistrationLabel_Click);
            // 
            // AuthorizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.RegistrationLabel);
            this.Controls.Add(this.EnterButton);
            this.Controls.Add(this.passwordLabel);
            this.Controls.Add(this.phoneNumberLabel);
            this.Controls.Add(this.passwordTextBox);
            this.Controls.Add(this.phoneTextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AuthorizeForm";
            this.Text = "AuthorizeForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox phoneTextBox;
        private System.Windows.Forms.TextBox passwordTextBox;
        private System.Windows.Forms.Label phoneNumberLabel;
        private System.Windows.Forms.Label passwordLabel;
        private System.Windows.Forms.Button EnterButton;
        private System.Windows.Forms.Label RegistrationLabel;
    }
}