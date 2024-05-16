using ExpressPost.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpressPost.Forms
{
    public partial class RegistrationForm : BaseForm
    {
        public RegistrationForm()
        {
            InitializeComponent();
        }

        private void AuthorizeLabel_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new AuthorizeForm());
        }

        private void Button_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримуємо дані з текстових полів
                string firstName = name_textBox.Text;
                string lastName = surname_textBox.Text;
                string phoneNumber = phone_textBox.Text;
                string password = password_textBox.Text;

                // Створюємо новий об'єкт класу Client
                User newClient = new Client(firstName, lastName, phoneNumber, password);

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
    }
}
