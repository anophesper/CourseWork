namespace ExpressPost
{
    partial class AuthorizeForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.phone = new System.Windows.Forms.TextBox();
            this.password = new System.Windows.Forms.TextBox();
            this.Button = new System.Windows.Forms.Button();
            this.RegistrationLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // phone
            // 
            this.phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone.Location = new System.Drawing.Point(362, 201);
            this.phone.Name = "phone";
            this.phone.Size = new System.Drawing.Size(207, 31);
            this.phone.TabIndex = 0;
            // 
            // password
            // 
            this.password.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password.Location = new System.Drawing.Point(362, 271);
            this.password.Name = "password";
            this.password.PasswordChar = '*';
            this.password.Size = new System.Drawing.Size(207, 31);
            this.password.TabIndex = 1;
            // 
            // Button
            // 
            this.Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button.Location = new System.Drawing.Point(403, 332);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(130, 35);
            this.Button.TabIndex = 2;
            this.Button.Text = "Enter";
            this.Button.UseVisualStyleBackColor = true;
            this.Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // RegistrationLabel
            // 
            this.RegistrationLabel.AutoSize = true;
            this.RegistrationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RegistrationLabel.Location = new System.Drawing.Point(420, 370);
            this.RegistrationLabel.Name = "RegistrationLabel";
            this.RegistrationLabel.Size = new System.Drawing.Size(95, 20);
            this.RegistrationLabel.TabIndex = 3;
            this.RegistrationLabel.Text = "Registration";
            this.RegistrationLabel.Click += new System.EventHandler(this.RegistrationLabel_Click);
            // 
            // AuthorizeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.RegistrationLabel);
            this.Controls.Add(this.Button);
            this.Controls.Add(this.password);
            this.Controls.Add(this.phone);
            this.Name = "AuthorizeForm";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox phone;
        private System.Windows.Forms.TextBox password;
        private System.Windows.Forms.Button Button;
        private System.Windows.Forms.Label RegistrationLabel;
    }
}

