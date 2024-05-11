using ExpressPost.Classes;
using ExpressPost.Forms;
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
        // Створення TextBox для кожного Label
        TextBox firstNameTextBox = new TextBox();
        TextBox lastNameTextBox = new TextBox();
        TextBox phoneNumberTextBox = new TextBox();

        public MyProfile()
        {
            InitializeComponent();
            LoadInfo();
        }

        private void LoadInfo()
        {
            // Встановлення шрифту для Label та TextBox
            Font userFont = new Font("Microsoft Sans Serif", 16F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            Font userFont2 = new Font("Microsoft Sans Serif", 15F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            firstNameLabel.Font = userFont;
            lastNameLabel.Font = userFont;
            phoneNumberLabel.Font = userFont;

            firstNameTextBox.Font = userFont2;
            lastNameTextBox.Font = userFont2;
            phoneNumberTextBox.Font = userFont2;

            firstNameLabel.Text = Program.CurrentUser.FirstName;
            lastNameLabel.Text = Program.CurrentUser.LastName;
            phoneNumberLabel.Text = Program.CurrentUser.PhoneNumber;

            // Ініціалізація TextBox із значеннями Label
            firstNameTextBox.Text = Program.CurrentUser.FirstName;
            lastNameTextBox.Text = Program.CurrentUser.LastName;
            phoneNumberTextBox.Text = Program.CurrentUser.PhoneNumber;

            // Встановлення положення TextBox
            int formWidth = this.ClientSize.Width; // Ширина форми
            int textBoxWidth = 300; // Збільшена ширина TextBox

            int xPosition = (formWidth - textBoxWidth) / 2; // Розрахунок координати X для вирівнювання TextBox по центру

            firstNameTextBox.Location = new Point(xPosition, 158); // Ваші координати для firstNameTextBox
            lastNameTextBox.Location = new Point(xPosition, 202); // Ваші координати для lastNameTextBox
            phoneNumberTextBox.Location = new Point(xPosition, 255); // Ваші координати для phoneNumberTextBox

            // Встановлення ширини TextBox
            firstNameTextBox.Width = textBoxWidth;
            lastNameTextBox.Width = textBoxWidth;
            phoneNumberTextBox.Width = textBoxWidth;

            // Встановлення вирівнювання тексту
            firstNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            lastNameLabel.TextAlign = ContentAlignment.MiddleCenter;
            phoneNumberLabel.TextAlign = ContentAlignment.MiddleCenter;

            firstNameTextBox.TextAlign = HorizontalAlignment.Center;
            lastNameTextBox.TextAlign = HorizontalAlignment.Center;
            phoneNumberTextBox.TextAlign = HorizontalAlignment.Center;

            // Приховуємо TextBox на початку
            firstNameTextBox.Visible = false;
            lastNameTextBox.Visible = false;
            phoneNumberTextBox.Visible = false;

            // Додаємо TextBox до форми
            this.Controls.Add(firstNameTextBox);
            this.Controls.Add(lastNameTextBox);
            this.Controls.Add(phoneNumberTextBox);
        }

        private void EditButton_Click(object sender, EventArgs e)
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

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            // Виклик методу Logout для виходу з системи
            User.Logout();
            FormProperties.SwitchToForm(this, new AuthorizeForm());
        }
    }
}
