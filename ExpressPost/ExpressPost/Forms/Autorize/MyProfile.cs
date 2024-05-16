using ExpressPost.Classes;
using ExpressPost.Forms;
using ExpressPost.Forms.Autorize;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost.Forms
{
    public partial class MyProfile : BaseForm
    {
        // Створення TextBox та Label для кожного поля
        Label firstNameLabel = new Label();
        Label lastNameLabel = new Label();
        Label phoneNumberLabel = new Label();
        
        TextBox firstNameTextBox = new TextBox();
        TextBox lastNameTextBox = new TextBox();
        TextBox phoneNumberTextBox = new TextBox();

        Button ChangePasswordButton = new Button();

        public MyProfile()
        {
            InitializeComponent();
            ElementSetting();
        }

        private void ElementSetting()
        {
            // Встановлення шрифту для Label та TextBox
            Font userFont = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            firstNameLabel.Font = userFont;
            lastNameLabel.Font = userFont;
            phoneNumberLabel.Font = userFont;

            firstNameTextBox.Font = userFont;
            lastNameTextBox.Font = userFont;
            phoneNumberTextBox.Font = userFont;

            // Ініціалізація TextBox та Label зі значеннями користувача
            firstNameLabel.Text = Program.CurrentUser.FirstName;
            lastNameLabel.Text = Program.CurrentUser.LastName;
            phoneNumberLabel.Text = Program.CurrentUser.PhoneNumber;
            
            firstNameTextBox.Text = Program.CurrentUser.FirstName;
            lastNameTextBox.Text = Program.CurrentUser.LastName;
            phoneNumberTextBox.Text = Program.CurrentUser.PhoneNumber;

            // Встановлення положення TextBox
            int formWidth = this.ClientSize.Width; // Ширина форми
            int Width = 300; // Ширина TextBox

            int xPosition = (formWidth - Width) / 2; // Розрахунок координати X для вирівнювання TextBox по центру

            // Встановлення однакового положення для Label і TextBox
            firstNameTextBox.Location = firstNameLabel.Location = new Point(xPosition, 150);
            lastNameTextBox.Location = lastNameLabel.Location = new Point(xPosition, 200);
            phoneNumberTextBox.Location = phoneNumberLabel.Location = new Point(xPosition, 250);

            // Встановлення ширини
            firstNameTextBox.Width = Width;
            lastNameTextBox.Width = Width;
            phoneNumberTextBox.Width = Width;

            firstNameLabel.Width = Width;
            lastNameLabel.Width = Width;
            phoneNumberLabel.Width = Width;

            // Встановлення вирівнювання тексту
            firstNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            lastNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            phoneNumberLabel.TextAlign = ContentAlignment.MiddleCenter;

            firstNameTextBox.TextAlign = HorizontalAlignment.Center;
            lastNameTextBox.TextAlign = HorizontalAlignment.Center;
            phoneNumberTextBox.TextAlign = HorizontalAlignment.Center;

            // Додаємо TextBox до форми
            this.Controls.Add(firstNameTextBox);
            this.Controls.Add(lastNameTextBox);
            this.Controls.Add(phoneNumberTextBox);

            // Додаємо Label до форми
            this.Controls.Add(firstNameLabel);
            this.Controls.Add(lastNameLabel);
            this.Controls.Add(phoneNumberLabel);

            // Приховуємо TextBox на початку
            firstNameTextBox.Visible = false;
            lastNameTextBox.Visible = false;
            phoneNumberTextBox.Visible = false;

            // Ініціалізація кнопки зміни паролю
            ChangePasswordButton.Text = "Change Password";
            ChangePasswordButton.Location = new Point(xPosition, 300); // Встановлення положення кнопки
            ChangePasswordButton.Size = new Size(130, 30);//Встановлюємо розміри кнопки
            ChangePasswordButton.Visible = false; // Приховуємо кнопку на початку

            // Додаємо кнопку до форми
            this.Controls.Add(ChangePasswordButton);

            // Додаємо обробник подій для кнопки
            ChangePasswordButton.Click += ChangePasswordButton_Click;
        }

        private void EditButton_Click(object sender, EventArgs e)
        {
            try
            {
                if (EditButton.Text == "Edit")
                {
                    // Приховуємо Label і робимо TextBox видимим
                    firstNameLabel.Visible = false;
                    lastNameLabel.Visible = false;
                    phoneNumberLabel.Visible = false;

                    firstNameTextBox.Visible = true;
                    lastNameTextBox.Visible = true;
                    phoneNumberTextBox.Visible = true;

                    EditButton.Text = "Save changes";
                    LogOutButton.Visible = false;
                    ChangePasswordButton.Visible = true;
                }
                else if (EditButton.Text == "Save changes")
                {
                    // Приховуємо TextBox  і робимо Label видимим
                    firstNameTextBox.Visible = false;
                    lastNameTextBox.Visible = false;
                    phoneNumberTextBox.Visible = false;

                    firstNameLabel.Visible = true;
                    lastNameLabel.Visible = true;
                    phoneNumberLabel.Visible = true;

                    EditButton.Text = "Edit";
                    LogOutButton.Visible = true;
                    ChangePasswordButton.Visible = false;

                    // Оновлюємо дані користувача
                    Program.CurrentUser.FirstName = firstNameTextBox.Text;
                    Program.CurrentUser.LastName = lastNameTextBox.Text;
                    Program.CurrentUser.PhoneNumber = phoneNumberTextBox.Text;

                    // Зберігаємо зміни в базі даних
                    DB_DataManager.UpdateDatabase(Program.CurrentUser);

                    // Оновлюємо Label з новими даними
                    firstNameLabel.Text = Program.CurrentUser.FirstName;
                    lastNameLabel.Text = Program.CurrentUser.LastName;
                    phoneNumberLabel.Text = Program.CurrentUser.PhoneNumber;
                }
            }
            catch (Exception ex)
            {
                // Обробка помилок
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }

        private void ChangePasswordButton_Click(object sender, EventArgs e)
        {
            ChangePasswordForm changePasswordForm = new ChangePasswordForm();
            changePasswordForm.Show();
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Виклик методу Logout для виходу з системи
                User.Logout();
                FormProperties.SwitchToForm(this, new AuthorizeForm());
            }
            catch (Exception ex)
            {
                // Обробка помилок
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}
