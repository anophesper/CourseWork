namespace ExpressPost_CourseWork.Forms.SystemAdmin
{
    partial class WorkersForm
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
            this.EditButton = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.OpenWordButton = new System.Windows.Forms.Button();
            this.OpenExelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // EditButton
            // 
            this.EditButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EditButton.Location = new System.Drawing.Point(60, 13);
            this.EditButton.Name = "EditButton";
            this.EditButton.Size = new System.Drawing.Size(150, 40);
            this.EditButton.TabIndex = 14;
            this.EditButton.Text = "Редагувати";
            this.EditButton.UseVisualStyleBackColor = true;
            this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(30, 65);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(900, 450);
            this.dataGridView.TabIndex = 15;
            // 
            // OpenWordButton
            // 
            this.OpenWordButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenWordButton.Location = new System.Drawing.Point(468, 12);
            this.OpenWordButton.Name = "OpenWordButton";
            this.OpenWordButton.Size = new System.Drawing.Size(213, 40);
            this.OpenWordButton.TabIndex = 16;
            this.OpenWordButton.Text = "Відкрити в MS Word ";
            this.OpenWordButton.UseVisualStyleBackColor = true;
            this.OpenWordButton.Click += new System.EventHandler(this.OpenWordButton_Click);
            // 
            // OpenExelButton
            // 
            this.OpenExelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.OpenExelButton.Location = new System.Drawing.Point(687, 12);
            this.OpenExelButton.Name = "OpenExelButton";
            this.OpenExelButton.Size = new System.Drawing.Size(213, 40);
            this.OpenExelButton.TabIndex = 17;
            this.OpenExelButton.Text = "Відкрити в MS Excel ";
            this.OpenExelButton.UseVisualStyleBackColor = true;
            this.OpenExelButton.Click += new System.EventHandler(this.OpenExelButton_Click);
            // 
            // WorkersForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.OpenExelButton);
            this.Controls.Add(this.OpenWordButton);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.EditButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WorkersForm";
            this.Text = "WorkersForm";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EditButton;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button OpenWordButton;
        private System.Windows.Forms.Button OpenExelButton;
    }
}