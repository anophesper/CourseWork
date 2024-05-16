using ExpressPost_CourseWork.Classes;
using ExpressPost_CourseWork.Forms.Client;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost_CourseWork.Forms.Authorize
{
    public partial class RegistrationForm : Form
    {
        public RegistrationForm()
        {
            InitializeComponent();
            FormProperties.DefaultFormSetup(this);
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримуємо дані з текстових полів
                string firstName = firstNameTextBox.Text;
                string lastName = lastNameTextBox.Text;
                string phoneNumber = phoneTextBox.Text;
                string password = passwordTextBox.Text;

                // Створюємо новий об'єкт класу Client
                User newClient = new Classes.Client(firstName, lastName, phoneNumber, password);

                // Вставляємо нового клієнта в базу даних
                DB_DataManager.InsertIntoDatabase(newClient);
                // Зберігаємо інформацію про користувача
                Program.CurrentUser = Program.DataManager.Users.FirstOrDefault(user => user.PhoneNumber == phoneNumber);//після внесення змін в бд, списки оновлились тому робимо пошук
                Program.CurrentUser.Login();
                FormProperties.SwitchToForm(this, new ClientMainForm());
            }
            catch (Exception ex)
            {
                // Виводимо повідомлення про помилку
                MessageBox.Show("Виникла помилка: " + ex.Message);
            }
        }

        private void AuthorizationLabel_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new AuthorizeForm());
        }
    }
}
