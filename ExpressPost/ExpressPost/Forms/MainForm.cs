using ExpressPost.Classes;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Logout_button_Click(object sender, EventArgs e)
        {
            // Виклик методу Logout для виходу з системи
            User.Logout();
            // Закриття поточної форми
            this.Hide();
            // Перехід до форми авторизації
            AuthorizeForm authorizeForm = new AuthorizeForm();
            authorizeForm.Show();
        }
    }
}
