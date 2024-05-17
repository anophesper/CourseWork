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
    public partial class ChangePasswordForm : Form
    {
        public ChangePasswordForm()
        {
            InitializeComponent();

            //відцентровали форму по цетру, налаштували розмір та стиль вікна
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Size = new Size(500, 270);
            this.BackColor = Color.LightGray;

            //додаємо кнопку для закриття форми
            PictureBox ExitBox = new PictureBox
            {
                Image = Properties.Resources._4115230_cancel_close_delete_icon,
                SizeMode = PictureBoxSizeMode.Zoom,
                Size = new Size(30, 25),
                Location = new Point(470, 0)
            };
            ExitBox.Click += (sender, e) => { this.Hide(); }; // додаємо обробник події Click
            this.Controls.Add(ExitBox); // додаємо ExitBox до форми
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            try
            {
                string currentUserPassword = Program.CurrentUser.Password;
                if (currentPasswordTextBox.Text != currentUserPassword)
                    throw new Exception("Поточний пароль введено неправильно");

                if (newPasswordTextBox.Text != newPasswordAgainTextBox.Text)
                    throw new Exception("Нові паролі не співпадають");

                // Якщо все в порядку, оновлюємо пароль
                Program.CurrentUser.Password = newPasswordTextBox.Text;
                DB_DataManager.UpdateDatabase(Program.CurrentUser); // Оновлюємо дані в базі даних

                // Повідомлення про успішну зміну паролю
                MessageBox.Show("Пароль успішно змінено");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Помилка: " + ex.Message);
            }
        }
    }
}
