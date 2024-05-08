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
    public partial class AuthorizeForm : Form
    {
        DBConnection dbConnection;

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
            User user = Program.dataManager.Users.FirstOrDefault(u => u.PhoneNumber == phoneText && u.Password == passwordText);

            if (user != null)
            {
                // Якщо користувач існує, зберегти інформацію про користувача
                user.Login();
                // Закриття поточної форми
                this.Hide();
                //Відкрити головну форму
                MainForm mainForm = new MainForm();
                mainForm.Show();
            }
            else
            {
                // Якщо користувача не існує, показати повідомлення про помилку
                MessageBox.Show("Невірний номер телефону або пароль");
            }
        }
    }
}
