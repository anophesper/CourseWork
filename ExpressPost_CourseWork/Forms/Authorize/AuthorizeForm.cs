using ExpressPost_CourseWork.Classes;
using ExpressPost_CourseWork.Forms.BranchAdmin;
using ExpressPost_CourseWork.Forms.Client;
using ExpressPost_CourseWork.Forms.SystemAdmin;
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
    public partial class AuthorizeForm : Form
    {
        public AuthorizeForm()
        {
            InitializeComponent();
            FormProperties.DefaultFormSetup(this);
        }

        private void EnterButton_Click(object sender, EventArgs e)
        {
            try
            {
                // Отримання введеного номера телефону та паролю
                string phoneText = phoneTextBox.Text;
                string passwordText = passwordTextBox.Text;

                // Перевірка, чи існує користувач з введеним номером телефону та паролем
                User user = Program.DataManager.Users.FirstOrDefault(u => u.PhoneNumber == phoneText && u.Password == passwordText);

                if (user != null)
                {
                    // Якщо користувач існує, зберегти інформацію про користувача
                    Program.CurrentUser = user;
                    user.Login();

                    // Визначаємо тип користувача і відкриваємо відповідну форму
                    switch (user)
                    {
                        case Classes.Client client:
                            FormProperties.SwitchToForm(this, new ClientMainForm()); break;
                        case Classes.BranchAdmin branchAdmin:
                            FormProperties.SwitchToForm(this, new BranchAdmMainForm()); break;
                        case Classes.SystemAdmin systemAdmin:
                            FormProperties.SwitchToForm(this, new SystemAdmMainForm()); break;
                        default: break;
                    }
                }
                else
                    MessageBox.Show("Невірний номер телефону або пароль");
            }
            catch (Exception ex)
            {
                // Обробка помилки
                MessageBox.Show($"Виникла помилка: {ex.Message}");
            }
        }

        private void RegistrationLabel_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new RegistrationForm());
        }
    }
}
