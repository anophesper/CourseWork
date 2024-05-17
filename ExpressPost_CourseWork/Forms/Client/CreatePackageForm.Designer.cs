namespace ExpressPost_CourseWork.Forms.Client
{
    partial class CreatePackageForm
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
            this.billOfLadingLabel = new System.Windows.Forms.Label();
            this.senderInformationLabel = new System.Windows.Forms.Label();
            this.senderNameLabel = new System.Windows.Forms.Label();
            this.SenderNameTextBox = new System.Windows.Forms.TextBox();
            this.SenderPhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.senderPhoneNumberLabel = new System.Windows.Forms.Label();
            this.parcelTypeLabel = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.CargoRadioButton = new System.Windows.Forms.RadioButton();
            this.ParcelRadioButton = new System.Windows.Forms.RadioButton();
            this.DocumentRadioButton = new System.Windows.Forms.RadioButton();
            this.EstimatedCostTextBox = new System.Windows.Forms.TextBox();
            this.EstimatedCostLabel = new System.Windows.Forms.Label();
            this.WeightTextBox = new System.Windows.Forms.TextBox();
            this.weightLabel = new System.Windows.Forms.Label();
            this.RecipientPhoneNumberTextBox = new System.Windows.Forms.TextBox();
            this.recipientPhoneNumberLabel = new System.Windows.Forms.Label();
            this.RecipientNameTextBox = new System.Windows.Forms.TextBox();
            this.recipientNameLabel = new System.Windows.Forms.Label();
            this.recipientInformationLabel = new System.Windows.Forms.Label();
            this.departmentRecipientLabel = new System.Windows.Forms.Label();
            this.cityRecipientLabel = new System.Windows.Forms.Label();
            this.CityRecipientComboBox = new System.Windows.Forms.ComboBox();
            this.DepartmentRecipientComboBox = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.RecipientRadioButton = new System.Windows.Forms.RadioButton();
            this.SenderRadioButton = new System.Windows.Forms.RadioButton();
            this.label = new System.Windows.Forms.Label();
            this.CreateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.DepartmentSenderComboBox = new System.Windows.Forms.ComboBox();
            this.CitySenderComboBox = new System.Windows.Forms.ComboBox();
            this.departmentSenderLabel = new System.Windows.Forms.Label();
            this.citySenderLabel = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // billOfLadingLabel
            // 
            this.billOfLadingLabel.AutoSize = true;
            this.billOfLadingLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.billOfLadingLabel.Location = new System.Drawing.Point(82, 18);
            this.billOfLadingLabel.Name = "billOfLadingLabel";
            this.billOfLadingLabel.Size = new System.Drawing.Size(53, 25);
            this.billOfLadingLabel.TabIndex = 0;
            this.billOfLadingLabel.Text = "ТТН";
            // 
            // senderInformationLabel
            // 
            this.senderInformationLabel.AutoSize = true;
            this.senderInformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.senderInformationLabel.Location = new System.Drawing.Point(81, 55);
            this.senderInformationLabel.Name = "senderInformationLabel";
            this.senderInformationLabel.Size = new System.Drawing.Size(263, 24);
            this.senderInformationLabel.TabIndex = 1;
            this.senderInformationLabel.Text = "Інформація про відправника";
            // 
            // senderNameLabel
            // 
            this.senderNameLabel.AutoSize = true;
            this.senderNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.senderNameLabel.Location = new System.Drawing.Point(81, 95);
            this.senderNameLabel.Name = "senderNameLabel";
            this.senderNameLabel.Size = new System.Drawing.Size(113, 20);
            this.senderNameLabel.TabIndex = 2;
            this.senderNameLabel.Text = "Прізвище Ім\'я";
            // 
            // SenderNameTextBox
            // 
            this.SenderNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SenderNameTextBox.Location = new System.Drawing.Point(85, 118);
            this.SenderNameTextBox.Name = "SenderNameTextBox";
            this.SenderNameTextBox.Size = new System.Drawing.Size(200, 29);
            this.SenderNameTextBox.TabIndex = 3;
            // 
            // SenderPhoneNumberTextBox
            // 
            this.SenderPhoneNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SenderPhoneNumberTextBox.Location = new System.Drawing.Point(84, 181);
            this.SenderPhoneNumberTextBox.Name = "SenderPhoneNumberTextBox";
            this.SenderPhoneNumberTextBox.Size = new System.Drawing.Size(200, 29);
            this.SenderPhoneNumberTextBox.TabIndex = 5;
            this.SenderPhoneNumberTextBox.TextChanged += new System.EventHandler(this.SenderPhoneNumberTextBox_TextChanged);
            // 
            // senderPhoneNumberLabel
            // 
            this.senderPhoneNumberLabel.AutoSize = true;
            this.senderPhoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.senderPhoneNumberLabel.Location = new System.Drawing.Point(80, 158);
            this.senderPhoneNumberLabel.Name = "senderPhoneNumberLabel";
            this.senderPhoneNumberLabel.Size = new System.Drawing.Size(140, 20);
            this.senderPhoneNumberLabel.TabIndex = 4;
            this.senderPhoneNumberLabel.Text = "Номер телефону";
            // 
            // parcelTypeLabel
            // 
            this.parcelTypeLabel.AutoSize = true;
            this.parcelTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.parcelTypeLabel.Location = new System.Drawing.Point(642, 95);
            this.parcelTypeLabel.Name = "parcelTypeLabel";
            this.parcelTypeLabel.Size = new System.Drawing.Size(102, 20);
            this.parcelTypeLabel.TabIndex = 6;
            this.parcelTypeLabel.Text = "Тип посилки";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.CargoRadioButton);
            this.panel1.Controls.Add(this.ParcelRadioButton);
            this.panel1.Controls.Add(this.DocumentRadioButton);
            this.panel1.Location = new System.Drawing.Point(646, 118);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(171, 93);
            this.panel1.TabIndex = 7;
            // 
            // CargoRadioButton
            // 
            this.CargoRadioButton.AutoSize = true;
            this.CargoRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CargoRadioButton.Location = new System.Drawing.Point(3, 63);
            this.CargoRadioButton.Name = "CargoRadioButton";
            this.CargoRadioButton.Size = new System.Drawing.Size(152, 24);
            this.CargoRadioButton.TabIndex = 2;
            this.CargoRadioButton.TabStop = true;
            this.CargoRadioButton.Text = "Великий вантаж";
            this.CargoRadioButton.UseVisualStyleBackColor = true;
            // 
            // ParcelRadioButton
            // 
            this.ParcelRadioButton.AutoSize = true;
            this.ParcelRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ParcelRadioButton.Location = new System.Drawing.Point(3, 33);
            this.ParcelRadioButton.Name = "ParcelRadioButton";
            this.ParcelRadioButton.Size = new System.Drawing.Size(163, 24);
            this.ParcelRadioButton.TabIndex = 1;
            this.ParcelRadioButton.TabStop = true;
            this.ParcelRadioButton.Text = "Посилка (до 30кг)";
            this.ParcelRadioButton.UseVisualStyleBackColor = true;
            // 
            // DocumentRadioButton
            // 
            this.DocumentRadioButton.AutoSize = true;
            this.DocumentRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DocumentRadioButton.Location = new System.Drawing.Point(3, 3);
            this.DocumentRadioButton.Name = "DocumentRadioButton";
            this.DocumentRadioButton.Size = new System.Drawing.Size(110, 24);
            this.DocumentRadioButton.TabIndex = 0;
            this.DocumentRadioButton.TabStop = true;
            this.DocumentRadioButton.Text = "Документи";
            this.DocumentRadioButton.UseVisualStyleBackColor = true;
            // 
            // EstimatedCostTextBox
            // 
            this.EstimatedCostTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EstimatedCostTextBox.Location = new System.Drawing.Point(646, 300);
            this.EstimatedCostTextBox.Name = "EstimatedCostTextBox";
            this.EstimatedCostTextBox.Size = new System.Drawing.Size(200, 29);
            this.EstimatedCostTextBox.TabIndex = 11;
            // 
            // EstimatedCostLabel
            // 
            this.EstimatedCostLabel.AutoSize = true;
            this.EstimatedCostLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.EstimatedCostLabel.Location = new System.Drawing.Point(642, 277);
            this.EstimatedCostLabel.Name = "EstimatedCostLabel";
            this.EstimatedCostLabel.Size = new System.Drawing.Size(147, 20);
            this.EstimatedCostLabel.TabIndex = 10;
            this.EstimatedCostLabel.Text = "Оціночна вартість";
            // 
            // WeightTextBox
            // 
            this.WeightTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.WeightTextBox.Location = new System.Drawing.Point(646, 239);
            this.WeightTextBox.Name = "WeightTextBox";
            this.WeightTextBox.Size = new System.Drawing.Size(200, 29);
            this.WeightTextBox.TabIndex = 9;
            // 
            // weightLabel
            // 
            this.weightLabel.AutoSize = true;
            this.weightLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.weightLabel.Location = new System.Drawing.Point(642, 216);
            this.weightLabel.Name = "weightLabel";
            this.weightLabel.Size = new System.Drawing.Size(45, 20);
            this.weightLabel.TabIndex = 8;
            this.weightLabel.Text = "Вага";
            // 
            // RecipientPhoneNumberTextBox
            // 
            this.RecipientPhoneNumberTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecipientPhoneNumberTextBox.Location = new System.Drawing.Point(363, 181);
            this.RecipientPhoneNumberTextBox.Name = "RecipientPhoneNumberTextBox";
            this.RecipientPhoneNumberTextBox.Size = new System.Drawing.Size(200, 29);
            this.RecipientPhoneNumberTextBox.TabIndex = 16;
            this.RecipientPhoneNumberTextBox.TextChanged += new System.EventHandler(this.RecipientPhoneNumberTextBox_TextChanged);
            // 
            // recipientPhoneNumberLabel
            // 
            this.recipientPhoneNumberLabel.AutoSize = true;
            this.recipientPhoneNumberLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipientPhoneNumberLabel.Location = new System.Drawing.Point(359, 158);
            this.recipientPhoneNumberLabel.Name = "recipientPhoneNumberLabel";
            this.recipientPhoneNumberLabel.Size = new System.Drawing.Size(140, 20);
            this.recipientPhoneNumberLabel.TabIndex = 15;
            this.recipientPhoneNumberLabel.Text = "Номер телефону";
            // 
            // RecipientNameTextBox
            // 
            this.RecipientNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecipientNameTextBox.Location = new System.Drawing.Point(364, 118);
            this.RecipientNameTextBox.Name = "RecipientNameTextBox";
            this.RecipientNameTextBox.Size = new System.Drawing.Size(200, 29);
            this.RecipientNameTextBox.TabIndex = 14;
            // 
            // recipientNameLabel
            // 
            this.recipientNameLabel.AutoSize = true;
            this.recipientNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipientNameLabel.Location = new System.Drawing.Point(360, 95);
            this.recipientNameLabel.Name = "recipientNameLabel";
            this.recipientNameLabel.Size = new System.Drawing.Size(113, 20);
            this.recipientNameLabel.TabIndex = 13;
            this.recipientNameLabel.Text = "Прізвище Ім\'я";
            // 
            // recipientInformationLabel
            // 
            this.recipientInformationLabel.AutoSize = true;
            this.recipientInformationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.recipientInformationLabel.Location = new System.Drawing.Point(360, 55);
            this.recipientInformationLabel.Name = "recipientInformationLabel";
            this.recipientInformationLabel.Size = new System.Drawing.Size(261, 24);
            this.recipientInformationLabel.TabIndex = 12;
            this.recipientInformationLabel.Text = "Інформація про одержувача";
            // 
            // departmentRecipientLabel
            // 
            this.departmentRecipientLabel.AutoSize = true;
            this.departmentRecipientLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentRecipientLabel.Location = new System.Drawing.Point(360, 277);
            this.departmentRecipientLabel.Name = "departmentRecipientLabel";
            this.departmentRecipientLabel.Size = new System.Drawing.Size(94, 20);
            this.departmentRecipientLabel.TabIndex = 19;
            this.departmentRecipientLabel.Text = "Відділення";
            // 
            // cityRecipientLabel
            // 
            this.cityRecipientLabel.AutoSize = true;
            this.cityRecipientLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cityRecipientLabel.Location = new System.Drawing.Point(360, 217);
            this.cityRecipientLabel.Name = "cityRecipientLabel";
            this.cityRecipientLabel.Size = new System.Drawing.Size(51, 20);
            this.cityRecipientLabel.TabIndex = 17;
            this.cityRecipientLabel.Text = "Місто";
            // 
            // CityRecipientComboBox
            // 
            this.CityRecipientComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CityRecipientComboBox.FormattingEnabled = true;
            this.CityRecipientComboBox.Location = new System.Drawing.Point(363, 239);
            this.CityRecipientComboBox.Name = "CityRecipientComboBox";
            this.CityRecipientComboBox.Size = new System.Drawing.Size(200, 28);
            this.CityRecipientComboBox.TabIndex = 21;
            this.CityRecipientComboBox.SelectedIndexChanged += new System.EventHandler(this.CityRecipientComboBox_SelectedIndexChanged);
            // 
            // DepartmentRecipientComboBox
            // 
            this.DepartmentRecipientComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentRecipientComboBox.FormattingEnabled = true;
            this.DepartmentRecipientComboBox.Location = new System.Drawing.Point(364, 300);
            this.DepartmentRecipientComboBox.Name = "DepartmentRecipientComboBox";
            this.DepartmentRecipientComboBox.Size = new System.Drawing.Size(200, 28);
            this.DepartmentRecipientComboBox.TabIndex = 22;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.RecipientRadioButton);
            this.panel2.Controls.Add(this.SenderRadioButton);
            this.panel2.Location = new System.Drawing.Point(87, 368);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(171, 71);
            this.panel2.TabIndex = 9;
            // 
            // RecipientRadioButton
            // 
            this.RecipientRadioButton.AutoSize = true;
            this.RecipientRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RecipientRadioButton.Location = new System.Drawing.Point(3, 33);
            this.RecipientRadioButton.Name = "RecipientRadioButton";
            this.RecipientRadioButton.Size = new System.Drawing.Size(111, 24);
            this.RecipientRadioButton.TabIndex = 1;
            this.RecipientRadioButton.TabStop = true;
            this.RecipientRadioButton.Text = "Отримувач";
            this.RecipientRadioButton.UseVisualStyleBackColor = true;
            // 
            // SenderRadioButton
            // 
            this.SenderRadioButton.AutoSize = true;
            this.SenderRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SenderRadioButton.Location = new System.Drawing.Point(3, 3);
            this.SenderRadioButton.Name = "SenderRadioButton";
            this.SenderRadioButton.Size = new System.Drawing.Size(114, 24);
            this.SenderRadioButton.TabIndex = 0;
            this.SenderRadioButton.TabStop = true;
            this.SenderRadioButton.Text = "Відправник";
            this.SenderRadioButton.UseVisualStyleBackColor = true;
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(82, 348);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(197, 20);
            this.label.TabIndex = 8;
            this.label.Text = "Оплата послуг доставки";
            // 
            // CreateButton
            // 
            this.CreateButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CreateButton.Location = new System.Drawing.Point(390, 449);
            this.CreateButton.Name = "CreateButton";
            this.CreateButton.Size = new System.Drawing.Size(150, 40);
            this.CreateButton.TabIndex = 23;
            this.CreateButton.Text = "Створити";
            this.CreateButton.UseVisualStyleBackColor = true;
            this.CreateButton.Click += new System.EventHandler(this.CreateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(643, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(261, 24);
            this.label1.TabIndex = 24;
            this.label1.Text = "Інформація про одержувача";
            // 
            // DepartmentSenderComboBox
            // 
            this.DepartmentSenderComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.DepartmentSenderComboBox.FormattingEnabled = true;
            this.DepartmentSenderComboBox.Location = new System.Drawing.Point(85, 300);
            this.DepartmentSenderComboBox.Name = "DepartmentSenderComboBox";
            this.DepartmentSenderComboBox.Size = new System.Drawing.Size(200, 28);
            this.DepartmentSenderComboBox.TabIndex = 28;
            // 
            // CitySenderComboBox
            // 
            this.CitySenderComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CitySenderComboBox.FormattingEnabled = true;
            this.CitySenderComboBox.Location = new System.Drawing.Point(84, 239);
            this.CitySenderComboBox.Name = "CitySenderComboBox";
            this.CitySenderComboBox.Size = new System.Drawing.Size(200, 28);
            this.CitySenderComboBox.TabIndex = 27;
            this.CitySenderComboBox.SelectedIndexChanged += new System.EventHandler(this.CitySenderComboBox_SelectedIndexChanged);
            // 
            // departmentSenderLabel
            // 
            this.departmentSenderLabel.AutoSize = true;
            this.departmentSenderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.departmentSenderLabel.Location = new System.Drawing.Point(81, 277);
            this.departmentSenderLabel.Name = "departmentSenderLabel";
            this.departmentSenderLabel.Size = new System.Drawing.Size(94, 20);
            this.departmentSenderLabel.TabIndex = 26;
            this.departmentSenderLabel.Text = "Відділення";
            // 
            // citySenderLabel
            // 
            this.citySenderLabel.AutoSize = true;
            this.citySenderLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.citySenderLabel.Location = new System.Drawing.Point(81, 217);
            this.citySenderLabel.Name = "citySenderLabel";
            this.citySenderLabel.Size = new System.Drawing.Size(51, 20);
            this.citySenderLabel.TabIndex = 25;
            this.citySenderLabel.Text = "Місто";
            // 
            // CreatePackageForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 540);
            this.Controls.Add(this.DepartmentSenderComboBox);
            this.Controls.Add(this.CitySenderComboBox);
            this.Controls.Add(this.departmentSenderLabel);
            this.Controls.Add(this.citySenderLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CreateButton);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label);
            this.Controls.Add(this.DepartmentRecipientComboBox);
            this.Controls.Add(this.CityRecipientComboBox);
            this.Controls.Add(this.departmentRecipientLabel);
            this.Controls.Add(this.cityRecipientLabel);
            this.Controls.Add(this.RecipientPhoneNumberTextBox);
            this.Controls.Add(this.recipientPhoneNumberLabel);
            this.Controls.Add(this.RecipientNameTextBox);
            this.Controls.Add(this.recipientNameLabel);
            this.Controls.Add(this.recipientInformationLabel);
            this.Controls.Add(this.EstimatedCostTextBox);
            this.Controls.Add(this.EstimatedCostLabel);
            this.Controls.Add(this.WeightTextBox);
            this.Controls.Add(this.weightLabel);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.parcelTypeLabel);
            this.Controls.Add(this.SenderPhoneNumberTextBox);
            this.Controls.Add(this.senderPhoneNumberLabel);
            this.Controls.Add(this.SenderNameTextBox);
            this.Controls.Add(this.senderNameLabel);
            this.Controls.Add(this.senderInformationLabel);
            this.Controls.Add(this.billOfLadingLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CreatePackageForm";
            this.Text = "CreatePackageForm";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label billOfLadingLabel;
        private System.Windows.Forms.Label senderInformationLabel;
        private System.Windows.Forms.Label senderNameLabel;
        private System.Windows.Forms.TextBox SenderNameTextBox;
        private System.Windows.Forms.TextBox SenderPhoneNumberTextBox;
        private System.Windows.Forms.Label senderPhoneNumberLabel;
        private System.Windows.Forms.Label parcelTypeLabel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton CargoRadioButton;
        private System.Windows.Forms.RadioButton ParcelRadioButton;
        private System.Windows.Forms.RadioButton DocumentRadioButton;
        private System.Windows.Forms.TextBox EstimatedCostTextBox;
        private System.Windows.Forms.Label EstimatedCostLabel;
        private System.Windows.Forms.TextBox WeightTextBox;
        private System.Windows.Forms.Label weightLabel;
        private System.Windows.Forms.TextBox RecipientPhoneNumberTextBox;
        private System.Windows.Forms.Label recipientPhoneNumberLabel;
        private System.Windows.Forms.TextBox RecipientNameTextBox;
        private System.Windows.Forms.Label recipientNameLabel;
        private System.Windows.Forms.Label recipientInformationLabel;
        private System.Windows.Forms.Label departmentRecipientLabel;
        private System.Windows.Forms.Label cityRecipientLabel;
        private System.Windows.Forms.ComboBox CityRecipientComboBox;
        private System.Windows.Forms.ComboBox DepartmentRecipientComboBox;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.RadioButton RecipientRadioButton;
        private System.Windows.Forms.RadioButton SenderRadioButton;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button CreateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox DepartmentSenderComboBox;
        private System.Windows.Forms.ComboBox CitySenderComboBox;
        private System.Windows.Forms.Label departmentSenderLabel;
        private System.Windows.Forms.Label citySenderLabel;
    }
}