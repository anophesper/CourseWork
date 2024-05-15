namespace ControlLibrary1
{
    partial class ParcelCard
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.billOfLadingLabel = new System.Windows.Forms.Label();
            this.city1Label = new System.Windows.Forms.Label();
            this.city2Label = new System.Windows.Forms.Label();
            this.data2Label = new System.Windows.Forms.Label();
            this.data1Label = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // billOfLadingLabel
            // 
            this.billOfLadingLabel.AutoSize = true;
            this.billOfLadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billOfLadingLabel.Location = new System.Drawing.Point(10, 10);
            this.billOfLadingLabel.Name = "billOfLadingLabel";
            this.billOfLadingLabel.Size = new System.Drawing.Size(120, 24);
            this.billOfLadingLabel.TabIndex = 0;
            this.billOfLadingLabel.Text = "Bill Of Lading";
            // 
            // city1Label
            // 
            this.city1Label.AutoSize = true;
            this.city1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.city1Label.Location = new System.Drawing.Point(9, 67);
            this.city1Label.Name = "city1Label";
            this.city1Label.Size = new System.Drawing.Size(44, 20);
            this.city1Label.TabIndex = 1;
            this.city1Label.Text = "City1";
            // 
            // city2Label
            // 
            this.city2Label.AutoSize = true;
            this.city2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.city2Label.Location = new System.Drawing.Point(230, 67);
            this.city2Label.Name = "city2Label";
            this.city2Label.Size = new System.Drawing.Size(44, 20);
            this.city2Label.TabIndex = 2;
            this.city2Label.Text = "City2";
            // 
            // data2Label
            // 
            this.data2Label.AutoSize = true;
            this.data2Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data2Label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.data2Label.Location = new System.Drawing.Point(230, 44);
            this.data2Label.Name = "data2Label";
            this.data2Label.Size = new System.Drawing.Size(47, 18);
            this.data2Label.TabIndex = 4;
            this.data2Label.Text = "Data2";
            // 
            // data1Label
            // 
            this.data1Label.AutoSize = true;
            this.data1Label.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.data1Label.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.data1Label.Location = new System.Drawing.Point(10, 44);
            this.data1Label.Name = "data1Label";
            this.data1Label.Size = new System.Drawing.Size(47, 18);
            this.data1Label.TabIndex = 3;
            this.data1Label.Text = "Data1";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(96, 98);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(90, 30);
            this.button1.TabIndex = 5;
            this.button1.Text = "Checked";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ParcelCard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Controls.Add(this.button1);
            this.Controls.Add(this.data2Label);
            this.Controls.Add(this.data1Label);
            this.Controls.Add(this.city2Label);
            this.Controls.Add(this.city1Label);
            this.Controls.Add(this.billOfLadingLabel);
            this.Name = "ParcelCard";
            this.Size = new System.Drawing.Size(287, 144);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label billOfLadingLabel;
        private System.Windows.Forms.Label city1Label;
        private System.Windows.Forms.Label city2Label;
        private System.Windows.Forms.Label data2Label;
        private System.Windows.Forms.Label data1Label;
        private System.Windows.Forms.Button button1;
    }
}
