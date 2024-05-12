using ExpressPost.Classes;
using ExpressPost.Forms;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Common;
using System.Data.Odbc;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace ExpressPost
{
    public partial class AuthorizeForm : BaseForm
    {
        public AuthorizeForm()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, EventArgs e)
        {
            // Отримання введеного номера телефону та паролю
            string phoneText = phone.Text;
            string passwordText = password.Text;

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
                    case Client client:
                        FormProperties.SwitchToForm(this, new ClientMainForm()); break;
                    case BranchAdmin branchAdmin:
                        //FormProperties.SwitchToForm(this, new BranchAdmMainForm()); break;
                    case SystemAdmin systemAdmin:
                        //FormProperties.SwitchToForm(this, new SystemAdmMainForm()); break;
                    default: break;
                }
            }
            else
            {
                // Якщо користувача не існує, показати повідомлення про помилку
                MessageBox.Show("Невірний номер телефону або пароль");
            }
        }

        private void RegistrationLabel_Click(object sender, EventArgs e)
        {
            FormProperties.SwitchToForm(this, new RegistrationForm());
        }
    }
}
