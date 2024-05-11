namespace ExpressPost.Forms
{
    partial class RegistrationForm
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
            this.AuthorizeLabel = new System.Windows.Forms.Label();
            this.Button = new System.Windows.Forms.Button();
            this.password_textBox = new System.Windows.Forms.TextBox();
            this.phone_textBox = new System.Windows.Forms.TextBox();
            this.surname_textBox = new System.Windows.Forms.TextBox();
            this.name_textBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // AuthorizeLabel
            // 
            this.AuthorizeLabel.AutoSize = true;
            this.AuthorizeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AuthorizeLabel.Location = new System.Drawing.Point(432, 394);
            this.AuthorizeLabel.Name = "AuthorizeLabel";
            this.AuthorizeLabel.Size = new System.Drawing.Size(77, 20);
            this.AuthorizeLabel.TabIndex = 7;
            this.AuthorizeLabel.Text = "Authorize";
            this.AuthorizeLabel.Click += new System.EventHandler(this.AuthorizeLabel_Click);
            // 
            // Button
            // 
            this.Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Button.Location = new System.Drawing.Point(407, 356);
            this.Button.Name = "Button";
            this.Button.Size = new System.Drawing.Size(130, 35);
            this.Button.TabIndex = 6;
            this.Button.Text = "Enter";
            this.Button.UseVisualStyleBackColor = true;
            this.Button.Click += new System.EventHandler(this.Button_Click);
            // 
            // password_textBox
            // 
            this.password_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.password_textBox.Location = new System.Drawing.Point(366, 281);
            this.password_textBox.Name = "password_textBox";
            this.password_textBox.PasswordChar = '*';
            this.password_textBox.Size = new System.Drawing.Size(207, 31);
            this.password_textBox.TabIndex = 5;
            // 
            // phone_textBox
            // 
            this.phone_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.phone_textBox.Location = new System.Drawing.Point(366, 228);
            this.phone_textBox.Name = "phone_textBox";
            this.phone_textBox.Size = new System.Drawing.Size(207, 31);
            this.phone_textBox.TabIndex = 4;
            // 
            // surname_textBox
            // 
            this.surname_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.surname_textBox.Location = new System.Drawing.Point(366, 177);
            this.surname_textBox.Name = "surname_textBox";
            this.surname_textBox.Size = new System.Drawing.Size(207, 31);
            this.surname_textBox.TabIndex = 9;
            // 
            // name_textBox
            // 
            this.name_textBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.name_textBox.Location = new System.Drawing.Point(366, 122);
            this.name_textBox.Name = "name_textBox";
            this.name_textBox.Size = new System.Drawing.Size(207, 31);
            this.name_textBox.TabIndex = 8;
            // 
            // RegistrationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.surname_textBox);
            this.Controls.Add(this.name_textBox);
            this.Controls.Add(this.AuthorizeLabel);
            this.Controls.Add(this.Button);
            this.Controls.Add(this.password_textBox);
            this.Controls.Add(this.phone_textBox);
            this.Name = "RegistrationForm";
            this.Text = "RegistrationForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label AuthorizeLabel;
        private System.Windows.Forms.Button Button;
        private System.Windows.Forms.TextBox password_textBox;
        private System.Windows.Forms.TextBox phone_textBox;
        private System.Windows.Forms.TextBox surname_textBox;
        private System.Windows.Forms.TextBox name_textBox;
    }
}